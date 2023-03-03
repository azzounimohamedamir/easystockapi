using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.TypeReclamation.Commands
{
    public class TypeReclamationCommandsHandler :
        IRequestHandler<CreateTypeReclamationCommand, Created>,
        IRequestHandler<UpdateTypeReclamationCommand, NoContent>,
        IRequestHandler<DeleteTypeReclamationCommand, NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TypeReclamationCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Created> Handle(CreateTypeReclamationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateTypeReclamationCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var typeReclamation = _mapper.Map<Domain.Entities.TypeReclamation>(request);
            _context.TypeReclamations.Add(typeReclamation);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(DeleteTypeReclamationCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteSectionCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var typeReclamation = await _context.TypeReclamations.FindAsync(request.Id).ConfigureAwait(false);
            if (typeReclamation == null)
                throw new NotFoundException(nameof(Domain.Entities.TypeReclamation), request.Id);
            _context.TypeReclamations.Remove(typeReclamation);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(UpdateTypeReclamationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTypeReclamationCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var typereclamation = await _context.TypeReclamations.AsNoTracking()
                .FirstOrDefaultAsync(s => s.TypeReclamationId == request.Id, cancellationToken)
                .ConfigureAwait(false);
            if (typereclamation == null)
                throw new NotFoundException(nameof(Domain.Entities.TypeReclamation), request.Id);
            var entity = _mapper.Map<Domain.Entities.TypeReclamation>(request);
            _context.TypeReclamations.Update(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

      
    }
}