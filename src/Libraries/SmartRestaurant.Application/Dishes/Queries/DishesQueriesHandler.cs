using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.DishDtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.CurrencyExchange;
using SmartRestaurant.Application.Dishes.Queries.FilterStrategy;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Dishes.Queries
{
    public class DishesQueriesHandler : 
        IRequestHandler<GetDishByIdQuery, DishDto>,
        IRequestHandler<GetDishesListQuery, PagedListDto<DishDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DishesQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<DishDto> Handle(GetDishByIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetDishByIdQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var dish = await _context.Dishes
                 .Include(x => x.Ingredients)
                 .ThenInclude(x => x.Ingredient)
                 .Include(x => x.Supplements)
                 .ThenInclude(x => x.Supplement)
                 .Include(x => x.Specifications)
                 .ThenInclude(x=>x.ComboBoxContentTranslation)
                 .Where(u => u.DishId == Guid.Parse(request.Id))
                 .FirstOrDefaultAsync()
                 .ConfigureAwait(false);
            if (dish == null) 
                throw new NotFoundException(nameof(Dish), request.Id);

            var foodBusiness = await _context.FoodBusinesses.FindAsync(dish.FoodBusinessId);
            if (foodBusiness == null)
                throw new NotFoundException(nameof(FoodBusiness), request.Id);

            var dishDto = _mapper.Map<DishDto>(dish);
            dishDto.CurrencyExchange = CurrencyConverter.GetDefaultCurrencyExchangeList(dish.Price, foodBusiness.DefaultCurrency);

            return dishDto;
        }

        public async Task<PagedListDto<DishDto>> Handle(GetDishesListQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetDishesListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var foodBusiness = await _context.FoodBusinesses.FindAsync(Guid.Parse(request.FoodBusinessId));
            if (foodBusiness == null)
                throw new NotFoundException(nameof(FoodBusiness), request.FoodBusinessId);

            var filter = DishesStrategies.GetFilterStrategy(request.CurrentFilter);
            var query = filter.FetchData(_context.Dishes, request);

            var data = _mapper.Map<List<DishDto>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));
            
            foreach(var dish in data)
            {
                dish.CurrencyExchange = CurrencyConverter.GetDefaultCurrencyExchangeList(dish.Price, foodBusiness.DefaultCurrency);
            }
            return new PagedListDto<DishDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }
    }
}