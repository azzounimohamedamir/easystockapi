﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.WebResults;
using System.Threading;
using System.Threading.Tasks;
using ValidationException = SmartRestaurant.Application.Common.Exceptions.ValidationException;

namespace SmartRestaurant.Application.GestionVentes.Caisses.Commands
{
    public class CaisseCommandsHandler :
        IRequestHandler<CreateCaisseCommand, Created>,
        IRequestHandler<UpdateCaisseCommand, NoContent>,
        IRequestHandler<DeleteCaisseCommand, NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CaisseCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Created> Handle(CreateCaisseCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCaisseCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var caisse = _mapper.Map<Domain.Entities.Caisses>(request);
            _context.Caisses.Add(caisse);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }




        public async Task<NoContent> Handle(DeleteCaisseCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteCaisseCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var caisse = await _context.Caisses
                .FirstOrDefaultAsync(v => v.Id == request.Id.ToString(), cancellationToken)
                .ConfigureAwait(false);

            if (caisse == null)
                throw new NotFoundException(nameof(Caisses), request.Id);

            _context.Caisses.Remove(caisse);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return default;
        }

        public async Task<NoContent> Handle(UpdateCaisseCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCaisseCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var cs = await _context.Caisses
                .FirstOrDefaultAsync(m => m.Id == request.Id.ToString(), cancellationToken)
                .ConfigureAwait(false);

            if (cs == null)
                throw new NotFoundException(nameof(cs), request.Id);
            cs.Vendeur = request.Vendeur;
            cs.Status = request.Status;
            cs.Numero = request.Numero;
            cs.SoldeJ = request.SoldeJ;
            cs.SoldeM = request.SoldeM;
            _context.Caisses.Update(cs);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }





    }
}