using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
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
using Newtonsoft.Json.Linq;
using EllipticCurve.Utils;
using MailKit.Search;

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
		private readonly IOdooRepository _saleOrderRepository;

		public OrdersCommandsHandlers(IApplicationDbContext context,
									IIdentityContext identityContext,
									IMapper mapper,
									IUserService userService,
									IFirebaseRepository fireBase,
									IDateTime datetime ,
									IOdooRepository saleOrderRepository
		)
		{
			_context = context;
			_mapper = mapper;
			_identityContext = identityContext;
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
					var newOrder = await ExecuteOrderOperations<CreateOrderCommand>(request, cancellationToken, foodBusiness);

					newOrder.ErrorDeliveryTimeAvailabilite = ErrorResult.None;
					await addOrderNotifications(newOrder.OrderId.ToString(), newOrder.FoodBusinessId.ToString(), OrderNotificationType.Create, cancellationToken);
					return newOrder;
				}
			}
			else
			{
				var newOrder = await ExecuteOrderOperations<CreateOrderCommand>(request, cancellationToken, foodBusiness);
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
				}; 
				od.OdooId = orderDish.OdooId;
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
					float totalToPay = 0;
					if (!service.IsIncludeQuantity)
					{
						totalToPay = service.Price;

					}
					else
					{
						totalToPay = (float)request.Quantity * service.Price;

					}
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
						Type = 0,
						Quantity= request.Quantity,
						UnitePrice=service.Price,
						TotalToPay= totalToPay


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




		private async Task<long> CreateOdooClient(CheckIn checkIn, Hotel hotel)
		{
			await _saleOrderRepository.Authenticate(hotel.Odoo);


			long odooId=0;

			var result = await _saleOrderRepository.Search<List<int>>(
					"res.partner",
					"email",
					checkIn.Email,
					1
				);

		

		   if (result != null && result.Count > 0)
			{
				odooId = result[0];
			}
			else
			{

				var data = new Dictionary<string, object>
			{
				{ "name", checkIn.FullName},
				{ "phone", checkIn.PhoneNumber},

				{ "email",  checkIn.Email }

				};



				odooId = await _saleOrderRepository.CreateAsync("res.partner", data);
			}


			return odooId;
		}

		private async Task<long> CreateOdooProductOfTypeChekin(SmartRestaurant.Domain.Entities.Hotel hotel, HotelOrder hotelOrder)
		{
			var odooId = (long)0;
			if (hotel.Odoo != null)
			{
				var loggedIn = await _saleOrderRepository.Authenticate(hotel.Odoo);



				if (loggedIn)
				{

					var result = await _saleOrderRepository.Search<List<int>>(
							"product.template",
							"name",
						   "HS/" + hotelOrder.Names.EN.ToString()+"/"+ hotelOrder.CheckinId.ToString(),
							1
						);

					if (result != null && result.Count > 0)
					{
						odooId = result[0];
					}
					else
					{

						long categoryId = await getProductServiceId();
						var data = new Dictionary<string, object>
					{
						{ "name","HS/" + hotelOrder.Names.EN.ToString()+"/"+ hotelOrder.CheckinId.ToString()},
						{ "detailed_type", "service"},
						{ "pos_categ_id", categoryId},
						{ "available_in_pos", 1},
						{ "taxes_id",null }
					};


						odooId = await _saleOrderRepository.CreateAsync("product.template", data);
					}
				}
			}
			return odooId;
		}

		private async Task<long> getProductServiceId()
		{

			var result = await _saleOrderRepository.Search<List<int>>("pos.category", "name", "service", 1);
			long categoryId = 0;
			if (result != null && result.Count > 0)
			{
				categoryId = result[0];
			}
			else
			{
				var categoryData = new Dictionary<string, object>
				{
					{ "name", "service"}
				};
				categoryId = await _saleOrderRepository.CreateAsync("pos.category", categoryData);
			}

			return categoryId;
		}


		private async Task CreateOrderHotelServiceInOdoo(CheckIn checkIn, long clientId, HotelOrder order, long productId)
		{



			Dictionary<string, object> saleOrderDict = new Dictionary<string, object>
				{
					{ "name", "HS/"+checkIn.Id.ToString() },
					{ "partner_id", clientId }

				};

			var saleOrderId = await _saleOrderRepository.CreateAsync(
				"sale.order",
				saleOrderDict
			);
			var chekinOrder = new Dictionary<string, object>
					{
						{ "order_id", saleOrderId },

						{ "product_id", productId },
						{ "price_unit", order.UnitePrice },
						{ "product_uom_qty", order.Quantity>0 ? order.Quantity : 1 },
						 {"tax_id", null},


					};
			await _saleOrderRepository.CreateAsync("sale.order.line", chekinOrder);

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
			if (foodBusiness.Odoo != null)
			{
				await UpdateDishesAndProductQuantityOnCreateOrderWithOdoo(order, foodBusiness);// gestion de stock
			}
			else
			{
				await UpdateDishesAndProductQuantityOnCreateOrder(order, foodBusiness);// gestion de stock
				// Create a new instance of the logger
				TraceSource logger = new TraceSource("odoo");
				// Log an error
				logger.TraceEvent(TraceEventType.Error, 0, "odoo dont config");

				// Dispose of the logger
				logger.Close();
			}





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
			await  UpdateDishesAndProductQuantityOnCreateOrder(order, order.FoodBusiness); //  new order increase quantity
			await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
			var orderDto = _mapper.Map<OrderDto>(order);
			if (order.FoodBusiness.Odoo != null)
			{
				await UpdateOrderInOdoo(order); // update order in odoo
			}
			else
			{
				// Create a new instance of the logger
				TraceSource logger = new TraceSource("odoo");
				// Log an error
				logger.TraceEvent(TraceEventType.Error, 0, "odoo dont config");

				// Dispose of the logger
				logger.Close();
			}
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
				.Include(o => o.FoodBusiness)
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
				await addOrderNotifications(order.OrderId.ToString(), order.FoodBusinessId.ToString(), OrderNotificationType.Cancel, cancellationToken);
				await UpdateDishesAndProductQuantityOnRemoveOrder(order);
				
			}
			if (order.Status == OrderStatuses.InQueue){
			if (order.FoodBusiness.Odoo != null)
				{
					await _saleOrderRepository.Authenticate(order.FoodBusiness.Odoo); // auth in odoo
					await UpdateOrderStateInOdoo(order.OrderId.ToString(), "cancel",order);
				}
				else
				{
					// Create a new instance of the logger
					TraceSource logger = new TraceSource("odoo");
					// Log an error
					logger.TraceEvent(TraceEventType.Error, 0, "odoo dont config");

					// Dispose of the logger
					logger.Close();
				}
			 }
			 
			 if (order.Status == OrderStatuses.InProgress || order.Status == OrderStatuses.SalesOrderInOdoo)
			{
		if (order.FoodBusiness.Odoo != null)
			{
				await CreateOrderInOdoo(order); // create order odoo
			}
			else
			{
				// Create a new instance of the logger
				TraceSource logger = new TraceSource("odoo");
				// Log an error
				logger.TraceEvent(TraceEventType.Error, 0, "odoo dont config");

				// Dispose of the logger
				logger.Close();
			}
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
				 var hotel = _context.Hotels.Where(a => a.Id == hotelOrder.HotelId).FirstOrDefault();// get hotel
                    var checkin = _context.CheckIns.Where(a => a.Id == hotelOrder.CheckinId).FirstOrDefault();// get checkin

                    // create hotel order service in odoo

                    // read service hotel if existe else create one

                    if (hotel.Odoo != null)
                    {
                        long productId = await CreateOdooProductOfTypeChekin(hotel, hotelOrder); // get order chekin id 
                        long clientId = await CreateOdooClient(checkin, hotel); // get odoo client id
                        await CreateOrderHotelServiceInOdoo(checkin, clientId, hotelOrder, productId); // create order in odoo
                    }
                    else
                    {
                        // Create a new instance of the logger
                        TraceSource logger = new TraceSource("odoo");
                        // Log an error
                        logger.TraceEvent(TraceEventType.Error, 0, "odoo dont config");

                        // Dispose of the logger
                        logger.Close();
                    }

				
				
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

		private async Task UpdateDishesAndProductQuantityOnCreateOrderWithOdoo(Order order , Domain.Entities.FoodBusiness foodBusiness )
		{
			await _saleOrderRepository.Authenticate(foodBusiness.Odoo); // auth in odoo
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
					
					if (dishUpdated.SyncFromOdoo) // if SyncFromOdoo
				{
					var result = await _saleOrderRepository.Read<List<Dictionary<string, object>>>(
						"product.template",
						dishUpdated.OdooId
					); // get product quantity availale
				 
					int quantity = 0;
					if (result != null && result.Count > 0)
					{
						quantity = (int) result[0]["virtual_available"];
					}
					if ((quantity > 0) && ((quantity - (int)dish.Quantity) < 0))
								// trow if execption if not availibe
					{
						throw new ConflictException("Sorry, you can not take this quantity : " + dish.Quantity + " , issue quantity ( odoo ). ");
					}
				}else

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

				if (productUpdated.SyncFromOdoo) // if SyncFromOdoo
				{
					var result = await _saleOrderRepository.Read<List<Dictionary<string, object>>>(
						"product.template",
						productUpdated.OdooId
					); // get product quantity availale
				 
			
					if (result != null && result.Count > 0)
					{
						int quantity = 0;
						quantity = (int)int.Parse(result[0]["virtual_available"].ToString());
						if ((quantity>0)&&((quantity - (int)product.Quantity) < 0)) // trow if execption if not availibe
						{
							throw new ConflictException("Sorry, you can not take this quantity : " + product.Quantity + " , issue quantity ( odoo ). ");
						}
					}

					
				}else


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
		private async Task UpdateDishesAndProductQuantityOnCreateOrder(Order order, Domain.Entities.FoodBusiness foodBusiness)
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

		private async Task addOrderNotifications(string orderId,string foodBusinessId, OrderNotificationType type, CancellationToken cancellationToken)
		{
			var foodBusiness = await _context.FoodBusinesses.Where(u => u.FoodBusinessId == Guid.Parse(foodBusinessId))
				 .FirstOrDefaultAsync().ConfigureAwait(false);

			if (foodBusiness == null) throw new NotFoundException(nameof(foodBusiness), foodBusinessId);

			var orderNotificationDto = new OrderNotificationDto() { OrderId = orderId, Type = type, Read = null, CreatedAt = DateTime.Now, FoodBusinessId = foodBusinessId};

			var pathNotification = foodBusinessId + "/OrderNotifications";
			await _fireBase.AddCollectionAsync(pathNotification, orderNotificationDto, cancellationToken);

		} 
		
		
		
		private async Task<long> getOpnedSessionInOdooId()
		{
			var result = await _saleOrderRepository.Search<List<int>>(
				"pos.session",
				"state",
				"opened",
				1
			);
			long Id=0;
			if (result != null && result.Count > 0)
			{
				Id = result[0];
			}
			else
			{
				var sessionData = new Dictionary<string, object>
				{
					{ "config_id", 1 },
					{ "state", "opened" },
					{ "start_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") }
				};
				Id = await _saleOrderRepository.CreateAsync("pos.session", sessionData);
			}

			return Id;
		}

		private async Task UpdateOrderStateInOdoo(string orderId, string state,Order order)
		{
			string model = "pos.order";

			if (order.FoodBusinessClientId != null)
			{
				model = "sale.order";
			}
			var result = await _saleOrderRepository.Search<List<int>>(model, "name", orderId, 1);
			long Id=0;
			if (result != null && result.Count > 0)
			{
				Id = result[0];
				var data = new Dictionary<string, object> { { "state", state } };

				await _saleOrderRepository.UpdateAsync(model, Id, data);
			}
			else
			{
				// Create a new instance of the logger
				TraceSource logger = new TraceSource("odoo");
				// Log an error
				logger.TraceEvent(TraceEventType.Error, 0, "Sorry,this order not exist in odoo for updated it");

				// Dispose of the logger
				logger.Close();
			}
		}

		private async Task UpdateOrderInOdoo(Order order)
		{
			string model = "pos.order";
			string orderlineAttr = "lines";
			var data = new Dictionary<string, object>
			{
				{ "amount_total", order.TotalToPay },
				{ "amount_paid", order.TotalToPay }
			};

			if (order.FoodBusinessClientId != null)
			{
				model = "sale.order";
				orderlineAttr = "order_line";

				data = new Dictionary<string, object> { { "amount_total", order.TotalToPay } };
			}

			await _saleOrderRepository.Authenticate(order.FoodBusiness.Odoo); // auth in odoo
			var result = await _saleOrderRepository.Search<List<int>>(
				model,
				"name",
				order.OrderId.ToString(),
				1
			);

			long Id=0;
			


			if (result != null && result.Count > 0)
			{
				Id = result[0];
				var orderR = await _saleOrderRepository.Read<List<Dictionary<string, object>>>(
					model,
					Id
				);

				var linesIds = orderR[0][orderlineAttr]; // get lines

				if (linesIds != null)
				{
					JArray jArray = JArray.Parse(linesIds.ToString());

					foreach (int line in jArray)
					{
						await _saleOrderRepository.DeleteAsync(model + ".line", line); // delete line
					}
				}

				await _saleOrderRepository.UpdateAsync(model, Id, data); // update order amouunt

				if (order.FoodBusinessClientId == null)
				{
					await CreateOdooOrderLines(order, Id); // create new lines in order posales
				}
				else
				{
					await CreateOdooOrderSaleLines(order, Id); // create new lines in order posales
				}
			}
			else
			{
				// Create a new instance of the logger
				TraceSource logger = new TraceSource("odoo");
				// Log an error
				logger.TraceEvent(TraceEventType.Error, 0, "Sorry,this order not exist in odoo for updated it");

				// Dispose of the logger
				logger.Close();
			   
			}
		}

		private async Task CreateOrderInOdoo(Order order)
		{
			await _saleOrderRepository.Authenticate(order.FoodBusiness.Odoo); // auth in odoo
			

			if (order.FoodBusinessClientId != null)
			{
				var foodBusinessClient = await _context.FoodBusinessClients.FindAsync(
					order.FoodBusinessClientId
				);

				Dictionary<string, object> saleOrderDict = new Dictionary<string, object>
				{
					{ "name", order.OrderId.ToString() },
					{ "partner_id", foodBusinessClient.OdooId },
					{ "amount_total", order.TotalToPay },
				};

				var saleOrderId = await _saleOrderRepository.CreateAsync(
					"sale.order",
					saleOrderDict
				);
				await CreateOdooOrderSaleLines(order, saleOrderId);
				await UpdateOrderStateInOdoo(order.OrderId.ToString(),"sale.order" ,"sale");// set odoo order " bon de commande "
				
			}
			else
			{
				long sessionId = await getOpnedSessionInOdooId(); // get opned session id
				Dictionary<string, object> saleOrderDict = new Dictionary<string, object>
				{
					{ "name", order.OrderId.ToString() },
					{ "date_order", order.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss") },
					{ "session_id", sessionId },
					{ "amount_total", order.TotalToPay },
					{ "amount_tax", 0.0 },
					{ "amount_paid", order.TotalToPay },
					{ "amount_return", 0.0 },
					{ "pos_reference", order.OrderId.ToString() },
				}; // create order odoo

				var saleOrderId = await _saleOrderRepository.CreateAsync(
					"pos.order",
					saleOrderDict
				);
				await CreateOdooOrderLines(order, saleOrderId);
			
			}
		}

		private async Task CreateOdooOrderLines(Order order, long saleOrderId)
		{
			if (order.Dishes.Count > 0)
			{
				foreach (var dishLine in order.Dishes)
				{
					var orderLineDish = new Dictionary<string, object>
					{
						{ "order_id", saleOrderId },
						{ "full_product_name", dishLine.Name },
						{ "qty", dishLine.Quantity },
						{ "price_unit", dishLine.UnitPrice },
						{ "discount", 0.0 },
						{ "product_id", dishLine.OdooId },
						{ "price_subtotal", dishLine.UnitPrice * dishLine.Quantity },
						{ "price_subtotal_incl", dishLine.UnitPrice * dishLine.Quantity }
					};
					await _saleOrderRepository.CreateAsync("pos.order.line", orderLineDish);
					// add dish in odoo order
				}
			}

			if (order.Products.Count > 0)
			{
				foreach (var productLine in order.Products)
				{
					var orderLineProduct = new Dictionary<string, object>
					{
						{ "order_id", saleOrderId },
						{ "full_product_name", productLine.Name },
						{ "qty", productLine.Quantity },
						{ "price_unit", productLine.UnitPrice },
						{ "discount", 0.0 },
						{ "price_subtotal", productLine.UnitPrice * productLine.Quantity },
						{ "price_subtotal_incl", productLine.UnitPrice * productLine.Quantity },
						{ "product_id", productLine.OdooId }
					};
					await _saleOrderRepository.CreateAsync("pos.order.line", orderLineProduct); // add product in odoo order
				}
			}
		}

		private async Task CreateOdooOrderSaleLines(Order order, long saleOrderId)
		{
			if (order.Dishes.Count > 0)
			{
				foreach (var dishLine in order.Dishes)
				{
					var orderLineDish = new Dictionary<string, object>
					{
						{ "order_id", saleOrderId },
						{ "name", dishLine.Name },
						{ "product_uom_qty", dishLine.Quantity },
						{ "price_unit", dishLine.UnitPrice },
						{ "product_id", dishLine.OdooId },
						 {"tax_id", null},
						 
						
					};
					await _saleOrderRepository.CreateAsync("sale.order.line", orderLineDish);
					// add dish in odoo order
				}
			}

			if (order.Products.Count > 0)
			{
				foreach (var productLine in order.Products)
				{
					var orderLineProduct = new Dictionary<string, object>
					{
						{ "order_id", saleOrderId },
						{ "name", productLine.Name },
						{ "product_uom_qty", productLine.Quantity },
						{ "price_unit", productLine.UnitPrice },
						{ "product_id", productLine.OdooId },
						{"tax_id", null}
					};
					await _saleOrderRepository.CreateAsync("sale.order.line", orderLineProduct); // add product in odoo order
				}
			}
		}
		
		private async Task<long> UpdateOrderStateInOdoo(string orderId,string model , string state)
		{
			var result = await _saleOrderRepository.Search<List<int>>(model, "name", orderId, 1);
			long Id=0;
			if (result != null && result.Count > 0)
			{
				Id = result[0];
				var data = new Dictionary<string, object>
			{
				{ "state", state}

			};
				await _saleOrderRepository.UpdateAsync(model, Id, data);
				return Id;
			}
			else
			{
				// Create a new instance of the logger
				TraceSource logger = new TraceSource("odoo");
				// Log an error
				logger.TraceEvent(TraceEventType.Error, 0, "Sorry,this order not exist in odoo for updated it");

				// Dispose of the logger
				logger.Close();
				return 0;
			}

		}
	
	



	}
}