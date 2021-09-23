using System;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.Dishes.Queries
{
    public class GetDishesByFoodBusinessIdQuery : IRequest<PagedListDto<DishDto>>
    {
        public Guid FoodBusinessId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}