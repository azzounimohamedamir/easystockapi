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
using Newtonsoft.Json;

using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using SmartRestaurant.Application.Common.Exceptions;

using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Application.GestionVentes.VenteComptoir.Commands;
using SmartRestaurant.Application.Stock.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;
using ValidationException = SmartRestaurant.Application.Common.Exceptions.ValidationException;
using SmartRestaurant.Application.GestionVentes.VenteParBl.Commands;
using static System.Net.WebRequestMethods;
using SmartRestaurant.Application.GestionVentes.VenteParFac.Commands;

namespace SmartRestaurant.Application.GestionAchats.BonsAchat.Commands
{
    public class BACommandsHandler :
        IRequestHandler<CreateBACommand, Created>,
        IRequestHandler<AjouterRegAcompteBACommand, Created>,

        IRequestHandler<UpdateBACommand, NoContent>,
        IRequestHandler<DeleteBACommand, NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BACommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public string GenerateCodeBA()
        {
            const string codeBCprefix = "BA";
            const int codeBCLength = 6;

            // Format Numero as a string with leading zeros
            string formattedNumero = GetNextInvoiceNumberFromDatabase().ToString($"D{codeBCLength - 1}");

            // Concatenate the prefix and formatted Numero
            return $"{codeBCprefix}{formattedNumero}";
        }

        private int GetNextInvoiceNumberFromDatabase()
        {
            // Retrieve the current invoice number from the database
            // This could involve querying the database or using a dedicated service to manage invoice numbers
            // In this example, let's assume you have a method to retrieve the next sequential number
            // You may need to implement this based on your database structure and business rules
            // For simplicity, I'm using a placeholder value here
            if (_context.BonAchats.Count() == 0) return 1;
            else
                return _context.BonAchats.Max(f => f.Numero) + 1;
        }

        public async Task<Created> Handle(CreateBACommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateBACommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var fr = _context.Fournisseurs.FirstOrDefault(c => c.Id == request.FournisseurId);
            var bonachat = new Domain.Entities.BonAchats()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Heure = DateTime.Now.ToShortTimeString(),
                VendeurId = Guid.NewGuid(), // Fix to generate a new Guid
                CodeBA = GenerateCodeBA(),
                CreatedBy = request.CreatedBy,
                MontantTotalHT = request.MontantTotalHT,
                MontantTotalTTC = request.MontantTotalTTC,
                MontantTotalTVA = request.MontantTotalTVA,
                FournisseurId = request.FournisseurId,
                Fournisseur = fr,
                TotalReglement = request.TotalReglement,
                Numero = request.Numero,
                Timbre = request.Timbre,
                DateEcheance = request.DateEcheance,
                DateFermuture = request.DateFermuture,
                Etat = request.Etat,
                PaymentMethod = request.PaymentMethod,
                Remise = request.Remise,
                MontantTotalHTApresRemise = request.MontantTotalHTApresRemise,
                RestTotal = request.RestTotal,
                Rib = request.Rib,
                Rip = request.Rip,
            };

            _context.BonAchats.Add(bonachat);

            var configLog = _context.DefaultConfigLogs.FirstOrDefault();

            foreach (var item in request.BAProducts)
            {
                var stockMatch = _context.Stocks.AsNoTracking().FirstOrDefault(u => u.Designaation == item.Designation);

                var bcp = new BAProducts
                {
                    BAId = bonachat.Id,
                    Newpua = item.Newpua,
                    Pmp = item.Pmp,
                    Designation = item.Designation,
                    Qte = item.Qte,
                    MontantHT = item.MontantHT,
                    MontantTTC = item.MontantTTC,
                    MontantTVA = item.MontantTVA,
                    Pua = item.Pua,
                    Image = stockMatch?.Image,
                    SelectedStock = stockMatch,
                    SelectedStockId = stockMatch.Id,
                };

                _context.BAProducts.Add(bcp);

                await AlimenterStock(bcp, cancellationToken);

                var mvt = new MouvementStock
                {
                    DateMvt = bonachat.Date,
                    ProduitId = stockMatch.Id,
                    ProduitName = stockMatch.Designaation,
                    Qte = bcp.Qte,
                    TypeMouvement = TypeMouv.Entree
                };

                _context.MouvementStocks.Add(mvt);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                var existingStock = _context.Stocks.Local.FirstOrDefault(u => u.Designaation == item.Designation);

                if (existingStock != null && configLog != null)
                {
                    existingStock.PrixAchat = configLog.PrixAchatMoyPondere ? item.Pmp : item.Newpua;
                    var margBenifDetail = (decimal.Parse(configLog.MargeBenifDetail)) / 100 * existingStock.PrixAchat;
                    var margBenifGros = (decimal.Parse(configLog.MargeBenifGros)) / 100 * existingStock.PrixAchat;

                    existingStock.PrixVenteDetail = Math.Round(existingStock.PrixAchat + margBenifDetail);
                    existingStock.PrixVenteGros = Math.Round(existingStock.PrixAchat + margBenifGros);
                }

                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }

