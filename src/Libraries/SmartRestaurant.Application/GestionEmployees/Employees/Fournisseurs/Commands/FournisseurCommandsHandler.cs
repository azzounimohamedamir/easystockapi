using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Clients.Commands;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.GestionEmployees.Employees.Fournisseurs.Commands
{
    public class FournisseurCommandsHandler :
        IRequestHandler<CreateFournisseurCommand, Created>,
        IRequestHandler<UpdateFournisseurCommand, NoContent>,
        IRequestHandler<DeleteFournisseurCommand, NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FournisseurCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Created> Handle(CreateFournisseurCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateFournisseurCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var emp = _mapper.Map<Fournisseur>(request);
            
             
            _context.Fournisseurs.Add(emp);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(DeleteFournisseurCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteFournisseurCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var fr = await _context.Fournisseurs.FindAsync(request.Id).ConfigureAwait(false);
            if (fr == null)
                throw new NotFoundException(nameof(Fournisseur), request.Id);

           
            _context.Fournisseurs.Remove(fr);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(UpdateFournisseurCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateFournisseurCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var fr = await _context.Fournisseurs.AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken)
                .ConfigureAwait(false);
            if (fr == null)
                throw new NotFoundException(nameof(Fournisseur), request.Id);


            var entity = _mapper.Map<Fournisseur>(request);
            _context.Fournisseurs.Update(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

    }
}