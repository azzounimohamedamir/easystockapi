using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.BillDtos;
using SmartRestaurant.Application.Common.Dtos.OrdersDtos;
using SmartRestaurant.Application.Common.Enums;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Application.CurrencyExchange;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.Identity.Entities;
using SmartRestaurant.Domain.ValueObjects;

namespace SmartRestaurant.Application.Orders.Commands
{
    public class OrdersCommandsHandlers : IRequestHandler<CreateOrderCommand, OrderDto>,
        IRequestHandler<UpdateOrderCommand, NoContent>,
        IRequestHandler<UpdateOrderStatusCommand, NoContent>,
        IRequestHandler<AddSeatOrderToTableOrderCommand, NoContent>,
        IRequestHandler<UpdateOrderGeoLocalisationCommand, Order>

    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IDateTime _datetime;

        private readonly IUserService _userService;
        private readonly IFirebaseRepository _fireBase;
        private readonly string CreateAction = "CreateAction";
        private readonly string UpdateAction = "UpdateAction";
        private readonly ISaleOrderRepository _saleOrderRepository;

        public OrdersCommandsHandlers(IApplicationDbContext context,

                                    IMapper mapper,
                                    IUserService userService,
                                    IFirebaseRepository fireBase,
                                    IDateTime datetime, ISaleOrderRepository saleOrderRepository)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
            _fireBase = fireBase;
            _datetime = datetime;
            _saleOrderRepository = saleOrderRepository;

        }

        public async Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateOrderCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var foodBusiness = await _context.FoodBusinesses.FindAsync(Guid.Parse(request.FoodBusinessId));
            if (foodBusiness == null)
                throw new NotFoundException(nameof(FoodBusiness), request.FoodBusinessId);

            if (request.Type == OrderTypes.Delivery)
            {
                var isOutdeliveryTime = DateTimeHelpers.CheckAvailabiliteOfOrderDeliveryInCurrentTime(foodBusiness.OpeningTime, foodBusiness.ClosingTime, _datetime);
                if (isOutdeliveryTime == ErrorResult.OutOfDeliveryTime)
                {
                    var newOrder = new OrderDto();

                    newOrder.ErrorDeliveryTimeAvailabilite = ErrorResult.OutOfDeliveryTime;
                    return newOrder;
                }
                else
                {
                    var newOrder = await ExecuteOrderOperations(request, cancellationToken, foodBusiness);
                    newOrder.ErrorDeliveryTimeAvailabilite = ErrorResult.None;
                    await addOrderNotifications(newOrder.OrderId.ToString(), newOrder.FoodBusinessId.ToString(), OrderNotificationType.Create, cancellationToken);

                    
                    return newOrder;
                }
            }
            else
            {
                var newOrder = await ExecuteOrderOperations(request, cancellationToken, foodBusiness);
                await addOrderNotifications(newOrder.OrderId.ToString(), newOrder.FoodBusinessId.ToString(), OrderNotificationType.Create, cancellationToken);



                return newOrder;
            }

        }

        private Order PopulatFromLocalDishesAndProducts(Order order)
        {
            order.Dishes = order.Dishes.Select((OrderDish od) =>
            {
                var orderDish = _context.Dishes.
                FirstOrDefault(d => d.DishId.Equals(Guid.Parse(od.DishId)));
                if (orderDish == null)
                    throw new NotFoundException("Dish", od.DishId);
                od.Names = new Names()
                {
                    AR = orderDish.Names.AR,
                    EN = orderDish.Names.EN,
                    FR = orderDish.Names.FR,
                    TR = orderDish.Names.TR,
                    RU = orderDish.Names.RU,
                }; ;
                od.Description = orderDish.Description;
                od.Name = orderDish.Name;
                od.EstimatedPreparationTime = orderDish.EstimatedPreparationTime;
                od.InitialPrice = orderDish.Price;
                od.OdooId = orderDish.OdooId;
                od.Supplements = od.Supplements.Select((supplement) =>
                {
                    var supp = _context.Dishes.FirstOrDefault(d => d.DishId.Equals(Guid.Parse(supplement.SupplementId)));
                    supplement.Name = supp.Name;
                    supplement.Names = new Names()
                    {
                        AR = supp.Names.AR,
                        EN = supp.Names.EN,
                        FR = supp.Names.FR,
                        TR = supp.Names.TR,
                        RU = supp.Names.RU,
                    };
                    supplement.Description = supp.Description;
                    supplement.Price = supp.Price;
                    supplement.EnergeticValue = supp.EnergeticValue;
                    return supplement;
                }).ToList();
                return od;
            }).ToList();
            order.Products = order.Products.Select((OrderProduct p) =>
            {
                var orderProduct = _context.Products.FirstOrDefault(d => d.ProductId.Equals(Guid.Parse(p.ProductId)));
                if (orderProduct == null)
                    throw new NotFoundException("Products", p.ProductId);
                p.Names = new Names()
                {
                    AR = orderProduct.Names.AR,
                    EN = orderProduct.Names.EN,
                    FR = orderProduct.Names.FR,
                    TR = orderProduct.Names.TR,
                    RU = orderProduct.Names.RU,
                };
                p.OdooId = orderProduct.OdooId;
                p.Description = orderProduct.Description;
                p.Name = orderProduct.Name;
                p.EnergeticValue = orderProduct.EnergeticValue;
                p.UnitPrice = orderProduct.Price;
                p.InitialPrice = orderProduct.Price;
                return p;
            }).ToList();
            return order;
        }

        public async Task<OrderDto> ExecuteOrderOperations(CreateOrderCommand request, CancellationToken cancellationToken, Domain.Entities.FoodBusiness foodBusiness)
        {
            if (request.FoodBusinessClientId != null)
            {
                var foodBusinessClient = await _context.FoodBusinessClients.FindAsync(Guid.Parse(request.FoodBusinessClientId));
                if (foodBusinessClient == null)
                    throw new NotFoundException(nameof(FoodBusinessClient), request.FoodBusinessClientId);
            }

            var order = _mapper.Map<Order>(request);
            order = PopulatFromLocalDishesAndProducts(order);
            await UpdateDishesAndProductQuantityOnCreateOrder(order);// gestion de stock



            order.CreatedBy = ChecksHelper.GetUserIdFromToken_ThrowExceptionIfUserIdIsNullOrEmpty(_userService);
            order.CreatedAt = DateTime.Now;

            ChangeStatusForOccupiedTablesOnlyIfOrderTypeIsDineIn(order, CreateAction);
            CalculateAndSetOrderEnergeticValues(order);
            CalculateAndSetOrderTotalPrice(order, foodBusiness);
            CalculateAndSetOrderNumber(order, foodBusiness);
            _context.Orders.Add(order);
            await _context.SaveChangesAsync(cancellationToken);

            var orderDto = _mapper.Map<OrderDto>(order);
            orderDto.CurrencyExchange = CurrencyConverter.GetDefaultCurrencyExchangeList(orderDto.TotalToPay, foodBusiness.DefaultCurrency);
            var path = request.FoodBusinessId + "/Orders/" + orderDto.OrderId;
            await _fireBase.AddAsync(path, orderDto, cancellationToken);
            await CreateOrderInOdoo(order);// create order odoo

            var newOrder = await _context.Orders.AsNoTracking()
            .Include(o => o.Dishes)
            .ThenInclude(o => o.Specifications)
            .ThenInclude(o => o.ComboBoxContentTranslation)
            .Include(o => o.Dishes)
            .ThenInclude(o => o.Ingredients)
            .Include(o => o.Dishes)
            .ThenInclude(o => o.Supplements)
            .Include(o => o.Products)
            .Include(o => o.OccupiedTables)
            .Include(o => o.FoodBusiness)
            .Include(o => o.FoodBusinessClient)
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.OrderId == request.Id, cancellationToken)
            .ConfigureAwait(false);
            return _mapper.Map<OrderDto>(newOrder);
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
                .ThenInclude(o => o.ComboBoxContentTranslation)
                .Include(o => o.Dishes)
                .ThenInclude(o => o.Ingredients)
                .Include(o => o.Dishes)
                .ThenInclude(o => o.Supplements)
                .Include(o => o.Products)
                .Include(o => o.OccupiedTables)
                .Include(o => o.FoodBusiness)
                .FirstOrDefaultAsync(o => o.OrderId == Guid.Parse(request.Id), cancellationToken)
                .ConfigureAwait(false);
            await UpdateDishesAndProductQuantityOnRemoveOrder(order);//  old order decrease the quantity

            if (order == null)
                throw new NotFoundException(nameof(Order), request.Id);

            if (order.Status == OrderStatuses.Billed)
                throw new ConflictException("Sorry, you can not update a Billed Order");

            var releasedTables = GetReleasedTables(order, request);

            _mapper.Map(request, order);
            order = PopulatFromLocalDishesAndProducts(order);
            order.LastModifiedBy = ChecksHelper.GetUserIdFromToken_ThrowExceptionIfUserIdIsNullOrEmpty(_userService);
            order.LastModifiedAt = DateTime.Now;

           
            
            

            ChangeStatusForReleasedTablesOnlyIfOrderTypeIsDineIn(releasedTables);
            ChangeStatusForOccupiedTablesOnlyIfOrderTypeIsDineIn(order, UpdateAction);
            CalculateAndSetOrderEnergeticValues(order);
            CalculateAndSetOrderTotalPrice(order, order.FoodBusiness);
            _context.Orders.Update(order);
            await UpdateDishesAndProductQuantityOnCreateOrder(order); //  new order increase quantity
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var orderDto = _mapper.Map<OrderDto>(order);
            var foodBusiness = await _context.FoodBusinesses.FindAsync(order.FoodBusinessId);
            if (foodBusiness != null)
                orderDto.CurrencyExchange = CurrencyConverter.GetDefaultCurrencyExchangeList(orderDto.TotalToPay, foodBusiness.DefaultCurrency);
            await addOrderNotifications(order.OrderId.ToString(), order.FoodBusinessId.ToString(), OrderNotificationType.Update, cancellationToken);
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
                .ThenInclude(o => o.ComboBoxContentTranslation)
                .Include(o => o.Dishes)
                .ThenInclude(o => o.Ingredients)
                .Include(o => o.Dishes)
                .ThenInclude(o => o.Supplements)
                .Include(o => o.Products)
                .Include(o => o.OccupiedTables)
                 .Include(o => o.FoodBusiness)
                .FirstOrDefaultAsync(o => o.OrderId == Guid.Parse(request.Id), cancellationToken)
                .ConfigureAwait(false);
            if (order == null)
                throw new NotFoundException(nameof(Order), request.Id);

            if (order.Status == OrderStatuses.Billed)
                throw new ConflictException("Sorry, you can not change the status for a Billed Order");




            _mapper.Map(request, order);
            order.LastModifiedBy = ChecksHelper.GetUserIdFromToken_ThrowExceptionIfUserIdIsNullOrEmpty(_userService);
            order.LastModifiedAt = DateTime.Now;


            var releasedTables = order.OccupiedTables.Select(x => x.TableId).ToList();
            ChangeStatusForReleasedTablesOnlyIfOrderTypeIsDineIn(releasedTables);

            _context.Orders.Update(order);

            if (order.Status == OrderStatuses.Cancelled)
            {
                await addOrderNotifications(order.OrderId.ToString(), order.FoodBusinessId.ToString(), OrderNotificationType.Cancel, cancellationToken);
                await UpdateDishesAndProductQuantityOnRemoveOrder(order);
                await _saleOrderRepository.Authenticate(order.FoodBusiness.Odoo);// auth in odoo
                await UpdateOrderInOdoo(order.OrderId.ToString(),"cancel");
            }


            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            //if (order.Status == OrderStatuses.InProgress)
            //{
            //    await CreateOrderInOdoo(order);// create order odoo
            //}

            return default;
        }





        public async Task<Order> Handle(UpdateOrderGeoLocalisationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateOrderGeoLocalisationCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var order = await _context.Orders
                .Include(o => o.Dishes)
                .ThenInclude(o => o.Specifications)
                .ThenInclude(o => o.ComboBoxContentTranslation)
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


            if (order.Type != OrderTypes.Delivery)
                throw new ConflictException("Sorry,This order type not delivery");


            _mapper.Map(request, order);
            order.LastModifiedBy = ChecksHelper.GetUserIdFromToken_ThrowExceptionIfUserIdIsNullOrEmpty(_userService);
            order.LastModifiedAt = DateTime.Now;
            order.GeoPosition.Latitude = request.GeoPosition.Latitude;
            order.GeoPosition.Longitude = request.GeoPosition.Longitude;
            _context.Orders.Update(order);



            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return order;
        }






        public async Task<NoContent> Handle(AddSeatOrderToTableOrderCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddSeatOrderToTableOrderCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            Order order = await GetOrderForUpdate(request.Id, cancellationToken).ConfigureAwait(false);
            RemoveOldOrderOfChair(request, order);
            AddNewOrderOfChair(request, order);
            SetTableIsOccupedIfIsNew(request, order);
            await UpdateOrder(order, cancellationToken).ConfigureAwait(false);
            return default;
        }

        private void SetTableIsOccupedIfIsNew(AddSeatOrderToTableOrderCommand request, Order order)
        {
            var currentOrderTables = order.OccupiedTables.Select(x => x.TableId).ToList();
            if (!currentOrderTables.Contains(request.TableId))
            {
                var occuppedTable = new OrderOccupiedTable() { TableId = request.TableId };
                order.OccupiedTables.Add(occuppedTable);
                SetTabelOccuped(UpdateAction, occuppedTable);
            }
        }

        private void RemoveOldOrderOfChair(AddSeatOrderToTableOrderCommand request, Order order)
        {
            order.Dishes.RemoveAll(x => x.TableId == request.TableId &&
            x.ChairNumber == request.ChairNumber);
            order.Products.RemoveAll(x => x.TableId == request.TableId &&
            x.ChairNumber == request.ChairNumber);
        }
        private void AddNewOrderOfChair(AddSeatOrderToTableOrderCommand request, Order order)
        {
            Order NewOrder = new Order();
            _mapper.Map(request, NewOrder);
            NewOrder = PopulatFromLocalDishesAndProducts(NewOrder);
            order.Products.AddRange(NewOrder.Products);
            order.Dishes.AddRange(NewOrder.Dishes);
        }

        private async Task<Order> GetOrderForUpdate(string id, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
              .Include(o => o.Dishes)
              .ThenInclude(o => o.Specifications)
              .ThenInclude(o => o.ComboBoxContentTranslation)
              .Include(o => o.Dishes)
              .ThenInclude(o => o.Ingredients)
              .Include(o => o.Dishes)
              .ThenInclude(o => o.Supplements)
              .Include(o => o.Products)
              .Include(o => o.OccupiedTables)
              .Include(o => o.FoodBusiness)
              .FirstOrDefaultAsync(o => o.OrderId == Guid.Parse(id), cancellationToken)
              .ConfigureAwait(false);
            if (order == null)
                throw new NotFoundException(nameof(Order), id);

            if (order.Status == OrderStatuses.Billed)
                throw new ConflictException("Sorry, you can not update a Billed Order");
            return order;
        }
        private async Task UpdateOrder(Order order, CancellationToken cancellationToken)
        {
            order.LastModifiedBy = ChecksHelper.GetUserIdFromToken_ThrowExceptionIfUserIdIsNullOrEmpty(_userService);
            order.LastModifiedAt = DateTime.Now;
            CalculateAndSetOrderEnergeticValues(order);
            CalculateAndSetOrderTotalPrice(order, order.FoodBusiness);
            _context.Orders.Update(order);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
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


        private void CalculateAndSetOrderTotalPrice(Order order, Domain.Entities.FoodBusiness foodBusiness)
        {
            order.CommissionConfigs = foodBusiness.CommissionConfigs == null ? new CommissionConfigs() : foodBusiness.CommissionConfigs;
            if (foodBusiness.CommissionConfigs == null || foodBusiness.CommissionConfigs.WhoPay == WhoPayCommission.FoodBusiness)
            {
                CalculateTotalPrice(order);
            }
            else
            {
                CalculateTotalPrice(order);
                AddCommissionValueToTotalPrice(order, foodBusiness);
            }
        }

        private void AddCommissionValueToTotalPrice(Order order, Domain.Entities.FoodBusiness foodBusiness)
        {
            if (order.Type == OrderTypes.DineIn && foodBusiness.CommissionConfigs.Type == CommissionType.PerPerson)
            {
                var personsCount = 0;
                var billDto = _mapper.Map<BillDto>(order);
                foreach (var table in billDto.Tables)
                {
                    personsCount += table.Chairs.Count;
                }
                order.TotalToPay += (foodBusiness.CommissionConfigs.Value * personsCount);
            }
            else
            {
                order.TotalToPay += foodBusiness.CommissionConfigs.Value;
            }
        }

        private void CalculateTotalPrice(Order order)
        {
            float totalToPay = 0;

            foreach (var dish in order.Dishes)
            {
                float totalDishPrice = dish.InitialPrice;

                foreach (var supplement in dish.Supplements)
                {
                    if (supplement.IsSelected == true)
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
            order.TotalToPayWithoutCommissionValue = totalToPay;

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
                    if (ingredientDtails.EnergeticValue.Amount == 0)
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

            foreach (var occupiedTable in order.OccupiedTables)
            {
                SetTabelOccuped(action, occupiedTable);
            }
        }

        private void SetTabelOccuped(string action, OrderOccupiedTable occupiedTable)
        {
            var table = _context.Tables.AsNoTracking().FirstOrDefault(t => t.TableId == Guid.Parse(occupiedTable.TableId));
            if (table == null)
                throw new NotFoundException(nameof(Tables), occupiedTable.TableId);



            if (table.TableState == TableState.Archived)
                throw new ConflictException($"The table numbered with '{table.TableNumber.ToString().PadLeft(3, '0')}' can not be used because it is archived");

            table.TableState = TableState.Occupied;
            _context.Tables.Update(table);
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
            foreach (var orderOccupiedTable in order.OccupiedTables)
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

        private async Task UpdateDishesAndProductQuantityOnCreateOrder(Order order)
        {
            var dishes = order.Dishes.GroupBy(d => d.DishId).Select(g => new
            {
                DishId = g.First().DishId,
                Count = g.Count(),
                Quantity = g.Sum(c => c.Quantity)

            }).ToList();

            // var dishes = order.Dishes;
            foreach (var dish in dishes)
            {

                // update dishes



                var dishUpdated = await _context.Dishes.FindAsync(Guid.Parse(dish.DishId));
                if (dishUpdated == null)
                    throw new NotFoundException(nameof(Dishes), dish.DishId);

                if (dishUpdated.IsQuantityChecked && dishUpdated.Quantity > 0)
                {
                    if ((dishUpdated.Quantity - (int)dish.Quantity) < 0)
                    {
                        throw new ConflictException("Sorry, you can not take this quantity : " + dish.Quantity + " , issue quantity. ");
                    }
                    else
                    {
                        dishUpdated.Quantity = dishUpdated.Quantity - ((int)dish.Quantity);

                        _context.Dishes.Update(dishUpdated);
                    }

                  
                }


            }


            // update products
            var products = order.Products.GroupBy(d => d.ProductId).Select(g => new
            {
                ProductId = g.First().ProductId,
                Count = g.Count(),
                Quantity = g.Sum(c => c.Quantity)

            }).ToList();
            foreach (var product in products)
            {

                var productUpdated = await _context.Products.FindAsync(Guid.Parse(product.ProductId));
                if (productUpdated == null)
                    throw new NotFoundException(nameof(Products), product.ProductId);


                if (productUpdated.IsQuantityChecked && productUpdated.Quantity > 0)
                {
                    if ((productUpdated.Quantity - (int)product.Quantity) < 0)
                    {
                        throw new ConflictException("Sorry, you can not take this quantity : " + product.Quantity + " , issue quantity. ");
                    }
                    else
                    {
                        productUpdated.Quantity = productUpdated.Quantity - ((int)product.Quantity);

                        _context.Products.Update(productUpdated);

                    }


                }

            }


        }


        private async Task UpdateDishesAndProductQuantityOnRemoveOrder(Order order)
        {
            var dishes = order.Dishes.GroupBy(d => d.DishId).Select(g => new
            {
                DishId = g.First().DishId,
                Count = g.Count(),
                Quantity = g.Sum(c => c.Quantity)

            }).ToList();

            // var dishes = order.Dishes;
            foreach (var dish in dishes)
            {

                // update dishes



                var dishUpdated = await _context.Dishes.FindAsync(Guid.Parse(dish.DishId));
                if (dishUpdated == null)
                    throw new NotFoundException(nameof(Dishes), dish.DishId);

                if (dishUpdated.IsQuantityChecked)
                {

                    dishUpdated.Quantity = dishUpdated.Quantity + ((int)dish.Quantity);

                    _context.Dishes.Update(dishUpdated);
                }


            }


            // update products
            var products = order.Products.GroupBy(d => d.ProductId).Select(g => new
            {
                ProductId = g.First().ProductId,
                Count = g.Count(),
                Quantity = g.Sum(c => c.Quantity)

            }).ToList();
            if (products.Count() > 0)
                foreach (var product in products)
                {

                    var productUpdated = await _context.Products.FindAsync(Guid.Parse(product.ProductId));
                    if (productUpdated == null)
                        throw new NotFoundException(nameof(Products), product.ProductId);


                    if (productUpdated.IsQuantityChecked)
                    {

                        productUpdated.Quantity = productUpdated.Quantity + ((int)product.Quantity);

                        _context.Products.Update(productUpdated);
                    }
                }
        }

        private async Task addOrderNotifications(string orderId, string foodBusinessId, OrderNotificationType type, CancellationToken cancellationToken)
        {
            var foodBusiness = await _context.FoodBusinesses.Where(u => u.FoodBusinessId == Guid.Parse(foodBusinessId))
                 .FirstOrDefaultAsync().ConfigureAwait(false);

            if (foodBusiness == null) throw new NotFoundException(nameof(foodBusiness), foodBusinessId);

            var orderNotificationDto = new OrderNotificationDto() { OrderId = orderId, Type = type, Read = null, CreatedAt = DateTime.Now, FoodBusinessId = foodBusinessId };

            var pathNotification = foodBusinessId + "/OrderNotifications";
            await _fireBase.AddCollectionAsync(pathNotification, orderNotificationDto, cancellationToken);

        }

        private async Task<long> getOpnedSessionInOdooId()
        {
            var result = await _saleOrderRepository.Search<List<int>>("pos.session", "state", "opened", 1);
            long Id;
            if (result.Count > 0)
            {
                Id = result[0];
            }
            else
            {
                var sessionData = new Dictionary<string, object>
                {

                    { "config_id",1},
                    {"state","opened"},
                    {"start_at",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}
                };
                Id = await _saleOrderRepository.CreateAsync("pos.session", sessionData);
            }

            return Id;
        }

        private async Task UpdateOrderInOdoo(String orderId, string state)
        {
            var result = await _saleOrderRepository.Search<List<int>>("pos.order", "name", orderId, 1);
            long Id;
            if (result.Count > 0)
            {
                Id = result[0];
                var data = new Dictionary<string, object>
            {
                { "state", state}

            };
          
                await _saleOrderRepository.UpdateAsync("pos.order", Id, data);
            }
            else
            {
                throw new ConflictException("Sorry,this order not exist in odoo for updated it");
            }

        }


        private async Task CreateOrderInOdoo(Order order)
        {
            await _saleOrderRepository.Authenticate(order.FoodBusiness.Odoo);// auth in odoo
            long sessionId = await getOpnedSessionInOdooId();// get opned session id




            var saleOrderDict = new Dictionary<string, object>
       {
               {"name", order.OrderId.ToString() },
               { "date_order", order.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")},
               {"session_id", sessionId},
               {"amount_total", order.TotalToPay},
               {"amount_tax", 0.0},
               {"amount_paid",order.TotalToPay},
               {"amount_return",0.0},
               {"pos_reference",order.OrderId.ToString()},

         };        // create order odoo

            var saleOrderId = await _saleOrderRepository.CreateAsync("pos.order", saleOrderDict);

            await CreateOdooOrderLines(order, saleOrderId);

        }

        private async Task CreateOdooOrderLines(Order order, long saleOrderId)
        {
            if (order.Dishes.Count > 0)
            {

                foreach (var dishLine in order.Dishes)
                {
                    var orderLineDict = new Dictionary<string, object>
            {
               { "order_id", saleOrderId },
               { "full_product_name",dishLine.Name},
               { "qty", dishLine.Quantity },
               { "price_unit", dishLine.UnitPrice },
               { "discount", 0.0 },
               {"product_id",dishLine.OdooId },
               { "price_subtotal", dishLine.UnitPrice*dishLine.Quantity },
               { "price_subtotal_incl", dishLine.UnitPrice*dishLine.Quantity }

            };
                    await _saleOrderRepository.CreateAsync("pos.order.line", orderLineDict);
                    // add dish in odoo order

                }


            }

            if (order.Products.Count > 0)
            {

                foreach (var productLine in order.Products)
                {
                    var orderLineDict = new Dictionary<string, object>
            {
               { "order_id", saleOrderId },
               { "full_product_name",productLine.Name },
               { "qty", productLine.Quantity },
               { "price_unit", productLine.UnitPrice } ,
               { "discount", 0.0 },
               { "price_subtotal", productLine.UnitPrice*productLine.Quantity },
                { "price_subtotal_incl",  productLine.UnitPrice*productLine.Quantity },
                {"product_id",productLine.OdooId }


            };
                    await _saleOrderRepository.CreateAsync("pos.order.line", orderLineDict); // add product in odoo order
                }


            }
        }




    }
}