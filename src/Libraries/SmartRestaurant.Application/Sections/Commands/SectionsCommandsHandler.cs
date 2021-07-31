using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Sections.Commands
{
    public class SectionsCommandsHandler :
        IRequestHandler<CreateSectionCommand, Created>,
        IRequestHandler<UpdateSectionCommand, NoContent>,
        IRequestHandler<DeleteSectionCommand, NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SectionsCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Created> Handle(CreateSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateSectionCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result); 
            var section = _mapper.Map<Section>(request);
            _context.Sections.Add(section);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(DeleteSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteSectionCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result); 
            var section = await _context.Sections.FindAsync(request.Id).ConfigureAwait(false);
            if (section == null)
                throw new NotFoundException(nameof(Section), request.Id);
            _context.Sections.Remove(section);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(UpdateSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSectionCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result); 
            var section = await _context.Sections.AsNoTracking()
                .FirstOrDefaultAsync(s => s.SectionId == request.Id, cancellationToken)
                .ConfigureAwait(false);
            if (section == null)
                throw new NotFoundException(nameof(Section), request.Id);
            var entity = _mapper.Map<Section>(request);
            _context.Sections.Update(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }
    }
}