using System;
using System.Collections.Generic;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.DishIngredients.Queries
{
    public class GetDishIngredientsByDishIdQuery : IRequest<List<DishIngredientDto>>
    {
        public Guid DishId { get; set; }
    }
}