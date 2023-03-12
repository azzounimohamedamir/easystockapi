using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Bcpg;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.BillDtos;
using SmartRestaurant.Application.Common.Dtos.OrdersDtos;
using SmartRestaurant.Application.Common.Enums;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Application.CurrencyExchange;
using SmartRestaurant.Domain.Common.Enums;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.Identity.Entities;
using SmartRestaurant.Domain.Identity.Enums;
using SmartRestaurant.Domain.ValueObjects;

namespace SmartRestaurant.Application.Orders.Commands
{
    public class OrdersCommandsHandlers :
        IRequestHandler<CreateOrderCommand, OrderDto>,
        IRequestHandler<CreateOrderSHCommand, HotelOrder>,
        IRequestHandler<UpdateOrderCommand, NoContent>,
        IRequestHandler<UpdateOrderStatusCommand, NoContent>,
        IRequestHandler<AcceptOrderSHCommand, NoContent>,
        IRequestHandler<UpdateOrderSHStatusCommand, NoContent>,
        IRequestHandler<AddSeatOrderToTableOrderCommand, NoContent>,
        IRequestHandler<UpdateOrderGeoLocalisationCommand, Order>

    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IDateTime _datetime;
        private readonly IIdentityContext _identityContext;

        private readonly IUserService _userService;
        private readonly IFirebaseRepository _fireBase;
        private readonly string CreateAction = "CreateAction";
        private readonly string UpdateAction = "UpdateAction";

