using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.Results;
using MediatR;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.SubSections.Commands
{
    public class SubSectionsCommandsHandler :
        IRequestHandler<CreateSubSectionCommand, ValidationResult>,
        IRequestHandler<UpdateSubSectionCommand, ValidationResult>,
        IRequestHandler<DeleteSubSectionCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SubSectionsCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ValidationResult> Handle(CreateSubSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateSubSectionCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) return result;
            var subSection = _mapper.Map<SubSection>(request);
            _context.SubSections.Add(subSection);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<Unit> Handle(DeleteSubSectionCommand request, CancellationToken cancellationToken)
        {
            var subSection = await _context.SubSections.FindAsync(request.SubSectionId).ConfigureAwait(false);
            if (subSection == null)
                throw new NotFoundException(nameof(subSection), request.SubSectionId);
            _context.SubSections.Remove(subSection);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<ValidationResult> Handle(UpdateSubSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSubSectionCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) return result;
            var subSection = await _context.SubSections.FindAsync(request.CmdId).ConfigureAwait(false);
            if (subSection == null)
                throw new NotFoundException(nameof(subSection), request.CmdId);
            subSection.Name = request.Name;
            subSection.SectionId = request.SectionId;
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }
    }
}