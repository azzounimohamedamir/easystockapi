using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.HotelDetailsSections.Queries
{
    
    public class HotelDetailsSectionQueriesHandler :
   
        IRequestHandler<GetHotelDetailsSectionByIdQuery, HotelDetailsSectionDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HotelDetailsSectionQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

     

        public async Task<HotelDetailsSectionDto> Handle(GetHotelDetailsSectionByIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetHotelDetailsSectionByIdQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var section = await _context.HotelDetailsSections.FindAsync(Guid.Parse(request.Id)).ConfigureAwait(false);
            if (section == null)
                throw new NotFoundException(nameof(HotelDetailsSection), request.Id);

            return _mapper.Map<HotelDetailsSectionDto>(section);
        }
    }
}
