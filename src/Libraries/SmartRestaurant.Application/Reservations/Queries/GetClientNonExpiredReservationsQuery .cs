using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;

namespace SmartRestaurant.Application.Reservations.Queries
{
    public class GetClientNonExpiredReservationsQuery : IPagedListQuery<ReservationClientDto>
    {
        public string UserId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}