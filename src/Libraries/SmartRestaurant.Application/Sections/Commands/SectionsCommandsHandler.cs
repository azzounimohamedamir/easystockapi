using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.Results;
using MediatR;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Sections.Commands
{
    public class SectionsCommandsHandler :
        IRequestHandler<CreateSectionCommand, ValidationResult>,
        IRequestHandler<UpdateSectionCommand, ValidationResult>,
        IRequestHandler<DeleteSectionCommand, ValidationResult>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SectionsCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ValidationResult> Handle(CreateSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateSectionCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) return result;
            var section = _mapper.Map<Section>(request);
            _context.Sections.Add(section);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<ValidationResult> Handle(DeleteSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteSectionCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) return result;
            var section = await _context.Sections.FindAsync(request.CmdId).ConfigureAwait(false);
            if (section == null)
                throw new NotFoundException(nameof(Section), request.CmdId);
            _context.Sections.Remove(section);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<ValidationResult> Handle(UpdateSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSectionCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) return result;
            var section = await _context.Sections.FindAsync(request.CmdId).ConfigureAwait(false);
            if (section == null)
                throw new NotFoundException(nameof(Section), request.CmdId);
            section.Name = request.Name;
            section.MenuId = request.MenuId;
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }
    }
}