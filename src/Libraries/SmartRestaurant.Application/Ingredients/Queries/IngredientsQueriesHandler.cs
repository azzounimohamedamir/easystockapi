using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Ingredients.Queries
{
    public class
        IngredientsQueriesHandler : IRequestHandler<GetIngredientByIdQuery, IngredientDto>,
            IRequestHandler<GetIngredientsByFoodBusinessIdQuery, PagedListDto<IngredientDto>>

    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public IngredientsQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IngredientDto> Handle(GetIngredientByIdQuery request, CancellationToken cancellationToken)
        {
            var ingredient = await _context.Ingredients.FindAsync(request.IngredientId);
            if (ingredient == null) throw new NotFoundException(nameof(Ingredient), request.IngredientId);
            return _mapper.Map<IngredientDto>(ingredient);
        }

        public async Task<PagedListDto<IngredientDto>> Handle(GetIngredientsByFoodBusinessIdQuery request,
            CancellationToken cancellationToken)
        {
            var foodBusiness = await _context.FoodBusinesses.FindAsync(request.FoodBusinessId);
            if (foodBusiness == null) throw new NotFoundException(nameof(FoodBusiness), request.FoodBusinessId);
            var result = _context.Ingredients.Where(i => i.FoodBusinessId == request.FoodBusinessId)
                .GetPaged(request.Page, request.PageSize);
            return result.Data.Any()
                ? _mapper.Map<PagedListDto<IngredientDto>>(result)
                : new PagedListDto<IngredientDto>(result.CurrentPage, result.PageCount, result.PageSize,
                    result.RowCount, new List<IngredientDto>());
        }
    }
}