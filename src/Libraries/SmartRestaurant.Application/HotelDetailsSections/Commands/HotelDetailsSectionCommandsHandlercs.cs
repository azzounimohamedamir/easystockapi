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
using SmartRestaurant.Application.Products.Commands;

namespace SmartRestaurant.Application.HotelDetailsSections.Commands
{
    public class HotelDetailsSectionCommandsHandlercs :
        IRequestHandler<CreateHotelDetailsSectionCommand, Created>,
        IRequestHandler<UpdateHotelDetailsSectionCommand, NoContent>,
        IRequestHandler<DeleteHotelDetailsSectionCommand, NoContent>

    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HotelDetailsSectionCommandsHandlercs(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Created> Handle(CreateHotelDetailsSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateHotelDetailsSectionCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var section = _mapper.Map<HotelDetailsSection>(request);
            using (var ms = new MemoryStream())
            {
                request.Picture.CopyTo(ms);
                section.Picture = ms.ToArray();
            }
            _context.HotelDetailsSections.Add(section);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(UpdateHotelDetailsSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateHotelDetailsSectionCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var section = await _context.HotelDetailsSections.AsNoTracking()
                .FirstOrDefaultAsync(s => s.HotelDetailsSectionId == Guid.Parse(request.hotelSetionId), cancellationToken)
                .ConfigureAwait(false);
            if (section == null)
                throw new NotFoundException(nameof(HotelDetailsSection), request.hotelSetionId);
            var entity = _mapper.Map<HotelDetailsSection>(request);
            using (var ms = new MemoryStream())
            {
                request.Picture.CopyTo(ms);
                entity.Picture = ms.ToArray();
            }
            _context.HotelDetailsSections.Update(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(DeleteHotelDetailsSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteHotelDetailsSectionCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var section = await _context.HotelDetailsSections.AsNoTracking().FirstOrDefaultAsync(r => r.HotelDetailsSectionId == Guid.Parse(request.Id), cancellationToken).ConfigureAwait(false);
            if (section == null)
                throw new NotFoundException(nameof(HotelDetailsSection), request.Id);

            _context.HotelDetailsSections.Remove(section);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }
    }
}
