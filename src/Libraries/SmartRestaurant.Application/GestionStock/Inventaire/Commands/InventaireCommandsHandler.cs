using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using SmartRestaurant.Application.Common.Exceptions;

using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Application.GestionStock.Inventaire.Commands;
using SmartRestaurant.Application.GestionStock.Stock.Commands;
using SmartRestaurant.Application.Stock.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;
using ValidationException = SmartRestaurant.Application.Common.Exceptions.ValidationException;

namespace SmartRestaurant.Application.Stock.Commands
{
    public class InventaireCommandsHandler :
        IRequestHandler<CreateInventaireParEquipeCommand, Created>,
        IRequestHandler<ValiderInventaireCommand, NoContent>,
        IRequestHandler<ReglerEcartsInventaireCommand, NoContent>,
        IRequestHandler<ResetInventaireCommand, NoContent>


    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public InventaireCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Created> Handle(CreateInventaireParEquipeCommand request, CancellationToken cancellationToken)
        {

            
            var validator = new CreateInventaireParEquipeCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            
             
            // ajouter l'invetaire equipe
            var inventaireEquipe = _mapper.Map<Domain.Entities.InventaireEquipe>(request);
            _context.InventaireEquipes.Add(inventaireEquipe);

            // ajouter toutes les lignes d'inventaire de l'équipe
            request.Lignes.ForEach(ligne =>
            {
                _context.LignesInventaireEquipes.Add(ligne);
            }
            );






            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            var invEquipeCount = _context.InventaireEquipes.Count();

            if(invEquipeCount == 2)
            {
                var lignesInventaireFinalList = _context.LignesInventaireEquipes.ToList()
    .GroupBy(l => new { l.CodeProduit, l.NomProduit, l.Rayonnage, l.CodeBar })
    .Select(g => new LignesInventaireFinal
    {
        Id = Guid.NewGuid(), // Générez un nouvel ID unique si nécessaire
        CodeProduit = g.Key.CodeProduit,
        NomProduit = g.Key.NomProduit,
        Rayonnage = g.Key.Rayonnage,
        CodeBar = g.Key.CodeBar,
        QuantiteTrouveeA = g.FirstOrDefault(e => e.Equipe == Equipe.A)?.QuantiteTrouvee ?? 0,
        QuantiteTrouveeB = g.FirstOrDefault(e => e.Equipe == Equipe.B)?.QuantiteTrouvee ?? 0,
        QuantiteTrouveeReel = 0,
        QuantiteStockLogiciel = _context.Stocks.Where(s => s.CodeP == g.Key.CodeProduit).Select(s=>s.QteRestante).FirstOrDefault(),
        QteEcart = 0,
        Manque =false,
        Surnombre = false,
        Egaux = false,
        Observation = "" // Ajoutez la logique d'observation si nécessaire
    })
    .ToList();
                foreach (var ligne in lignesInventaireFinalList)
                {
                   
                        var stock = _context.Stocks
                            .FirstOrDefault(s => s.Id.ToString() == ligne.CodeProduit);


                        if (stock != null)
                        {
                            ligne.QuantiteStockLogiciel = stock.QteRestante;
                            _context.LignesInventaireFinals.Add(ligne);
                        }
                    
                };
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

               




            }
            return default;
        }

     
        //    public async Task<NoContent> Handle(DeleteProductFromStockCommand request, CancellationToken cancellationToken)
        //{
        //    var validator = new DeleteProductFromStockCommandValidator();
        //    var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
        //    if (!result.IsValid) throw new ValidationException(result);

        //    var menu = await _context.Stocks.FindAsync(request.Id).ConfigureAwait(false);
        //    if (menu == null)
        //        throw new NotFoundException(nameof(Stock), request.Id);
        //    _context.Stocks.Remove(menu);
        //    await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        //    return default;
        //}

