using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Rooms.Queries.FilterStrategy
{
    public interface IRoomsFilterStrategy
    {     
        public PagedResultBase<Room> FetchData(DbSet<Room> rooms, GetAllRoomsByBuildingId request);
    }
}
