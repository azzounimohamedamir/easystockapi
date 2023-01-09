using AutoMapper;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;
using MediatR;


namespace SmartRestaurant.Application.HotelServices.Queries
{
    public class HotelServicesQueriesHandler:
        IRequestHandler<GetAllHotelServicesBySectionIdQuery,List<HotelServiceDto>>,
        IRequestHandler<GetHotelServiceByIdQuery,HotelServiceDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HotelServicesQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<HotelServiceDto>> Handle(GetAllHotelServicesBySectionIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetAllHotelServicesBySectionIdQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var query = await _context.HotelServices.Include(s => s.Parametres).Where(s =>s.SectionId == Guid.Parse(request.HotelSectionId))
                .ToListAsync(cancellationToken).ConfigureAwait(false);
            var data = _mapper.Map<List<HotelServiceDto>>(query);

            for (var i = 0; i < data.Count();)
            {
                for (var j = 0; j < data[i].Parametres.Count();)
                {

                    if (data[i].Parametres[j].ServiceParametreType == Domain.Enums.ServiceParametreType.Listing)
                    {
                        var listing = await _context.Listings.Include(l => l.ListingDetails).Where(l => l.ListingId == data[i].Parametres[j].ListingId).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

                        data[i].Parametres[j].Details =_mapper.Map<List<ListingDetailDto>>( listing.ListingDetails);
                        data[i].Parametres[j].Names = listing.Names;
                        data[i].Parametres[j].WithImage=listing.WithImage;
                    }
                    j++;
                }
                i++;
            }

            return data;
        }

        public async Task<HotelServiceDto> Handle(GetHotelServiceByIdQuery request ,CancellationToken cancellationToken)
        {
            var validator = new GetHotelServiceByIdQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var query = await _context.HotelServices.Include(s => s.Parametres).Where(s => s.Id == Guid.Parse(request.Id))
               .FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

            var data = _mapper.Map<HotelServiceDto>(query);

            for (var j = 0; j < data.Parametres.Count();)
            {

                if (data.Parametres[j].ServiceParametreType == Domain.Enums.ServiceParametreType.Listing)
                {
                    var listing = await _context.Listings.Include(l => l.ListingDetails).Where(l => l.ListingId == data.Parametres[j].ListingId).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

                    data.Parametres[j].Details = _mapper.Map<List<ListingDetailDto>>(listing.ListingDetails);
                    data.Parametres[j].Names = listing.Names;
                    data.Parametres[j].WithImage = listing.WithImage;
                }
                j++;
            }

            return data;
        }
    }
}
