using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using MediatR;
using AutoMapper;
using System.Threading.Tasks;
using System.Threading;
using SmartRestaurant.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace SmartRestaurant.Application.Listings.Commands
{
    public class ListingCommandHandler : IRequestHandler<CreateListingCommand, Created>
        , IRequestHandler<UpdateListingCommand, NoContent>,
        IRequestHandler<DeleteListingCommand, NoContent>

    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ListingCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<Created> Handle(CreateListingCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateListingCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var newlisting = _mapper.Map<Listing>(request);
            _context.Listings.Add(newlisting);
            await _context.SaveChangesAsync(cancellationToken);
            return default;
        }

    

        public async Task<NoContent> Handle(UpdateListingCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateListingCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var entity = await _context.Listings.AsNoTracking()
               .FirstOrDefaultAsync(s => s.ListingId == request.ListingId, cancellationToken)
               .ConfigureAwait(false);
            if (entity == null)
                throw new NotFoundException(nameof(HotelSection), request.Id);

            var editedlisting = _mapper.Map<Listing>(request);
            _context.Listings.Update(editedlisting);
            await _context.SaveChangesAsync(cancellationToken);
            return default;
        }


        public async Task<NoContent> Handle(DeleteListingCommand request,
          CancellationToken cancellationToken)
        {
            var validator = new DeleteListingCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var entity = await _context.Listings.FindAsync(request.Id).ConfigureAwait(false);

            if (entity == null)
                throw new NotFoundException(nameof(Listings), request.Id);

            _context.Listings.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return default;
        }
    }
}
