using System;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.Ingredients.Queries
{
    public class GetIngredientsByFoodBusinessIdQuery : IRequest<PagedListDto<IngredientDto>>
    {
        public Guid FoodBusinessId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}