using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Interfaces;

namespace SmartRestaurant.Application.Images.Queries
{
    public class ImagesQueriesHandler : IRequestHandler<GetImagesByEntityIdQuery, IEnumerable<byte[]>>
    {
        private readonly IApplicationDbContext _context;

        public ImagesQueriesHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<byte[]>> Handle(GetImagesByEntityIdQuery request,
            CancellationToken cancellationToken)
        {
            if (request.EntityId == Guid.Empty)
                throw new InvalidOperationException("Entity Id shouldn't be null or  empty");
            return await _context.FoodBusinessImages.Where(f => f.EntityId == request.EntityId)
                .Select(im => im.ImageBytes).ToArrayAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}