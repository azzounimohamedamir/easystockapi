using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Hotels.Queries
{
    public class GetHotelsListQuery : IRequest<PagedListDto<HotelsDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchKey { get; set; }
        public string SortOrder { get; set; }
        public string CurrentFilter { get; set; }
    }
}
