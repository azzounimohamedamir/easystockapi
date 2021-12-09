using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.Orders.Commands
{
    public class OrdersCommandsHandlers : IRequestHandler<CreateOrderCommand, Created>,
        IRequestHandler<UpdateOrderCommand, NoContent>,
        IRequestHandler<UpdateOrderStatusCommand, NoContent>

    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly string CreateAction = "CreateAction";
        private readonly string UpdateAction = "UpdateAction";

        public OrdersCommandsHandlers(IApplicationDbContext context, IMapper mapper, IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<Created> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateOrderCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var foodBusiness = await _context.FoodBusinesses.FindAsync(Guid.Parse(request.FoodBusinessId));
            if (foodBusiness == null)
                throw new NotFoundException(nameof(FoodBusiness), request.FoodBusinessId);

            if(request.FoodBusinessClientId != null)
            {
                var foodBusinessClient = await _context.FoodBusinessClients.FindAsync(Guid.Parse(request.FoodBusinessClientId));
                if (foodBusinessClient == null)
                    throw new NotFoundException(nameof(FoodBusinessClient), request.FoodBusinessClientId);
            }

            var order = _mapper.Map<Order>(request);
            order.CreatedBy = ChecksHelper.GetUserIdFromToken_ThrowExceptionIfUserIdIsNullOrEmpty(_userService);
            order.CreatedAt = DateTime.Now;

            ChangeStatusForOccupiedTablesOnlyIfOrderTypeIsDineIn(order, CreateAction);
            CalculateAndSetOrderEnergeticValues(order);
            CalculateAndSetOrderTotalPrice(order);
            CalculateAndSetOrderNumber(order, foodBusiness);
            _context.Orders.Add(order);
           await _context.SaveChangesAsync(cancellationToken);
                     
            return default;
        }

      
        public async Task<NoContent> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateOrderCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            if (request.FoodBusinessClientId != null)
            {
                var foodBusinessClient = await _context.FoodBusinessClients.FindAsync(Guid.Parse(request.FoodBusinessClientId));
                if (foodBusinessClient == null)
                    throw new NotFoundException(nameof(FoodBusinessClient), request.FoodBusinessClientId);
            }

            var order = await _context.Orders
                .Include(o => o.Dishes)
                .ThenInclude(o => o.Specifications)
                .Include(o => o.Dishes)
                .ThenInclude(o => o.Ingredients)
                .Include(o => o.Dishes)
                .ThenInclude(o => o.Supplements)
                .Include(o => o.Products)
                .Include(o => o.OccupiedTables)
                .FirstOrDefaultAsync(o => o.OrderId == Guid.Parse(request.Id), cancellationToken)
                .ConfigureAwait(false);

            if (order == null)
                throw new NotFoundException(nameof(Order), request.Id);

            var releasedTables = GetReleasedTables(order, request);

            _mapper.Map(request, order);
            order.LastModifiedBy = ChecksHelper.GetUserIdFromToken_ThrowExceptionIfUserIdIsNullOrEmpty(_userService);
            order.LastModifiedAt = DateTime.Now;

            ChangeStatusForReleasedTablesOnlyIfOrderTypeIsDineIn(releasedTables);
            ChangeStatusForOccupiedTablesOnlyIfOrderTypeIsDineIn(order, UpdateAction);
            CalculateAndSetOrderEnergeticValues(order);
            CalculateAndSetOrderTotalPrice(order);
            _context.Orders.Update(order);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }


        public async Task<NoContent> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateOrderStatusCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var order = await _context.Orders
                .Include(o => o.Dishes)
                .ThenInclude(o => o.Specifications)
                .Include(o => o.Dishes) 
                .ThenInclude(o => o.Ingredients)
                .Include(o => o.Dishes)
                .ThenInclude(o => o.Supplements)
                .Include(o => o.Products)
                .Include(o => o.OccupiedTables)
                .FirstOrDefaultAsync(o => o.OrderId == Guid.Parse(request.Id), cancellationToken)
                .ConfigureAwait(false);
            if (order == null)
                throw new NotFoundException(nameof(Order), request.Id);

            _mapper.Map(request, order);
            order.LastModifiedBy = ChecksHelper.GetUserIdFromToken_ThrowExceptionIfUserIdIsNullOrEmpty(_userService);
            order.LastModifiedAt = DateTime.Now;

            _context.Orders.Update(order);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }


        private void CalculateAndSetOrderNumber(Order order, Domain.Entities.FoodBusiness foodBusiness)
        {
            var maxOrderNumber = 0;
            var algeriaZone = GetAlgeriaTimeZone();

            var utcNow = DateTime.UtcNow;
            var algeriaTimeNow = TimeZoneInfo.ConvertTimeFromUtc(utcNow, algeriaZone);

            var orderNumberLastResetDateTimeInUtc = TimeZoneInfo.ConvertTimeToUtc(foodBusiness.OrderNumberLastResetDateTime);
            var orderNumberLastResetDateTimeInAlgeriaTime = TimeZoneInfo.ConvertTimeFromUtc(orderNumberLastResetDateTimeInUtc, algeriaZone);

            if (orderNumberLastResetDateTimeInAlgeriaTime.Day == algeriaTimeNow.Day)
            {
                maxOrderNumber = _context.Orders
                      .Where(x => x.FoodBusinessId == foodBusiness.FoodBusinessId)
                      .OrderByDescending(p => p.Number)
                      .Select(x => x.Number)
                      .FirstOrDefault();
            }
            else
            {
                foodBusiness.OrderNumberLastResetDateTime = DateTime.Now;
                _context.FoodBusinesses.Update(foodBusiness);
            }
          
            order.Number = maxOrderNumber + 1;
        }


        private  void CalculateAndSetOrderTotalPrice(Order order)
        {
            float totalToPay = 0;

            foreach (var dish in order.Dishes)
            {
                float totalDishPrice = dish.InitialPrice;

                foreach (var supplement in dish.Supplements)
                {
                    if(supplement.IsSelected == true)
                        totalDishPrice += supplement.Price;
                }

                foreach (var ingredient in dish.Ingredients)
                {
                    totalDishPrice += (ingredient.Steps * ingredient.PriceIncreasePerStep);
                }
                dish.UnitPrice = totalDishPrice;
                totalToPay += (dish.Quantity * totalDishPrice);
            }

            foreach (var product in order.Products)
            {
                product.InitialPrice = product.UnitPrice;
                totalToPay += (product.Quantity * product.UnitPrice);
            }

            order.TotalToPay = totalToPay;            
        }

        private void CalculateAndSetOrderEnergeticValues(Order order)
        {
            foreach (var dish in order.Dishes)
            {
                List<float> energeticValues = new List<float>();
                energeticValues.Add(dish.EnergeticValue);

                foreach (var supplement in dish.Supplements)
                {
                    if (supplement.IsSelected == true)
                        energeticValues.Add(supplement.EnergeticValue);
                }

                foreach (var ingredient in dish.Ingredients)
                {
                    var OrderishIngredient = ingredient;
                    var ingredientDtails = ingredient.OrderIngredient;
                    if(ingredientDtails.EnergeticValue.Amount == 0)
                    {
                        energeticValues.Add(0);
                    }
                    else if (OrderishIngredient.MeasurementUnits == ingredientDtails.EnergeticValue.MeasurementUnit)
                    {
                        energeticValues.Add(((OrderishIngredient.Amount * ingredientDtails.EnergeticValue.Energy) / ingredientDtails.EnergeticValue.Amount));
                    }
                    else
                    {
                        switch (OrderishIngredient.MeasurementUnits)
                        {
                            case MeasurementUnits.Gramme:
                                energeticValues.Add(((OrderishIngredient.Amount * (ingredientDtails.EnergeticValue.Energy / 1000)) / ingredientDtails.EnergeticValue.Amount));

                                break;
                            case MeasurementUnits.KiloGramme:
                                energeticValues.Add(((OrderishIngredient.Amount * (ingredientDtails.EnergeticValue.Energy * 1000)) / ingredientDtails.EnergeticValue.Amount));
                                break;
                            case MeasurementUnits.MilliLiter:
                                energeticValues.Add(((OrderishIngredient.Amount * (ingredientDtails.EnergeticValue.Energy / 1000)) / ingredientDtails.EnergeticValue.Amount));

                                break;
                            case MeasurementUnits.Liter:
                                energeticValues.Add(((OrderishIngredient.Amount * (ingredientDtails.EnergeticValue.Energy * 1000)) / ingredientDtails.EnergeticValue.Amount));
                                break;
                        }
                    }
                }

                dish.EnergeticValue = energeticValues.Sum(x => x);
            }
        }

        private void ChangeStatusForOccupiedTablesOnlyIfOrderTypeIsDineIn(Order order, string action)
        {
            if (order.Type != OrderTypes.DineIn)
                return;

            foreach(var occupiedTable in order.OccupiedTables)
            {
                var table = _context.Tables.AsNoTracking().FirstOrDefault(t => t.TableId == Guid.Parse(occupiedTable.TableId));
                if (table == null)
                    throw new NotFoundException(nameof(Tables), occupiedTable.TableId);

                if(table.TableState == TableState.Occupied && action == CreateAction)
                    throw new ConflictException($"The table numbered with '{table.TableNumber.ToString().PadLeft(3,'0')}' already occupied");

                if (table.TableState == TableState.Archived)
                    throw new ConflictException($"The table numbered with '{table.TableNumber.ToString().PadLeft(3, '0')}' can not be used because it is archived");

                table.TableState = TableState.Occupied;
                _context.Tables.Update(table);
            }
        }

        private void ChangeStatusForReleasedTablesOnlyIfOrderTypeIsDineIn(List<string> releasedTables)
        {           
            foreach (var tableId in releasedTables)
            {
                var table = _context.Tables.AsNoTracking().FirstOrDefault(t => t.TableId == Guid.Parse(tableId));
                if (table == null)
                    throw new NotFoundException(nameof(Tables), tableId);
              
                table.TableState = TableState.Available;
                _context.Tables.Update(table);
            }
        }

        private List<string> GetReleasedTables(Order order, UpdateOrderCommand request)
        {
            if (order.Type != OrderTypes.DineIn)
                return new List<string>();

            List<string> releasedTables = new List<string>();
            foreach(var orderOccupiedTable in order.OccupiedTables)
            {
               var result = request.OccupiedTables.Find(x => x.TableId == orderOccupiedTable.TableId);
                if (result == null)
                    releasedTables.Add(orderOccupiedTable.TableId);
            }
            return releasedTables;
        }

        public TimeZoneInfo GetAlgeriaTimeZone()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return TimeZoneInfo.FindSystemTimeZoneById("W. Central Africa Standard Time");
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return TimeZoneInfo.FindSystemTimeZoneById("Africa/Algiers");
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                throw new NotImplementedException("I don't know how to do a lookup for time zone on a Mac.");
            }
            return default;
        }
    }
}