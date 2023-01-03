using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using MediatR;
using AutoMapper;
using System.Threading.Tasks;
using System.Threading;
using SmartRestaurant.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;


namespace SmartRestaurant.Application.ListingDetails.Commands
{
    public class ListingDetailCommandHandler:IRequestHandler<CreateListingDetailCommand,Created>
        ,IRequestHandler<DeleteListingDetailCommand,NoContent>
        ,IRequestHandler<UpdateListingDetailCommand,NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ListingDetailCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Created> Handle(CreateListingDetailCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateListingDetailCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var listingDetail = _mapper.Map<ListingDetail>(request);
            if (request.Picture != null){
                using (var ms = new MemoryStream())
                {
                    request.Picture.CopyTo(ms);
                    listingDetail.Picture = ms.ToArray();
                };
            }
      
            _context.ListingDetails.Add(listingDetail);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;

        }

        public async Task<NoContent> Handle(UpdateListingDetailCommand request,CancellationToken cancellationToken)
        {
            var validator = new UpdateListingDetailCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var entity = await _context.ListingDetails.AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken)
                .ConfigureAwait(false);
            if (entity == null)
                throw new NotFoundException(nameof(HotelSection), request.Id);

            var editedDetail = _mapper.Map<ListingDetail>(request);
            if (request.Picture != null)
            {
                using (var ms = new MemoryStream())
                {
                    request.Picture.CopyTo(ms);
                    editedDetail.Picture = ms.ToArray();
                };
            }

            _context.ListingDetails.Update(editedDetail);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(DeleteListingDetailCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteListingDetailCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var entity = await _context.ListingDetails.FindAsync(request.Id).ConfigureAwait(false);

            if (entity == null)
                throw new NotFoundException(nameof(Listings), request.Id);

            _context.ListingDetails.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return default;
        }
    }
}
