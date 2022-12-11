using AutoMapper;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Extensions;
using System.Threading.Tasks;
using System.Threading;
using MediatR;

namespace SmartRestaurant.Application.ListingDetails.Queries
{
    public class ListingDetailsQuerisHandler:IRequestHandler<GetListingDetailByIdQuery,ListingDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public ListingDetailsQuerisHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ListingDetailDto> Handle(GetListingDetailByIdQuery request,CancellationToken cancellationToken)
        {
            var validator = new GetListingDetailByIdQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var listingDetail = await _context.ListingDetails
            .Where(u => u.Id == Guid.Parse(request.Id))
            .FirstOrDefaultAsync()
            .ConfigureAwait(false);
            if (listingDetail == null)
                throw new NotFoundException(nameof(listingDetail), request.Id);
            var listingDetailDto = _mapper.Map<ListingDetailDto>(listingDetail);
            return listingDetailDto;
        }
    }
}
