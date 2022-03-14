using System;
using System.Collections.Generic;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.Tables.Queries
{
    public class GetTablesListQuery : IRequest<IEnumerable<TableDto>>
    {
        public Guid ZoneId { get; set; }
    }
}