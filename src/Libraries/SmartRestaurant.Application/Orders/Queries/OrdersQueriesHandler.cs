using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.OrdersDtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Application.CurrencyExchange;
using SmartRestaurant.Application.Orders.Queries.FilterStrategy;
using SmartRestaurant.Domain.Common.Enums;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Identity.Entities;
using SmartRestaurant.Domain.Identity.Enums;
using SmartRestaurant.Domain.ValueObjects;

namespace SmartRestaurant.Application.Orders.Queries
{
    public class OrdersQueriesHandler : 
        IRequestHandler<GetOrderByIdQuery, OrderDto>,
        IRequestHandler<GetOrdersListQuery, PagedListDto<OrderDto>>,
        IRequestHandler<GetAllClientSHOrdersQuery, PagedListDto<HotelOrderDto>>,
        IRequestHandler<GetOrdersListByDinnerOrClientQuery, PagedListDto<OrderDto>>,
        IRequestHandler<GetAllTodayOrdersQueryByTableId, PagedListDto<OrderDto>>,
        IRequestHandler<GetLastOrderByTableIDQuery, OrderDto>,
        IRequestHandler<GetAllClientSHOrdersTotalQuery, float>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IOdooRepository _saleOrderRepository;


        public OrdersQueriesHandler( IApplicationDbContext context, IUserService userService, IMapper mapper, UserManager<ApplicationUser> userManager, IOdooRepository saleOrderRepository)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
            _userService = userService;
            _saleOrderRepository = saleOrderRepository;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetOrderByIdQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var order = await _context.Orders.AsNoTracking()
                .Include(o => o.Dishes)
                .ThenInclude(o => o.Specifications)
                .ThenInclude(o=>o.ComboBoxContentTranslation)
                .Include(o => o.Dishes)
                .ThenInclude(o => o.Ingredients)
                .Include(o => o.Dishes)
                .ThenInclude(o => o.Supplements)
                .Include(o => o.Products)
                .Include(o => o.OccupiedTables)
                .Include(o => o.CommissionConfigs)
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.OrderId == Guid.Parse(request.Id), cancellationToken)
                .ConfigureAwait(false);
            if (order == null)
                throw new NotFoundException(nameof(Order), request.Id);
                       
            var foodBusiness = await _context.FoodBusinesses.FindAsync(order.FoodBusinessId);
            if (foodBusiness == null)
                throw new NotFoundException(nameof(FoodBusiness), request.Id);

            var orderDto = _mapper.Map<OrderDto>(order);
            orderDto.CurrencyExchange = CurrencyConverter.GetDefaultCurrencyExchangeList(orderDto.TotalToPay, foodBusiness.DefaultCurrency);
            orderDto.CreatedBy = _mapper.Map<ApplicationUserDto>(await _userManager.FindByIdAsync(order.CreatedBy));

            return orderDto;
        }

        public async Task<PagedListDto<OrderDto>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetOrdersListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var foodBusiness = await _context.FoodBusinesses.FindAsync(Guid.Parse(request.FoodBusinessId));
            if (foodBusiness == null)
                throw new NotFoundException(nameof(FoodBusiness), request.FoodBusinessId);

            var filter = OrderStrategies.GetFilterStrategy(request.CurrentFilter);
            var query = filter.FetchData(_context.Orders, request);

            var queryData = await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false);
            var data = _mapper.Map<List<OrderDto>>(queryData);
            long contactMenuId = 0;
            if (foodBusiness.Odoo != null)
            {
                var loggedIn = await _saleOrderRepository.Authenticate(foodBusiness.Odoo);
                contactMenuId = await getOdooClientMenuId();
            }
                foreach (var order in data)
            {
                order.CurrencyExchange = CurrencyConverter.GetDefaultCurrencyExchangeList(order.TotalToPay, foodBusiness.DefaultCurrency);
                order.CreatedBy = _mapper.Map<ApplicationUserDto>(await _userManager.FindByIdAsync(queryData.Find(o => o.OrderId.ToString() == order.OrderId).CreatedBy));
                if (foodBusiness.Odoo != null && contactMenuId != 0)
                {
                    order.OdooContactMenuId = contactMenuId;
                    order.OdooUrl = foodBusiness.Odoo.Url;
                    if (order.FoodBusinessClientId != "")
                    { 

                        order.OdooClientId = await CreateOdooClient(order.FoodBusinessClient.Name, order.FoodBusinessClient.Email, order.FoodBusinessClient.PhoneNumber.Number.ToString(),true);
                        order.OrderedBy = order.FoodBusinessClient.Name;
                    }
                    else
                    {
                       order.OrderedBy = order.CreatedBy.FullName;
                       order.OdooClientId = await CreateOdooClient(order.CreatedBy.FullName, order.CreatedBy.Email, order.CreatedBy.PhoneNumber, order.CreatedBy.IsShowPhoneNumberInOdoo); // get odoo client id
                    }

                }
            }
            return new PagedListDto<OrderDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }

        private async Task<long> getOdooClientMenuId()
        {
            long menuId = 0;
            var result = await _saleOrderRepository.Search<List<int>>(
                  "ir.ui.menu",
                  "name",
                  "Contacts",
                  1
              );



            if (result != null && result.Count > 0)
            {
                menuId = result[0];
            }

            return menuId;

        }



        private async Task<long> CreateOdooClient(string fullName, string email, string phone, bool isShowPhoneNumberInOdoo)
        {



            long odooId = 0;

            var result = await _saleOrderRepository.Search<List<int>>(
                    "res.partner",
                    "email",
                    email,
                    1
                );



            if (result != null && result.Count > 0)
            {
                odooId = result[0];
            }
            else
            {
                var data = new Dictionary<string, object> { };

                if (isShowPhoneNumberInOdoo)
                {
                    data = new Dictionary<string, object>
                {
                { "name", fullName},
                { "phone", phone},
                { "email",  email }

                };

                }
                else
                {
                    data = new Dictionary<string, object>
                {
                { "name", fullName},

                { "email",  email }

                };

                }




                odooId = await _saleOrderRepository.CreateAsync("res.partner", data);
            }


            return odooId;
        }

        public async Task<PagedListDto<OrderDto>> Handle(GetOrdersListByDinnerOrClientQuery request, CancellationToken cancellationToken)
        {
            var dinerId = _userService.GetUserId();
            var validator = new GetOrdersListByDinnerOrClientQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var filter = OrderStrategies.GetFilterStrategy(request.CurrentFilter);
            var query = filter.FetchDataOfDinnerOrClient(_context.Orders, request, dinerId);

            var queryData = await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false);
            var data = _mapper.Map<List<OrderDto>>(queryData);
            foreach (var order in data)
            {
                var foodBusiness = await _context.FoodBusinesses.FindAsync(Guid.Parse(order.FoodBusinessId));
                if (foodBusiness == null)
                    throw new NotFoundException(nameof(FoodBusiness), order.FoodBusinessId);
                order.CurrencyExchange = CurrencyConverter.GetDefaultCurrencyExchangeList(order.TotalToPay, foodBusiness.DefaultCurrency);

                order.CreatedBy = _mapper.Map<ApplicationUserDto>(await _userManager.FindByIdAsync(queryData.Find(o => o.OrderId.ToString() == order.OrderId).CreatedBy));
            }
            return new PagedListDto<OrderDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }


        public async Task<PagedListDto<HotelOrderDto>> Handle(GetAllClientSHOrdersQuery request, CancellationToken cancellationToken)
        {
            var searchKey = (string.IsNullOrWhiteSpace(request.SearchKey) ? "" : request.SearchKey).ToLower();
            var roles = _userService.GetRoles();

            if(roles.Contains(Roles.Diner.ToString()) || roles.Contains(Roles.HotelClient.ToString()))
            {
                var clientId = _userService.GetUserId();

                var validator = new GetAllClientSHOrdersQueryValidator();
                var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
                if (!result.IsValid) throw new ValidationException(result);
                var filter = OrderStrategies.GetFilterStrategy(request.CurrentFilter);
                var list = filter.FetchDataOfClientSH(_context.HotelOrders, request, clientId);
                var hotelOrderdtoData = (from ho in list
                                         join check in _context.CheckIns on
                                          ho.CheckinId equals check.Id
                                         join ro in _context.Rooms on check.RoomId equals ro.Id
                                         join hotel in _context.Hotels on check.hotelId equals hotel.Id
                                         where check.ClientId == clientId
                                         select new HotelOrderDto
                                         {
                                             DateOrder = ho.DateOrder,
                                             ChairNumber = ho.ChairNumber,
                                             Checkin = check,
                                             Room = ro,
                                             Hotel = hotel,
                                             FailureMessage = ho.FailureMessage,
                                             SuccesMessage = ho.SuccesMessage,
                                             OrderDestinationId = ho.OrderDestinationId,
                                             FoodBusinessId = ho.FoodBusinessId,
                                             IsSmartrestaurantMenue = ho.IsSmartrestaurantMenue,
                                             Names = ho.Names,
                                             SmartRestaurentOrderId = ho.SmartRestaurentOrderId,
                                             ParametreValueClient = ho.ParametreValueClient,
                                             TableId = ho.TableId,
                                             OrderStat = ho.OrderStat,
                                             Type = ho.Type,
                                             UserId = ho.UserId,
                                             Id = ho.Id,
                                             Quantity=ho.Quantity,
                                             TotalToPay=ho.TotalToPay,
                                             UnitePrice=ho.UnitePrice,
                                         });
                var query = hotelOrderdtoData.AsQueryable().GetPaged(request.Page, request.PageSize);
                var data = query.Data.AsNoTracking().ToList();
                if (searchKey != "")
                {
                    var dataFiltered = hotelOrderdtoData.Where(
                      a => a.Hotel.Name.ToLower().Contains(searchKey) ||
                      a.Names.AR.ToLower().Contains(searchKey) ||
                      a.Names.FR.ToLower().Contains(searchKey) ||
                      a.Names.EN.ToLower().Contains(searchKey) ||
                      a.Names.RU.ToLower().Contains(searchKey) ||
                      a.Names.TR.ToLower().Contains(searchKey) ||
                      a.Type.ToString().ToLower().Contains(searchKey) ||
                       a.OrderStat.ToString().ToLower().Contains(searchKey) ||
                      a.Room.RoomNumber.ToString().Contains(searchKey)
                       ).ToList();
                    var pagedResult = new PagedListDto<HotelOrderDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, dataFiltered);
                    return pagedResult;
                }
                else
                {
                    return new PagedListDto<HotelOrderDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);

                }

            }
            if (roles.Contains(Roles.FoodBusinessManager.ToString()) || roles.Contains(Roles.HotelServiceAdmin.ToString()) || roles.Contains(Roles.FoodBusinessAdministrator.ToString()))
            {

                var validator = new GetAllClientSHOrdersQueryValidator();
                var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
                if (!result.IsValid) throw new ValidationException(result);
                var filter = OrderStrategies.GetFilterStrategy(request.CurrentFilter);
                var list = filter.FetchDataOfManagerSH(_context.HotelOrders, request);
                var hotelOrderdtoData = (from ho in list
                                         join check in _context.CheckIns on
                                        ho.CheckinId equals check.Id
                                         join ro in _context.Rooms on check.RoomId equals ro.Id
                                         join hotel in _context.Hotels on check.hotelId equals hotel.Id
                                         where hotel.Id == Guid.Parse(request.HotelId)
                                         select new HotelOrderDto
                                         {
                                             DateOrder = ho.DateOrder,
                                             ChairNumber = ho.ChairNumber,
                                             Checkin = check,
                                             Room = ro,
                                             Hotel = hotel,
                                             FailureMessage = ho.FailureMessage,
                                             SuccesMessage = ho.SuccesMessage,
                                             OrderDestinationId = ho.OrderDestinationId,
                                             FoodBusinessId = ho.FoodBusinessId,
                                             IsSmartrestaurantMenue = ho.IsSmartrestaurantMenue,
                                             Names = ho.Names,
                                             SmartRestaurentOrderId = ho.SmartRestaurentOrderId,
                                             ParametreValueClient = ho.ParametreValueClient,
                                             TableId = ho.TableId,
                                             OrderStat = ho.OrderStat,
                                             Type = ho.Type,
                                             UserId = ho.UserId,
                                             Id = ho.Id,
                                             TotalToPay= ho.TotalToPay,

                                         });
                                if (request.OrderDestinationId!= null)
                {
                    hotelOrderdtoData = hotelOrderdtoData.Where(o => o.OrderDestinationId == request.OrderDestinationId);
                }
                                if (roles.Contains(Roles.FoodBusinessAdministrator.ToString()))
                {
                    hotelOrderdtoData = hotelOrderdtoData.Where(o => o.OrderStat == SHOrderStat.ResponseSucces);

                }
               var query=hotelOrderdtoData.AsQueryable().GetPaged(request.Page,request.PageSize);
                var data = query.Data.AsNoTracking().ToList();

                if (searchKey != "")
                {
                     data = data.Where(
                      a => 
                      a.Checkin.FullName.ToLower().Contains(searchKey) ||
                      a.Checkin.Email.ToLower().Contains(searchKey) ||
                      a.Checkin.PhoneNumber.ToLower().Contains(searchKey) ||
                      a.Names.AR.ToLower().Contains(searchKey) ||
                      a.Names.FR.ToLower().Contains(searchKey) ||
                      a.Names.EN.ToLower().Contains(searchKey) ||
                      a.Names.RU.ToLower().Contains(searchKey) ||
                      a.Names.TR.ToLower().Contains(searchKey) ||
                      a.Type.ToString().ToLower().Contains(searchKey) ||
                       a.OrderStat.ToString().ToLower().Contains(searchKey) ||
                      a.Room.RoomNumber.ToString().Contains(searchKey)
                       ).ToList();
                   
                }
                    return new PagedListDto<HotelOrderDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
              
            }

                return default;
        }



        public async Task<PagedListDto<OrderDto>> Handle(GetAllTodayOrdersQueryByTableId request, CancellationToken cancellationToken)
        {
            var validator = new GetAllTodayOrdersQueryValidator();
            var datafilter=new List<OrderDto>();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var filter = OrderStrategies.GetFilterStrategy(request.CurrentFilter);
            var query = filter.FetchOrderListOfTodayOfDinner(_context.Orders, request);
                
            var queryData = await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false);
            var data = _mapper.Map<List<OrderDto>>(queryData);

            foreach (var item in data)
            {
                foreach (var occ in item.OccupiedTables)
                {
                    if (occ.TableId == request.TableId.ToString())
                    {
                        datafilter.Add(item);
                    }
                }
            }

            foreach (var order in datafilter)
            {
                var foodBusiness = await _context.FoodBusinesses.FindAsync(Guid.Parse(order.FoodBusinessId));
                if (foodBusiness == null)
                    throw new NotFoundException(nameof(FoodBusiness), order.FoodBusinessId);
                order.CurrencyExchange = CurrencyConverter.GetDefaultCurrencyExchangeList(order.TotalToPay, foodBusiness.DefaultCurrency);

                order.CreatedBy = _mapper.Map<ApplicationUserDto>(await _userManager.FindByIdAsync(queryData.Find(o => o.OrderId.ToString() == order.OrderId).CreatedBy));
            }
            return new PagedListDto<OrderDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, datafilter);
        }

        public async Task<OrderDto> Handle(GetLastOrderByTableIDQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetLastOrderByTableIDValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var orders = await _context.Orders.AsNoTracking()
                .Include(o => o.Dishes)
                .ThenInclude(o => o.Specifications)
                .ThenInclude(o => o.ComboBoxContentTranslation)
                .Include(o => o.Dishes)
                .ThenInclude(o => o.Ingredients)
                .Include(o => o.Dishes)
                .ThenInclude(o => o.Supplements)
                .Include(o => o.Products)
                .Include(o => o.OccupiedTables)
                .Where(o => o.OccupiedTables.Select(t => t.TableId).Contains(request.TableId))
                .OrderByDescending(o=>o.CreatedAt)
                .Take(1)
                .AsNoTracking()
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
            if (orders == null || orders.Count==0)
                throw new NotFoundException(nameof(Order), request.TableId);

            var foodBusiness = await _context.FoodBusinesses.FindAsync(orders[0].FoodBusinessId);
            if (foodBusiness == null)
                throw new NotFoundException(nameof(FoodBusiness), request.TableId);

            var orderDto = _mapper.Map<OrderDto>(orders[0]);
            orderDto.CurrencyExchange = CurrencyConverter.GetDefaultCurrencyExchangeList(orderDto.TotalToPay, foodBusiness.DefaultCurrency);
            orderDto.CreatedBy = _mapper.Map<ApplicationUserDto>(await _userManager.FindByIdAsync(orders[0].CreatedBy));
            return orderDto;
        }



        public async Task<float> Handle(GetAllClientSHOrdersTotalQuery request, CancellationToken cancellationToken)
        {
          

                var validator = new GetAllClientSHOrdersTotalQueryValidator();
                var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
                if (!result.IsValid) throw new ValidationException(result);
                var filter = OrderStrategies.GetFilterStrategy(request.CurrentFilter);
                return    filter.FetchDataOfManagerSHTotal(_context.HotelOrders, request);
             
              
           

          
        }


    }
}