using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.ProgrammeFidelite.Commands
{
    public class FideliteCommandsHandler :
        IRequestHandler<AjouterNivFideliteCommand, Created>,
        IRequestHandler<UpdateNivFideliteCommand, NoContent>,
        IRequestHandler<UpdatePointFideliteClientCommand, ClientFidelite>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FideliteCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Created> Handle(AjouterNivFideliteCommand request, CancellationToken cancellationToken)
        {
            var validator = new AjouterNivFideliteCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var niveau = _mapper.Map<Domain.Entities.NiveauFidelite>(request);
            _context.NiveauFidelites.Add(niveau);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<ClientFidelite> Handle(UpdatePointFideliteClientCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdatePointFideliteClientCommandValidator();


            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);


            var client = await _context.Clients.FindAsync(request.ClientId).ConfigureAwait(false);

            var clientFid = await _context.ClientFidelites.FindAsync(request.ClientId).ConfigureAwait(false);

            var config = _context.DefaultConfigLogs.FirstOrDefault();
            bool accepted = (int)Math.Floor(request.MontantFacture * (config.PointsGagner) / config.SommeFacture) <config.MinimumPointsToWithdraw;
     // Use Any() to check if any records match the criteria

            // result will be true if there is at least one matching record, otherwise false
            if (accepted)
            {
                if (clientFid == null)
                {



                    ClientFidelite nouveauClientFidele = new Domain.Entities.ClientFidelite
                    {
                        DateInscription = DateTime.Now,
                        Email = client.Email,
                        Points = (int)Math.Floor(request.MontantFacture * (config.PointsGagner) / config.SommeFacture),
                        Nom = client.FullName,
                        Id = client.Id

                        ,
                        Withdraw = ((int)Math.Floor(request.MontantFacture * (config.PointsGagner) / config.SommeFacture)) < config.MinimumPointsToWithdraw ? 0 : config.Recompense

                    };

                    _context.ClientFidelites.Add(nouveauClientFidele);
                    await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);


                    return nouveauClientFidele;

                }
                else
                {
                   
                    clientFid.Points += (int)Math.Floor(request.MontantFacture * config.PointsGagner / config.SommeFacture);
                    clientFid.Withdraw = clientFid.Points < config.MinimumPointsToWithdraw ? 0 : config.Recompense;
                _context.ClientFidelites.Update(clientFid);
                    await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                    return clientFid;
                }
            }
            else
            {
                return default;
            }
        }







        public async Task<NoContent> Handle(UpdateNivFideliteCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateNivFideliteCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var niveau = await _context.NiveauFidelites.AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken)
                .ConfigureAwait(false);
            if (niveau == null)
                throw new NotFoundException(nameof(NiveauFidelite), request.Id);


            var entity = _mapper.Map<Domain.Entities.NiveauFidelite>(request);
            _context.NiveauFidelites.Update(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

    }
}