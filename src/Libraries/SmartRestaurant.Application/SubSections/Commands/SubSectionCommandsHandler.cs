using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.SubSections.Commands
{
    public class SubSectionsCommandsHandler :
        IRequestHandler<CreateSubSectionCommand, Created>,
        IRequestHandler<UpdateSubSectionCommand, NoContent>,
        IRequestHandler<DeleteSubSectionCommand, NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SubSectionsCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Created> Handle(CreateSubSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateSubSectionCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var subSection = _mapper.Map<SubSection>(request);
            _context.SubSections.Add(subSection);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(DeleteSubSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteSubSectionCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var subSection = await _context.SubSections.FindAsync(request.Id).ConfigureAwait(false);
            if (subSection == null)
                throw new NotFoundException(nameof(subSection), request.Id);
            _context.SubSections.Remove(subSection);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(UpdateSubSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSubSectionCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var subSection = await _context.SubSections.AsNoTracking()
                .FirstOrDefaultAsync(s => s.SubSectionId == request.Id, cancellationToken)
                .ConfigureAwait(false);
            if (subSection == null)
                throw new NotFoundException(nameof(subSection), request.Id);
            subSection = _mapper.Map<SubSection>(request);
            _context.SubSections.Update(subSection);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }
    }
}