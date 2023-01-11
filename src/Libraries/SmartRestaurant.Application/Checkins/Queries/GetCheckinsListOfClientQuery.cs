using System;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;

namespace SmartRestaurant.Application.Checkins.Queries
{
    public class GetCheckinsListOfClientQuery : IPagedListQuery<CheckinDto>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}