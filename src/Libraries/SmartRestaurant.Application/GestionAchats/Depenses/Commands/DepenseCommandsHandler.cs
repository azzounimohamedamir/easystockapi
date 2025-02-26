using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Depenses.Commands
{
    public class DepenseCommandsHandler :
        IRequestHandler<CreateDepenseCommand, Created>,
        IRequestHandler<UpdateDepenseCommand, NoContent>,
        IRequestHandler<DeleteDepenseCommand, NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DepenseCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Created> Handle(CreateDepenseCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateDepenseCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var dep = _mapper.Map<Domain.Entities.Depense>(request);
            _context.Depenses.Add(dep);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(DeleteDepenseCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteDepenseCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var dep = await _context.Depenses.FindAsync(request.Id).ConfigureAwait(false);
            if (dep == null)
                throw new NotFoundException(nameof(Depense), request.Id);
            _context.Depenses.Remove(dep);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(UpdateDepenseCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateDepenseCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var dep = await _context.Depenses.AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken)
                .ConfigureAwait(false);
            if (dep == null)
                throw new NotFoundException(nameof(Depense), request.Id);


            var entity = _mapper.Map<Domain.Entities.Depense>(request);
            _context.Depenses.Update(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

    }
}