            return new Created(); // Adjust according to your actual return type
        }

        public async Task AlimenterStock(BAProducts bap, CancellationToken cancellationToken)
        {
            var stockedProduct = _context.Stocks.FirstOrDefault(p => p.Designaation == bap.Designation);
            if (stockedProduct != null)
            {
                stockedProduct.PrixAchat = bap.Pua;
                stockedProduct.QteRestante += bap.Qte;
                _context.Stocks.Update(stockedProduct);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
        }










        public async Task<NoContent> Handle(DeleteBACommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteBACommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var bon =  _context.BonAchats.Include(v=>v.BAProducts).FirstOrDefault();
            if (bon == null)
                throw new NotFoundException(nameof(BonAchats), request.Id);

            _context.BonAchats.Remove(bon);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(UpdateBACommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBACommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var bonToUpdate = await _context.BonAchats
                .Include(vp => vp.BAProducts)
                .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken)
                .ConfigureAwait(false);

            if (bonToUpdate == null)
                throw new NotFoundException(nameof(Domain.Entities.BonAchats), request.Id);

           

            // Remove old products included in vc
            _context.BAProducts.RemoveRange(bonToUpdate.BAProducts);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // Add new products included in request
            foreach (var item in request.BAProducts)
            {
                var stockMatch = _context.Stocks
                    .Where(u => u.Designaation == item.Designation)
                    .FirstOrDefault();

                var flp = new BAProducts
                {
                    BAId = request.Id,
                    Designation = item.Designation,
                    Qte = item.Qte,
                    MontantTTC = item.MontantTTC,
                    MontantHT= item.MontantHT,
                    MontantTVA= item.MontantTVA,
                    Pua = item.Pua,
                    Image = stockMatch.Image,
                    SelectedStockId = stockMatch.Id,
                    SelectedStock = stockMatch
                };
                _context.BAProducts.Add(flp);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }

            // Update old vente Comptoir with the new values

            var entity = _mapper.Map<Domain.Entities.BonAchats>(request);

            bonToUpdate.MontantTotalHT = request.MontantTotalHT;
            bonToUpdate.MontantTotalTVA = request.MontantTotalTVA;
            bonToUpdate.MontantTotalTTC = request.MontantTotalTTC;
            bonToUpdate.Fournisseur=request.Fournisseur;
            bonToUpdate.Heure=request.Heure;
            bonToUpdate.Date=request.Date;
            bonToUpdate.CreatedBy = request.CreatedBy;
            bonToUpdate.Numero=request.Numero;
            bonToUpdate.VendeurId=request.VendeurId;
            bonToUpdate.FournisseurId=request.FournisseurId;
            bonToUpdate.Timbre=request.Timbre;
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return default;
        }



        public async Task<Created> Handle(AjouterRegAcompteBACommand request, CancellationToken cancellationToken)
        {
            var validator = new AjouterRegAcompteBACommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var ba = _context.BonAchats.Where(f => f.Id == request.BAId).FirstOrDefault();
            var fournisseur = _context.Fournisseurs.Where(f => f.Id == request.FournisseurId).FirstOrDefault();


            if (request.Type == "Acompte")
            {
                ba.RestTotal = ba.RestTotal - request.Montant;

                ba.TotalReglement = ba.TotalReglement + request.Montant;
                if (ba.RestTotal <= 0)
                {
                    ba.Etat = "Acheté";
                }

                _context.BonAchats.Update(ba).Property(x => x.Numero).IsModified = false;
                var acompte = _mapper.Map<Domain.Entities.Reglement_Acompte_BA_Fournisseur>(request);
                _context.Reglement_Acompte_BA_Fournisseurs.Add(acompte);
                await UpdateCreditFournisseur(null, acompte, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            else if (request.Type == "Reglement")
            {
                ba.RestTotal = 0;
                ba.Etat = "Acheté";
                ba.TotalReglement = ba.MontantTotalTTC;
                _context.BonAchats.Update(ba).Property(x => x.Numero).IsModified = false;
                var reglement = _mapper.Map<Domain.Entities.Reglement_Acompte_BA_Fournisseur>(request);
                _context.Reglement_Acompte_BA_Fournisseurs.Add(reglement);
                await UpdateCreditFournisseur(null, reglement, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }

            return default;

        }


        public async Task UpdateCreditFournisseur(BonAchats ba, Reglement_Acompte_BA_Fournisseur reglement, CancellationToken cancellationToken)
        {

            if (ba != null)
            {
                if (ba.RestTotal >= ba.Fournisseur.TotalAvances)
                {
                    ba.Fournisseur.TotalAvances = 0;
                }
                if (ba.Fournisseur != null)
                    ba.Fournisseur.TotalCredits += ba.RestTotal;
                if (ba.Fournisseur.DateEcheance.Day <= DateTime.Now.Day && ba.Fournisseur.TotalCredits > 0)
                {
                    ba.Fournisseur.IsBanned = true;
                }

                else
                {
                    ba.Fournisseur.IsBanned = false;
                }
                _context.Fournisseurs.Update(ba.Fournisseur);
            }
            else if (reglement != null)
            {
                if (reglement.Fournisseur != null)
                    reglement.Fournisseur.TotalCredits = reglement.Fournisseur.TotalCredits - reglement.Montant;
                if (reglement.Fournisseur.DateEcheance <= DateTime.Now && reglement.Fournisseur.TotalCredits > 0)
                {
                    reglement.Fournisseur.IsBanned = true;
                }
                else
                {
                    reglement.Fournisseur.IsBanned = false;
                }
                _context.Fournisseurs.Update(reglement.Fournisseur);
            }
        }






    }
}