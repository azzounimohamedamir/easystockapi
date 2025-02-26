using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Clients.Commands;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.GestionEmployees.Employees.Clients.Commands
{
    public class ClientCommandsHandler :
        IRequestHandler<CreateClientCommand, Created>,
        IRequestHandler<UpdateClientCommand, NoContent>,
        IRequestHandler<DeleteClientCommand, NoContent>,
      IRequestHandler<AssainirClientCommand, NoContent>

    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ClientCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Created> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateClientCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var emp = _mapper.Map<Domain.Entities.Client>(request);
            emp.IsBanned = false;
            emp.IsDisabled = false;
            emp.TotalCredits = 0;
            if (request.TotalAvances == 0)
            {
                emp.TotalAvances = 0;
            }
            _context.Clients.Add(emp);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteClientCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var cl = await _context.Clients.FindAsync(request.Id).ConfigureAwait(false);
            if (cl == null)
                throw new NotFoundException(nameof(Client), request.Id);


            _context.Clients.Remove(cl);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateClientCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var cl = await _context.Clients.AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken)
                .ConfigureAwait(false);
            if (cl == null)
                throw new NotFoundException(nameof(Client), request.Id);


            var entity = _mapper.Map<Client>(request);
            _context.Clients.Update(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(AssainirClientCommand request, CancellationToken cancellationToken)
        {
            var validator = new AssainirClientCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var cl = await _context.Clients.AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken)
                .ConfigureAwait(false);
            if (cl == null)
                throw new NotFoundException(nameof(Client), request.Id);


            var facturesNotPaidsOfClient = _context.Factures.Where(a => a.Etat == "Non Réglé" && a.ClientId == request.Id).ToList();

            if (facturesNotPaidsOfClient.Count != 0)
            {
                facturesNotPaidsOfClient.ForEach(facture =>
                {
                    facture.RestTotal = 0;
                    facture.Etat = "Reglé par Assainissement";
                    facture.TotalReglement = facture.MontantTotalTTC;
                    _context.Factures.Update(facture).Property(x => x.Numero).IsModified = false;
                    var reglement = new Reglement_Acompte_Facture_Client
                    {
                        Client = cl,
                        Facture = facture,
                        ClientId = cl.Id,
                        Date = DateTime.Now,
                        FactureId = facture.Id,
                        Libelle = "Réglement Par Assainir le client ",
                        Montant = facture.MontantTotalTTC,
                        Type = "Reglement",
                    };
                    _context.Reglement_Acompte_Facture_Clients.Add(reglement);
                    ViderSoldeClient(reglement, cancellationToken);

                }
                );

                var CreanceAsainie = new CreanceAssainie
                {
                    DateAssainissement = DateTime.Now,
                    NomClient = cl.FullName,
                    MontantAssainissement = facturesNotPaidsOfClient.Select(a => a.MontantTotalTTC).Sum(),
                    Motif = "Créance Assainie du Client",
                    AncienCredit = facturesNotPaidsOfClient.Select(a => a.MontantTotalTTC).Sum(),
                    Reste = 0,
                    AssainissementSur = "Factures non réglés du client",
                };
                _context.CreanceAssainies.Add(CreanceAsainie);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }






            cl.IsDisabled = true;
            _context.Clients.Update(cl);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task ViderSoldeClient(Reglement_Acompte_Facture_Client reglement, CancellationToken cancellationToken)
        {

            if (reglement != null)
            {
                if (reglement.Client != null)
                {
                    reglement.Client.TotalCredits = 0;
                    reglement.Client.IsBanned = false;

                }
                _context.Clients.Update(reglement.Client);
            }
        }

    }
}