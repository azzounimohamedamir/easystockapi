using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Rooms.Queries
{
    public class GetAllRoomsByBuildingId: IRequest<PagedListDto<RoomDto>>
    {
        public Guid BuildingId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchKey { get; set; }
        public string SortOrder { get; set; }
        public string CurrentFilter { get; set; }
    }
}
