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

namespace SmartRestaurant.Application.HotelSections.Commands
{
    public class HotelSectionCommandsHandlercs :
        IRequestHandler<CreateHotelSectionCommand, Created>,
        IRequestHandler<UpdateHotelSectionCommand, NoContent>,
        IRequestHandler<DeleteHotelSectionCommand, NoContent>

    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HotelSectionCommandsHandlercs(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Created> Handle(CreateHotelSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateHotelSectionCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var section = _mapper.Map<HotelSection>(request);
            using (var ms = new MemoryStream())
            {
                request.Picture.CopyTo(ms);
                section.Picture = ms.ToArray();
            }
            _context.HotelSections.Add(section);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(UpdateHotelSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateHotelSectionCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var section = await _context.HotelSections.AsNoTracking()
                .FirstOrDefaultAsync(s => s.HotelSectionId == Guid.Parse(request.hotelSetionId), cancellationToken)
                .ConfigureAwait(false);
            if (section == null)
                throw new NotFoundException(nameof(HotelSection), request.hotelSetionId);
            var entity = _mapper.Map<HotelSection>(request);
            using (var ms = new MemoryStream())
            {
                request.Picture.CopyTo(ms);
                entity.Picture = ms.ToArray();
            }
            _context.HotelSections.Update(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(DeleteHotelSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteHotelSectionCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var section = await _context.HotelSections.AsNoTracking().FirstOrDefaultAsync(r => r.HotelSectionId == Guid.Parse(request.Id), cancellationToken).ConfigureAwait(false);
            if (section == null)
                throw new NotFoundException(nameof(HotelSection), request.Id);

            _context.HotelSections.Remove(section);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }
    }
}
