using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using System;

namespace SmartRestaurant.Application.Tables.Queries
{
    public class GetTableByIdQuery : IRequest<TableDto>
    {
        public Guid TableId { get; set; }
    }
}
