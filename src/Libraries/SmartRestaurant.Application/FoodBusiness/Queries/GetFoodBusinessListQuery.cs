using MediatR;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.FoodBusiness.Queries
{
    public class GetFoodBusinessListQuery :  IRequest<PagedListDto<FoodBusinessDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
