using MediatR;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.FoodBusinessClient.Queries
{
    public class GetFoodBusinesClientListQuery : IRequest<PagedListDto<FoodBusinessClientDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
