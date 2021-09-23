using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;

namespace SmartRestaurant.Application.DishIngredients.Queries
{
    public class
        DishIngredientsQueriesHandler : IRequestHandler<GetDishIngredientsByDishIdQuery, List<DishIngredientDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DishIngredientsQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<DishIngredientDto>> Handle(GetDishIngredientsByDishIdQuery request,
            CancellationToken cancellationToken)
        {
            var dish = await _context.Dishes.FindAsync(request.DishId);

            var dishIngredients = await _context.DishIngredients
                .Where(di => di.DishId == request.DishId)
                .ToListAsync(cancellationToken);

            var ingredients = await _context.Ingredients
                .Where(i => i.FoodBusinessId == dish.FoodBusinessId)
                .ToListAsync(cancellationToken);

            var dishIngredientsDto = _mapper.Map<List<DishIngredientDto>>(dishIngredients);

            for (var i = 0; i < dishIngredients.Count; i++)
            {
                var ingredientId = dishIngredientsDto[i].IngredientId;
                dishIngredientsDto[i].IngredientName =
                    ingredients.First(ingredient => ingredient.IngredientId == ingredientId).Name;
            }

            return dishIngredientsDto;
        }
    }
}