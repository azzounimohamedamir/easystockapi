using System;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.Ingredients.Queries
{
    public class GetIngredientByIdQuery : IRequest<IngredientDto>
    {
        public Guid IngredientId { get; set; }
    }
}