        public OrdersCommandsHandlers(IApplicationDbContext context,
                                    IIdentityContext identityContext,
                                    IMapper mapper,
                                    IUserService userService,
                                    IFirebaseRepository fireBase,
                                    IDateTime datetime)
        {
            _context = context;
            _mapper = mapper;
            _identityContext = identityContext;
            _userService = userService;
            _fireBase = fireBase;
            _datetime = datetime;
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
                    var newOrder = await ExecuteOrderOperations<CreateOrderCommand>(request, cancellationToken, foodBusiness);

                    newOrder.ErrorDeliveryTimeAvailabilite = ErrorResult.None;
                    return newOrder;
                }
            }
            else
            {
                var newOrder = await ExecuteOrderOperations<CreateOrderCommand>(request, cancellationToken, foodBusiness);

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
                p.Description = orderProduct.Description;
                p.Name = orderProduct.Name;
                p.EnergeticValue = orderProduct.EnergeticValue;
                p.UnitPrice = orderProduct.Price;
                p.InitialPrice = orderProduct.Price;
                return p;
            }).ToList();
            return order;
        }

        public async Task<Domain.Entities.CheckIn> GetCheckinInfo(string UserId, string CeckinId, CancellationToken cancellation)
        {

            var checkin = await _context.CheckIns
            .FirstOrDefaultAsync(u => u.ClientId == UserId && u.Id == Guid.Parse(CeckinId) && u.IsActivate == true, cancellation)
            .ConfigureAwait(false);

            if (checkin == null)
            {
                return null;
            }
            else
            {
                return checkin;
            }
        }
        public async Task<HotelOrder> Handle(CreateOrderSHCommand request, CancellationToken cancellationToken)
        {
            string user = ChecksHelper.GetUserIdFromToken_ThrowExceptionIfUserIdIsNullOrEmpty(_userService);
            CheckIn clientCheckin = await GetCheckinInfo(user, request.CheckinId , cancellationToken);
            if(clientCheckin != null)
            {
                var validator = new CreateOrderSHCommandValidator();
                var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
                if (!result.IsValid) throw new ValidationException(result);

              

                var service = await _context.HotelServices.FindAsync(Guid.Parse(request.ServiceId));


                if (service == null)
                    throw new NotFoundException(nameof(HotelServices), request.ServiceId);

                if(service.isSmartrestaurantMenue == true && request.Type==OrderTypes.DineIn)
                {
                    var foodBusiness = await _context.FoodBusinesses.FindAsync(Guid.Parse(request.FoodBusinessId));
                    if (foodBusiness == null)
                        throw new NotFoundException(nameof(FoodBusiness), request.FoodBusinessId);
                    var newOrder = await ExecuteOrderOperations<CreateOrderSHCommand>(request, cancellationToken, foodBusiness);

                    HotelOrder orderSH = new HotelOrder()
                    {
                        UserId = Guid.Parse(clientCheckin.ClientId),
                        CheckinId = Guid.Parse(request.CheckinId),
                        SmartRestaurentOrderId = Guid.Parse(newOrder.OrderId),
                        Names = service.Names,
                        HotelId= clientCheckin.hotelId,
                        RoomId=clientCheckin.RoomId ,
                        DateOrder = newOrder.CreatedAt,
                        ParametreValueClient=null,
                        ChairNumber = newOrder.Dishes[0].ChairNumber,
                        TableId = Guid.Parse(newOrder.OccupiedTables[0].TableId),
                        FailureMessage = service.TitelFailureResponce,
                        SuccesMessage = service.TitelSeccesResponce,
                        FoodBusinessId = service.FoodBusinessID,
                        IsSmartrestaurantMenue = service.isSmartrestaurantMenue,
                        OrderStat = SHOrderStat.IsNew,
                        ServiceManagerName = null,
                        Type = OrderTypes.DineIn
                    };
                    _context.HotelOrders.Add(orderSH);
                    await _context.SaveChangesAsync(cancellationToken);

                    return orderSH;
                }

                if (service.isSmartrestaurantMenue == true && request.Type==OrderTypes.InRoom)
                {
                    var foodBusiness = await _context.FoodBusinesses.FindAsync(Guid.Parse(request.FoodBusinessId));
                    if (foodBusiness == null)
                        throw new NotFoundException(nameof(FoodBusiness), request.FoodBusinessId);
                    var newOrder = await ExecuteOrderOperations<CreateOrderSHCommand>(request, cancellationToken, foodBusiness);

                    HotelOrder orderSH = new HotelOrder()
                    {
                        UserId = Guid.Parse(clientCheckin.ClientId),
                        CheckinId = Guid.Parse(request.CheckinId),
                        SmartRestaurentOrderId = Guid.Parse(newOrder.OrderId),
                        Names = service.Names,
                        HotelId = clientCheckin.hotelId,
                        RoomId = clientCheckin.RoomId,
                        DateOrder = newOrder.CreatedAt,
                        ParametreValueClient = null,
                        ChairNumber = 0,
                        TableId = Guid.Empty,
                        FailureMessage = service.TitelFailureResponce,
                        SuccesMessage = service.TitelSeccesResponce,
                        FoodBusinessId = service.FoodBusinessID,
                        IsSmartrestaurantMenue = service.isSmartrestaurantMenue,
                        OrderStat = SHOrderStat.IsNew,
                        ServiceManagerName = null,
                        Type = OrderTypes.InRoom
                    };
                    _context.HotelOrders.Add(orderSH);
                    await _context.SaveChangesAsync(cancellationToken);

                    return orderSH;
                }
                if(service.isSmartrestaurantMenue == false)
                {
                    HotelOrder orderSH = new HotelOrder()
                    {
                        UserId = Guid.Parse(clientCheckin.ClientId),
                        CheckinId = Guid.Parse(request.CheckinId),
                        SmartRestaurentOrderId = Guid.Empty,
                        Names = service.Names,
                        HotelId = clientCheckin.hotelId,
                        RoomId = clientCheckin.RoomId,
                        DateOrder = DateTime.Now,
                        ChairNumber = 0,
                        TableId = Guid.Empty,
                        ParametreValueClient=request.ParametreValueClient,
                        FailureMessage = service.TitelFailureResponce,
                        SuccesMessage = service.TitelSeccesResponce,
                        FoodBusinessId = Guid.Empty,
                        IsSmartrestaurantMenue = service.isSmartrestaurantMenue,
                        OrderStat = SHOrderStat.IsNew,
                        ServiceManagerName = null,
                        Type = 0
                    };
                    _context.HotelOrders.Add(orderSH);
                    await _context.SaveChangesAsync(cancellationToken);

                    return orderSH;
                }

            }
            else
            {
                throw new NotFoundException(nameof(clientCheckin), clientCheckin);
            }
            return default;

        }




            public async Task<OrderDto> ExecuteOrderOperations<T>(T request, CancellationToken cancellationToken, Domain.Entities.FoodBusiness foodBusiness)
        {

            Order order = null;
            if (request.GetType() == typeof(CreateOrderSHCommand))
            {
                var newrequest = (request as CreateOrderSHCommand);
                if (newrequest.FoodBusinessClientId != null)
                {
                    var foodBusinessClient = await _context.FoodBusinessClients.FindAsync(Guid.Parse(newrequest.FoodBusinessClientId));
                    if (foodBusinessClient == null)
                        throw new NotFoundException(nameof(FoodBusinessClient), newrequest.FoodBusinessClientId);
                }

                order = _mapper.Map<Order>(newrequest);
            }
            else
            {
                var newrequest = (request as CreateOrderCommand);
                if (newrequest.FoodBusinessClientId != null)
                {
                    var foodBusinessClient = await _context.FoodBusinessClients.FindAsync(Guid.Parse(newrequest.FoodBusinessClientId));
                    if (foodBusinessClient == null)
                        throw new NotFoundException(nameof(FoodBusinessClient), newrequest.FoodBusinessClientId);
                }

                order = _mapper.Map<Order>(newrequest);
            }

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
            var path = foodBusiness.FoodBusinessId + "/Orders/" + orderDto.OrderId;
            await _fireBase.AddAsync(path, orderDto, cancellationToken);

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
            .FirstOrDefaultAsync(o => o.OrderId == order.OrderId, cancellationToken)
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
           await  UpdateDishesAndProductQuantityOnCreateOrder(order); //  new order increase quantity
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var orderDto = _mapper.Map<OrderDto>(order);
            var foodBusiness = await _context.FoodBusinesses.FindAsync(order.FoodBusinessId);
            if (foodBusiness != null)
                orderDto.CurrencyExchange = CurrencyConverter.GetDefaultCurrencyExchangeList(orderDto.TotalToPay, foodBusiness.DefaultCurrency);
            var path = order.FoodBusinessId + "/Orders/" + order.OrderId;
            await _fireBase.UpdateAsync(path, orderDto, cancellationToken);
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

             if (order.Status == OrderStatuses.Cancelled){

            await UpdateDishesAndProductQuantityOnRemoveOrder(order);
            }

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

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


        public async Task<NoContent> Handle(UpdateOrderSHStatusCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateOrderSHStatusCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var hotelOrder = await _context.HotelOrders.FirstOrDefaultAsync(o => o.Id == Guid.Parse(request.Id), cancellationToken)
                .ConfigureAwait(false);
            if (hotelOrder == null)
                throw new NotFoundException(nameof(HotelOrder), request.Id);
            if(hotelOrder.IsSmartrestaurantMenue)
            {
                var orderentity = await _context.Orders
               .Include(o => o.Dishes)
               .ThenInclude(o => o.Specifications)
               .ThenInclude(o => o.ComboBoxContentTranslation)
               .Include(o => o.Dishes)
               .ThenInclude(o => o.Ingredients)
               .Include(o => o.Dishes)
               .ThenInclude(o => o.Supplements)
               .Include(o => o.Products)
               .Include(o => o.OccupiedTables)
               .FirstOrDefaultAsync(o => o.OrderId == hotelOrder.SmartRestaurentOrderId, cancellationToken)
               .ConfigureAwait(false);

                if (orderentity != null)
                {
                    orderentity.Status = OrderStatuses.Cancelled;
                    await UpdateDishesAndProductQuantityOnRemoveOrder(orderentity);
                    _context.Orders.Update(orderentity);
                    hotelOrder.OrderStat = SHOrderStat.DeniedByClient;
                    _context.HotelOrders.Update(hotelOrder);
                    await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    throw new NotFoundException(nameof(Order), orderentity.OrderId);
                }
            }
            else
            {
                hotelOrder.OrderStat = SHOrderStat.DeniedByClient;
                _context.HotelOrders.Update(hotelOrder);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
           
            return default;
        }



        public async Task<NoContent> Handle(AcceptOrderSHCommand request, CancellationToken cancellationToken)
        {
            var validator = new AcceptOrderSHCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var hotelOrder = await _context.HotelOrders.FirstOrDefaultAsync(o => o.Id == Guid.Parse(request.Id), cancellationToken)
                .ConfigureAwait(false);
            if (hotelOrder == null)
                throw new NotFoundException(nameof(HotelOrder), request.Id);
            if (hotelOrder.IsSmartrestaurantMenue)
            {
                var orderentity = await _context.Orders
               .Include(o => o.Dishes)
               .ThenInclude(o => o.Specifications)
               .ThenInclude(o => o.ComboBoxContentTranslation)
               .Include(o => o.Dishes)
               .ThenInclude(o => o.Ingredients)
               .Include(o => o.Dishes)
               .ThenInclude(o => o.Supplements)
               .Include(o => o.Products)
               .Include(o => o.OccupiedTables)
               .FirstOrDefaultAsync(o => o.OrderId == hotelOrder.SmartRestaurentOrderId, cancellationToken)
               .ConfigureAwait(false);

                if (orderentity != null)
                {
                    orderentity.Status = OrderStatuses.InProgress;
                    await UpdateDishesAndProductQuantityOnRemoveOrder(orderentity);
                    _context.Orders.Update(orderentity);
                    hotelOrder.OrderStat = SHOrderStat.ResponseSucces;
                    _context.HotelOrders.Update(hotelOrder);
                    await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    throw new NotFoundException(nameof(Order), orderentity.OrderId);
                }
            }
            else
            {
                hotelOrder.OrderStat = SHOrderStat.ResponseSucces;
                _context.HotelOrders.Update(hotelOrder);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }

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
                        throw new ConflictException("Sorry, you can not take this quantity : "+product.Quantity+ " , issue quantity. ");
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
            if(products.Count()>0)
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



    }
}