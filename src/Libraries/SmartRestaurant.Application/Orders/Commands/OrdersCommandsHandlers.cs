using System;
using System.Collections.Generic;
using System.Linq;
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
        IRequestHandler<UpdateOrderCommand, NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly string _algeriaZoneId = "W. Central Africa Standard Time";

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

            var order = _mapper.Map<Order>(request);
            order.CreatedBy = ChecksHelper.GetUserIdFromToken_ThrowExceptionIfUserIdIsNullOrEmpty(_userService);
            order.CreatedAt = DateTime.Now;

            ChangeStatusForOccupiedTablesOnlyIfOrderTypeIsDineIn(order, TableState.Occupied);
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
            return default;
        }


        private void CalculateAndSetOrderNumber(Order order, Domain.Entities.FoodBusiness foodBusiness)
        {
            var maxOrderNumber = 0;
            TimeZoneInfo algeriaZone = TimeZoneInfo.FindSystemTimeZoneById(_algeriaZoneId);

            DateTime utcNow = DateTime.UtcNow;
            DateTime algeriaTimeNow = TimeZoneInfo.ConvertTimeFromUtc(utcNow, algeriaZone);

            DateTime orderNumberLastResetDateTimeInUtc = TimeZoneInfo.ConvertTimeToUtc(foodBusiness.OrderNumberLastResetDateTime);
            DateTime orderNumberLastResetDateTimeInAlgeriaTime = TimeZoneInfo.ConvertTimeFromUtc(orderNumberLastResetDateTimeInUtc, algeriaZone);

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
                float totalDishPrice = dish.UnitPrice;

                foreach (var supplement in dish.Supplements)
                {
                    if(supplement.IsSelected == true)
                        totalDishPrice += supplement.Price;
                }

                foreach (var ingredient in dish.Ingredients)
                {
                    totalDishPrice += (ingredient.Steps * ingredient.PriceIncreasePerStep);
                }

                totalToPay += (dish.Quantity * totalDishPrice);
            }

            foreach (var product in order.Products)
            {
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

        private void ChangeStatusForOccupiedTablesOnlyIfOrderTypeIsDineIn(Order order, TableState newState)
        {
            if (order.Type != OrderTypes.DineIn)
                return;

            foreach(var occupiedTable in order.OccupiedTables)
            {
                var table = _context.Tables.AsNoTracking().FirstOrDefault(t => t.TableId == Guid.Parse(occupiedTable.TableId));
                if (table == null)
                    throw new NotFoundException(nameof(Tables), occupiedTable.TableId);

                if(table.TableState == TableState.Occupied)
                    throw new ConflictException($"The table numbered with '{table.TableNumber.ToString().PadLeft(3,'0')}' already occupied");

                table.TableState = newState;
                _context.Tables.Update(table);
            }
        }
    }
}