        public async Task<NoContent> Handle(ValiderInventaireCommand request, CancellationToken cancellationToken)
        {
            //var validator = new ValiderInventaireCommandValidator();
            //var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            //if (!result.IsValid) throw new ValidationException(result);

            //var product = await _context.Stocks.AsNoTracking()
            //    .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken)
            //    .ConfigureAwait(false);
            //if (product == null)
            //    throw new NotFoundException(nameof(Stock), request.Id);
            //if(request.IsPerissable == false)
            //{
            //    request.DatePeremption = DateTime.Now;
            //    request.JourAlerte = 0;
            //}

            //var entity = _mapper.Map<Domain.Entities.Stock>(request);
            //_context.Stocks.Update(entity);
            //await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(ReglerEcartsInventaireCommand request, CancellationToken cancellationToken)
        {
            var validator = new ReglerEcartsInventaireCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            request.Ecarts.ForEach(ligne =>
            {
                var entityAttached = _context.LignesInventaireFinals.FirstOrDefault(c=>c.CodeProduit== ligne.CodeProduit);
                    entityAttached.QuantiteTrouveeReel = ligne.QuantiteTrouveeReel;
                if (entityAttached.QuantiteStockLogiciel >= 0)
                {
                    if (entityAttached.QuantiteStockLogiciel > entityAttached.QuantiteTrouveeReel)
                    {
                        entityAttached.QteEcart = entityAttached.QuantiteTrouveeReel - entityAttached.QuantiteStockLogiciel;
                        entityAttached.Manque = true;
                        entityAttached.Surnombre = false;
                        entityAttached.Egaux = false;
                        entityAttached.Observation = "Manque (" + entityAttached.QteEcart + " )";
                    }
                    if (entityAttached.QuantiteStockLogiciel < entityAttached.QuantiteTrouveeReel)
                    {
                        entityAttached.QteEcart = (entityAttached.QuantiteTrouveeReel) - entityAttached.QuantiteStockLogiciel;
                        entityAttached.Manque = false;
                        entityAttached.Surnombre = true;
                        entityAttached.Egaux = false;
                        entityAttached.Observation = "Surnombre (" + entityAttached.QteEcart + " )"; ;
                    }
                    if (entityAttached.QuantiteStockLogiciel == entityAttached.QuantiteTrouveeReel)
                    {
                        entityAttached.QteEcart = 0;
                        entityAttached.Manque = false;
                        entityAttached.Surnombre = false;
                        entityAttached.Egaux = true;
                        entityAttached.Observation = "Bon Etat ";
                    }
                }
                else
                {
                    entityAttached.QteEcart = -1;
                    entityAttached.Manque = false;
                    entityAttached.Surnombre = false;
                    entityAttached.Egaux = false;
                    entityAttached.Observation = "Stock Négative , Calcul de stock faux , erreur de saisie ...etc ";
                }
                   _context.LignesInventaireFinals.Update(entityAttached);
            }
            );

            // Retrieve records with no corresponding Ecarts from the database
            var recordsWithNoEcarts = _context.LignesInventaireFinals
                .ToList() // Retrieve all records from the database
                .Where(ligne => !request.Ecarts.Any(ecart => ecart.CodeProduit == ligne.CodeProduit))
                .ToList(); // Perform the filtering in-memory

            recordsWithNoEcarts.ForEach(entity =>
            {
                entity.QuantiteTrouveeReel = entity.QuantiteTrouveeA;
                entity.QteEcart = 0;
                entity.Manque = false;
                entity.Surnombre = false;
                entity.Egaux = true;
                entity.Observation = "Bon Etat ";
                _context.LignesInventaireFinals.Update(entity);
            });
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // enfin remplir inventaire 

            var lignesInventaireValide = _context.LignesInventaireFinals.ToList();

            var existInv = _context.Inventaires.Count();

            if (existInv == 0)
            {
                var inventaire = new Inventaire()
                {
                    Id = Guid.NewGuid().ToString(),
                    Date = DateTime.Now,
                    LignesInventaire = lignesInventaireValide,
                    TotalProduitsEnManque = lignesInventaireValide.Count(a => a.Manque == true),
                    TotalProduitsEnSurnombre = lignesInventaireValide.Count(a => a.Surnombre == true),
                    TotalProduitsInventaire = lignesInventaireValide.Count(),
                    Annuel = true,
                    Trimestre = 1,
                };
                _context.Inventaires.Add(inventaire);
            }
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);





            // ajouter l'inventaire 




            return default;
        }



        public async Task<NoContent> Handle(ResetInventaireCommand request, CancellationToken cancellationToken)
        {
            var validator = new ResetInventaireCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            if(request.Equipe == Equipe.A)
            {
                var deletedLignesInvEquipeA = _context.LignesInventaireEquipes.Where(e=>e.Equipe==Equipe.A).ToList();
                if (deletedLignesInvEquipeA.Count != 0)

                    _context.LignesInventaireEquipes.RemoveRange(deletedLignesInvEquipeA);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                var deleteInvEquipeA = _context.InventaireEquipes.Where(e => e.Equipe == Equipe.A).FirstOrDefault();
                if (deleteInvEquipeA != null)

                    _context.InventaireEquipes.Remove(deleteInvEquipeA);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }

            if(request.Equipe==Equipe.B)
            {
                var deletedLignesInvEquipeB = _context.LignesInventaireEquipes.Where(e => e.Equipe == Equipe.B).ToList();

                if(deletedLignesInvEquipeB.Count !=0)
                _context.LignesInventaireEquipes.RemoveRange(deletedLignesInvEquipeB);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                    var deleteInvEquipeB = _context.InventaireEquipes.Where(e => e.Equipe == Equipe.B).FirstOrDefault();
                if (deleteInvEquipeB != null)

                    _context.InventaireEquipes.Remove(deleteInvEquipeB);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                var lignesFinalRemoved = _context.LignesInventaireFinals.ToList();
                if(lignesFinalRemoved.Count!=0)
                _context.LignesInventaireFinals.RemoveRange(lignesFinalRemoved);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                var inv = _context.Inventaires.ToList();
                if(inv.Count!=0)
                _context.Inventaires.RemoveRange(inv);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }





            return default;
        }

    }
}