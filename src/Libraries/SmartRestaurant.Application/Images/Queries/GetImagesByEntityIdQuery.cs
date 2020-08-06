using System;
using System.Collections.Generic;
using MediatR;

namespace SmartRestaurant.Application.Images.Queries
{
    public class GetImagesByEntityIdQuery : IRequest<IEnumerable<byte[]>>
    {
        public Guid EntityId { get; set; }
    }
}
