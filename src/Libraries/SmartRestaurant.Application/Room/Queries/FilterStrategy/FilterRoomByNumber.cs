using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Rooms.Queries.FilterStrategy;
using SmartRestaurant.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SmartRestaurant.Application.Rooms.Queries.FilterStrategy
{
    public class FilterRoomByNumber : IRoomsFilterStrategy
    {
        public PagedResultBase<Room> FetchData(DbSet<Room> rooms, GetAllRoomsByBuildingId request)
        {


            return rooms
               .Where(Condition(request.BuildingId))
               .GetPaged(request.Page, request.PageSize);

        }

        private static Expression<Func<Room, bool>> Condition( Guid buildingid)
        {
           
                return room => room.BuildingId==buildingid ;
        }

    }
}
