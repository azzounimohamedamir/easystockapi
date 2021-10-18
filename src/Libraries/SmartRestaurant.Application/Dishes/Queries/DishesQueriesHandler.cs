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
                 .Where(u => u.DishId == Guid.Parse(request.Id))
                 .FirstOrDefaultAsync()
                 .ConfigureAwait(false);

            if (dish == null) 
                throw new NotFoundException(nameof(Dish), request.Id);
            return _mapper.Map<DishDto>(dish);
        }


        public async Task<PagedListDto<DishDto>> Handle(GetDishesListQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetDishesListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var foodBusiness = await _context.FoodBusinesses.FindAsync(Guid.Parse(request.FoodBusinessId));
            if (foodBusiness == null)
                throw new NotFoundException(nameof(FoodBusiness), request.FoodBusinessId);

            var filter = DishStrategies.GetFilterStrategy(request.CurrentFilter);
            var query = filter.FetchData(_context.Dishes, request);

            var data = _mapper.Map<List<DishDto>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));

            return new PagedListDto<DishDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }


      


        private async Task<CurrencyDto> GetFoodBusinessDefaultCurrency(Guid foodBusinessId)
        {
            var foodBusiness = await _context.FoodBusinesses
                .FirstOrDefaultAsync(d => d.FoodBusinessId == foodBusinessId);
            var currency = await _context.Currencies.FindAsync(foodBusiness.DefaultCurrencyId);
            if (currency != null) return _mapper.Map<CurrencyDto>(currency);

            return new CurrencyDto
            {
                Code = "DZD",
                Name = "Algerian Dinar",
                Symbol = "DZD"
            };
        }

        private PriceDto MapPrice(Dish dish, CurrencyDto currency)
        {
            return new PriceDto
            {
                Value = dish.Price,
                Currency = _mapper.Map<CurrencyDto>(currency)
            };
        }
    }
}