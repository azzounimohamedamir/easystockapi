using System;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;

namespace SmartRestaurant.Application.Reservations.Queries
{
    public class GetReservationsListByReservationDateTimeIntervalQuery : IPagedListQuery<ReservationDto>
    {
        public Guid FoodBusinessId { get; set; }
        public DateTime TimeIntervalStart { get; set; }
        public DateTime TimeIntervalEnd { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}