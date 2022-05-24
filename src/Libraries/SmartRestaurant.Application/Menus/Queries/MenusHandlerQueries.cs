using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.CurrencyExchange;
using SmartRestaurant.Application.Menus.Queries.FilterStrategy;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.Menus.Queries
{
    public class MenusHandlerQueries :
        IRequestHandler<GetMenusListQuery, PagedListDto<MenuDto>>,
        IRequestHandler<GetMenuByIdQuery, MenuDto>,
        IRequestHandler<GetActiveMenuQuery, ActiveMenuDto>

    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MenusHandlerQueries(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MenuDto> Handle(GetMenuByIdQuery request, CancellationToken cancellationToken)
        {
            var query = await _context.Menus.FindAsync(request.MenuId).ConfigureAwait(false);
            return _mapper.Map<MenuDto>(query);
        }

        public async Task<PagedListDto<MenuDto>> Handle(GetMenusListQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetMenusListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var foodBusiness = await _context.FoodBusinesses.FindAsync(Guid.Parse(request.FoodBusinessId));
            if (foodBusiness == null)
                throw new NotFoundException(nameof(FoodBusiness), request.FoodBusinessId);

            var filter = MenuStrategies.GetFilterStrategy(request.CurrentFilter);
            var query = filter.FetchData(_context.Menus, request);

            var data = _mapper.Map<List<MenuDto>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));

            return new PagedListDto<MenuDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }

        public async Task<ActiveMenuDto> Handle(GetActiveMenuQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetActiveMenuQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid)
                throw new ValidationException(result);

            var foodBusiness = await _context.FoodBusinesses.FindAsync(Guid.Parse(request.FoodBusinessId));
            if (foodBusiness == null)
                throw new NotFoundException(nameof(FoodBusiness), request.FoodBusinessId);

            var query = await _context.Menus
                .Where(m => m.FoodBusinessId == Guid.Parse(request.FoodBusinessId)
                       && m.MenuState == MenuState.Enabled)

                .Include(m => m.Sections)
                .ThenInclude(sb => sb.Dishes)
                .ThenInclude(d => d.Dish)
                .ThenInclude(d => d.Ingredients)
                .ThenInclude(d => d.Ingredient)
                .Include(m => m.Sections)
                .ThenInclude(sb => sb.Dishes)
                .ThenInclude(d => d.Dish)
                .ThenInclude(d => d.Specifications)
                .Include(m => m.Sections)
                .ThenInclude(sb => sb.Dishes)
                .ThenInclude(d => d.Dish)
                .ThenInclude(d => d.Supplements)
                .ThenInclude(d=>d.Supplement)

                .Include(m => m.Sections)
                .ThenInclude(s => s.SubSections)
                .ThenInclude(sb => sb.Dishes)
                .ThenInclude(d => d.Dish)
                .ThenInclude(d => d.Ingredients)
                .ThenInclude(d => d.Ingredient)
                .Include(m => m.Sections)
                .ThenInclude(s => s.SubSections)
                .ThenInclude(sb => sb.Dishes)
                .ThenInclude(d => d.Dish)
                .ThenInclude(d => d.Specifications)
                .Include(m => m.Sections)
                .ThenInclude(s => s.SubSections)
                .ThenInclude(sb => sb.Dishes)
                .ThenInclude(d => d.Dish)
                .ThenInclude(d => d.Supplements)
                .ThenInclude(d => d.Supplement)

                .Include(m => m.Sections)
                .ThenInclude(sb => sb.Products)
                .ThenInclude(d => d.Product)

                .Include(m => m.Sections)
                .ThenInclude(s => s.SubSections)
                .ThenInclude(sb => sb.Products)
                .ThenInclude(d => d.Product)

                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            var menu = _mapper.Map<ActiveMenuDto>(query);
            SetCurrencyExchange(foodBusiness, menu);
            return menu;
        }

        private static void SetCurrencyExchange(Domain.Entities.FoodBusiness foodBusiness, ActiveMenuDto menu)
        {
            foreach (var section in menu.Sections)
            {
                if (section.HasSubSection == true)
                {
                    foreach (var subSections in section.SubSections)
                    {
                        foreach (var dish in subSections.MenuItems.Dishes)
                        {
                            dish.CurrencyExchange = CurrencyConverter
                               .GetDefaultCurrencyExchangeList(dish.Price, foodBusiness.DefaultCurrency);
                        }

                        foreach (var product in subSections.MenuItems.Products)
                        {
                            product.CurrencyExchange = CurrencyConverter
                                .GetDefaultCurrencyExchangeList(product.Price, foodBusiness.DefaultCurrency);
                        }
                    }
                }
                else
                {
                    foreach (var dish in section.MenuItems.Dishes)
                    {
                        dish.CurrencyExchange = CurrencyConverter
                           .GetDefaultCurrencyExchangeList(dish.Price, foodBusiness.DefaultCurrency);
                    }

                    foreach (var product in section.MenuItems.Products)
                    {
                        product.CurrencyExchange = CurrencyConverter
                            .GetDefaultCurrencyExchangeList(product.Price, foodBusiness.DefaultCurrency);
                    }
                }
            }
        }
    }
}