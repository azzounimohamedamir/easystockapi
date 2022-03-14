using MediatR;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.Common.Interfaces
{
    public interface IPagedListQuery<TDto> : IRequest<PagedListDto<TDto>> where TDto : class
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}