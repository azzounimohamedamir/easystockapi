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
using Microsoft.AspNetCore.Routing;

namespace SmartRestaurant.Application.GestionVentes.VenteComptoir.Commands
{
    public class VenteComptoirCommandsHandler :
        IRequestHandler<CreateVenteComptoirCommand, Created>,
        IRequestHandler<TransformerVCenBLCommand, Created>,
        IRequestHandler<UpdateVenteComptoirCommand, NoContent>,
        IRequestHandler<DeleteVenteComptoirCommand, NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public VenteComptoirCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Created> Handle(CreateVenteComptoirCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateVenteComptoirCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
                        var client = _context.Clients.Where(c => c.Id == request.ClientId).FirstOrDefault();
            decimal benifice = 0;


            foreach (var item in request.VenteComptoirIncludedProducts)
            {
                var stockMatch = await _context.Stocks
                   .Where(u => u.Designaation == item.Designation)
                   .FirstOrDefaultAsync(cancellationToken);
                if (stockMatch != null)
                {
                    benifice = (item.Puv - stockMatch.PrixAchat)* item.Qte + benifice;
                }
                stockMatch.TotalBenifice = (item.Puv - stockMatch.PrixAchat) * item.Qte + stockMatch.TotalBenifice; 
                _context.Stocks.Update(stockMatch);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            }
            var venteCompt = new Domain.Entities.VenteComptoir()
            {
                Id = Guid.NewGuid(),
                Conducteur = request.Conducteur,
                LieuLivraison = request.LieuLivraison,
                MatriculeVeh = request.MatriculeVeh,
                NomVehicule = request.NomVehicule,
                ConditionDePaiment= request.ConditionDePaiment,
                Date = DateTime.Now,
                CodeVc = GenerateCodeVC(request.Caisse),
                Heure = DateTime.Now.ToShortTimeString(),
                VendeurId = new Guid(),
                NomCaissier = request.NomCaissier,
                Caisse = request.Caisse,
                BlId = Guid.Empty,
                IsDeleted = false,
                Remise = request.Remise,
                CouponPrice = request.CouponPrice,
                MontantTotalHT = decimal.Parse(request.MontantTotalHT.ToString()),
                MontantTotalTTC = decimal.Parse(request.MontantTotalTTC.ToString()),
                MontantTotalTVA = decimal.Parse(request.MontantTotalTVA.ToString()),
                ClientId = request.ClientId,
                Client = client,
                TotalReglement = request.TotalReglement,
                Timbre = request.Timbre,
                DateEcheance = request.DateEcheance,
                DateFermuture = request.DateFermuture,
                Etat = request.RestTotal == 0 ? "Reglé" : "Non Réglé",
                PaymentMethod = request.PaymentMethod,
                MontantTotalHTApresRemise = decimal.Parse(request.MontantTotalHTApresRemise.ToString()),
                RestTotal = decimal.Parse(request.RestTotal.ToString()),
                Rib = request.Rib,
                Rip = request.Rip,
                Benifice = benifice - request.Remise
            };



            _context.VenteComptoirs.Add(venteCompt);

            foreach (var item in request.VenteComptoirIncludedProducts)
            {
                var stockMatch = await _context.Stocks
                    .Where(u => u.Designaation == item.Designation)
                    .FirstOrDefaultAsync(cancellationToken);

                if (stockMatch != null)
                {
                    var vcp = new VenteComptoirProducts
                    {
                        VenteComptoirId = venteCompt.Id,
                        Designation = item.Designation,
                        Qte = item.Qte,
                        LastPuv= item.LastPuv,
                        HasReduction=item.HasReduction,
                        Reduction= item.Reduction,
                        MontantHT = item.MontantHT,
                        Puv = item.Puv,
                        Image = stockMatch.Image,
                        SelectedStockId = stockMatch.Id,
                        SelectedStock = stockMatch
                    };
                    _context.VenteComptoirProducts.Add(vcp);

                    await AddSortieStock(vcp, venteCompt, cancellationToken);
                    await Destocker(vcp, cancellationToken);
                }
            }

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return default;
        }
        public string GenerateCodeVC(int caisse)
        {
            const string codeVCprefix = "VC";
            const int codeVCLength = 6;

            // Format Numero as a string with leading zeros
            string formattedNumero = GetNextInvoiceNumberFromDatabase().ToString($"D{codeVCLength - 1}");

            // Concatenate the prefix and formatted Numero
            return $"{codeVCprefix}{caisse}{formattedNumero}";
        }

        private int GetNextInvoiceNumberFromDatabase()
        {
            // Retrieve the current invoice number from the database
            // This could involve querying the database or using a dedicated service to manage invoice numbers
            // In this example, let's assume you have a method to retrieve the next sequential number
            // You may need to implement this based on your database structure and business rules
            // For simplicity, I'm using a placeholder value here
            if (_context.VenteComptoirs.Count() == 0) return 1;
            else
                return _context.VenteComptoirs.Max(f => f.Numero) + 1;
        }

        public async Task<Created> Handle(TransformerVCenBLCommand request, CancellationToken cancellationToken)
        {
            var validator = new TransformerVCenBLCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var newBlId = Guid.NewGuid(); // Generate a new unique Id
            // Check if a Bl with the same Id already exists (optional, depending on your requirements)
            var existingBl = await _context.Bls.FindAsync(newBlId);
            if (existingBl != null)
            {
                // Handle the case where a Bl with the same Id already exists
                // You can update the existing Bl or handle it according to your application logic
            }
            else
            {
                // Ensure that request.Client is not null and contains valid data
                if (request.Client != null && request.Client.Id != Guid.Empty)
                {
                    var clientBl= _context.Clients.FirstOrDefault(c=>c.Id==request.Client.Id);
                    // Create a new Bl entity
                    var bl = new Domain.Entities.Bl()
                    {
                        Id = newBlId, // Use the generated Id
                        Date = request.Vc.Date,
                        CodeBl = request.Vc.CodeVc.Replace("VC", "BL"),
                        VcId = request.Vc.Id,
                        NomCaissier=request.Vc.NomCaissier,
                        Heure = request.Vc.Date.ToShortTimeString(),
                        VendeurId = new Guid(),
                        MontantTotalHTApresRemise = request.Vc.MontantTotalHTApresRemise,
                        MontantTotalHT = request.Vc.MontantTotalHT,
                        Conducteur = request.Vc.Conducteur,
                        LieuLivraison = request.Vc.LieuLivraison,
                        MatriculeVeh = request.Vc.MatriculeVeh,
                        NomVehicule = request.Vc.NomVehicule,

                        Remise = request.Vc.Remise,
                        ClientId = clientBl.Id, // Assign the ClientId property
                        Client = clientBl, // Assign the Client property
                        Timbre = request.Vc.Timbre,
                        DateEcheance = clientBl.DateEcheance,
                        DateFermuture = DateTime.Now,
                        Etat = "Non Facturé",
                        PaymentMethod = request.Vc.PaymentMethod,
                        RestTotal = request.Vc.RestTotal,
                        Rib = request.Vc.Rib,
                        Rip = request.Vc.Rip,
                        MontantTotalTTC = request.Vc.MontantTotalTTC,
                        MontantTotalTVA = request.Vc.MontantTotalTVA,
                        TotalReglement = request.Vc.TotalReglement,
                    };

                    // Add the new Bl to the context
                    _context.Bls.Add(bl);
                    await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                    foreach (var item in request.Vc.VenteComptoirIncludedProducts)
                    {
                        var stockMatch = await _context.Stocks
                            .Where(u => u.Designaation == item.Designation)
                            .FirstOrDefaultAsync(cancellationToken);

                        if (stockMatch != null)
                        {
                            var blp = new BlProducts
                            {
                                BlId = bl.Id,
                                Designation = item.Designation,
                                Qte = item.Qte,
                                MontantHT = item.MontantHT,
                                MontantTTC = item.MontantTTC,
                                MontantTVA = item.MontantTVA,
                                Puv = item.Puv,
                                LastPuv = item.LastPuv,
                                Reduction = item.Reduction,
                                HasReduction = item.HasReduction,
                                Image = stockMatch.Image,
                                SelectedStockId = stockMatch.Id,
                                SelectedStock = stockMatch
                              
                            };
                            _context.BlProducts.Add(blp);
                            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);


                        }


                    }
                    var vc =  _context.VenteComptoirs.FirstOrDefault(vc => vc.Id == request.Vc.Id);
                    vc.IsTransformed = true;
                    _context.VenteComptoirs.Update(vc);
                    await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                    // Save changes to the database
                }
                else
                {
                    // Handle the case where request.Client is null or contains invalid data
                    // You can log an error or handle it according to your application logic
                }

            }




            return default;
        }

        public async Task<NoContent> Handle(DeleteVenteComptoirCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteVenteComptoirCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var vc = await _context.VenteComptoirs
                .Include(v => v.VenteComptoirIncludedProducts).Include(c=>c.Client)
                .FirstOrDefaultAsync(v => v.Id == request.Id, cancellationToken)
                .ConfigureAwait(false);

            if (vc == null)
                throw new NotFoundException(nameof(VenteComptoir), request.Id);

            List<RetourProducts> retours =new List<RetourProducts>();
            foreach (var item in vc.VenteComptoirIncludedProducts)
            {
                await Restorer(item, cancellationToken);

                RetourProducts retour = new RetourProducts()
                {
                    Id = item.Id,
                    Designation = item.Designation,
                    DocumentId = vc.Id,
                    Image = item.Image,
                    MontantHT = item.MontantHT,
                    Puv = item.Puv,
                    SelectedStock = item.SelectedStock,
                    SelectedStockId = item.SelectedStockId,
                    MontantTTC = item.MontantTTC,
                    Qte = item.Qte,
                    MontantTVA = 0,
                    
                };
          
                    retours.Add(retour);
            }



            _context.VenteComptoirs.Remove(vc);






            var retourProduitClient = new RetourProduitClient
            {
                Id = new Guid(),
                DocumentId = vc.Id,
                ReturnedFrom="Vente Comptoir ( Suppression )",
                Client= vc.Client,
                Date=DateTime.Now.Date,
                Heure = DateTime.Now.ToString("HH:mm:ss"),
                MontantTotalTTC=vc.MontantTotalTTC,
                Numero=vc.Numero,
                RestTotal=vc.RestTotal,
                RetourProducts=retours,
                ClientId= vc.Client.Id
            };
            _context.RetourProduitClients.Add(retourProduitClient);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return default;
        }

        public async Task<NoContent> Handle(UpdateVenteComptoirCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateVenteComptoirCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var vc = await _context.VenteComptoirs
                .Include(vp => vp.VenteComptoirIncludedProducts)
                .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken)
                .ConfigureAwait(false);

            if (vc == null)
                throw new NotFoundException(nameof(VenteComptoir), request.Id);

            // Restore old products quantities to stock
            foreach (var item in vc.VenteComptoirIncludedProducts)
            {
                await Restorer(item, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }

          

            //
            // old products included in vc
            _context.VenteComptoirProducts.RemoveRange(vc.VenteComptoirIncludedProducts);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // Add new products included in request
            foreach (var item in request.VenteComptoirIncludedProducts)
            {
                var stockMatch = await _context.Stocks
                    .Where(u => u.Designaation == item.Designation)
                    .FirstOrDefaultAsync(cancellationToken);

                if (stockMatch != null)
                {
                    var vcp = new VenteComptoirProducts
                    {
                        VenteComptoirId = request.Id,
                        Designation = item.Designation,
                        Qte = item.Qte,
                        MontantHT = item.MontantHT,
                        MontantTTC = item.MontantTTC,
                        MontantTVA= item.MontantTVA,
                        Puv = item.Puv,
                        Image = stockMatch.Image,
                        SelectedStockId = stockMatch.Id,
                        SelectedStock = stockMatch
                    };


                   


                    _context.VenteComptoirProducts.Add(vcp);
                    await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                    await Destocker(vcp, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                }
            }


            // Update BL related if exist

            var bl = await _context.Bls
               .Include(vp => vp.BlProducts).Include(c => c.Client)
               .FirstOrDefaultAsync(m => m.VcId == request.Id, cancellationToken)
               .ConfigureAwait(false);
            var client = _context.Clients.Where(c => c.Id == request.ClientId).FirstOrDefault();
            if (bl != null)
            {
                // Remove old products included in bl
                _context.BlProducts.RemoveRange(bl.BlProducts);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                // Add new products included in request
                foreach (var item in request.VenteComptoirIncludedProducts)
                {
                    var stockMatch = _context.Stocks
                        .Where(u => u.Designaation == item.Designation)
                        .FirstOrDefault();

                    var blp = new BlProducts
                    {
                        BlId = bl.Id,
                        Designation = item.Designation,
                        Qte = item.Qte,
                        MontantTTC = item.MontantTTC,
                        MontantTVA = item.MontantTVA,
                        MontantHT = item.MontantHT,
                        Puv = item.Puv,
                        Image = stockMatch.Image,
                        SelectedStockId = stockMatch.Id,
                        SelectedStock = stockMatch
                    };




                    _context.BlProducts.Add(blp);
                    await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);






                }

                // Update old vente Comptoir with the new values

                var entity = _mapper.Map<Domain.Entities.Bl>(request);

                bl.MontantTotalHT = request.MontantTotalHT;
                bl.MontantTotalTVA = request.MontantTotalTVA;
                bl.MontantTotalTTC = request.MontantTotalTTC;
                bl.RestTotal = request.RestTotal;
                bl.MontantTotalHTApresRemise = request.MontantTotalHTApresRemise;
                bl.Client = client;
                bl.Remise = request.Remise;
                bl.Conducteur = request.Conducteur;
                bl.MatriculeVeh = request.MatriculeVeh;
                bl.LieuLivraison = request.LieuLivraison;
                bl.NomVehicule = request.NomVehicule;
                bl.VendeurId = Guid.Parse(request.VendeurId);
                bl.ClientId = client.Id;
                bl.Timbre = request.Timbre;
                bl.Heure = bl.Heure;
                _context.Bls.Update(bl);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }



           




          























            // Update FactureInfo if exist 

            var fac = await _context.Factures
               .Include(vp => vp.FacProducts)
               .ThenInclude(s => s.SelectedStock)
                .Include(vp => vp.FacProducts)
               .ThenInclude(s => s.SelectedStock)
                .Include(vp => vp.FacProducts)
               .ThenInclude(s => s.SelectedStock)
               .FirstOrDefaultAsync(m => m.VcId == request.Id, cancellationToken)
               .ConfigureAwait(false);
            if ( fac != null)
           


            if (fac != null)
                {
                    fac.Etat = "Modifié";
                    _context.Factures.Update(fac);
                    await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);


                    var clientForReq = _context.Clients.Where(c => c.Id == request.ClientId).FirstOrDefault();
                    // créer un avoir sur cette facture ancienne a partir des nouveeaux modification
                    var facAvoir = new Facture()
                {
                    Date = DateTime.Now,
                    Heure = DateTime.Now.ToShortTimeString(),
                    VendeurId = Guid.NewGuid(),
                    NomCaissier = fac.NomCaissier,
                    Caisse = fac.Caisse,
                    CouponPrice = fac.CouponPrice,
                    MontantTotalHT = -1 * fac.MontantTotalHT, // Inverting MontantTotalHT
                    MontantTotalTTC = -1 * fac.MontantTotalTTC, // Inverting MontantTotalTTC
                    MontantTotalTVA = -1 * fac.MontantTotalTVA, // Inverting MontantTotalTVA
                    ClientId = clientForReq.Id,
                    Client = clientForReq,
                    TotalReglement = -1 * fac.TotalReglement,
                    Numero = 0,
                    ConditionPaiement = vc.ConditionDePaiment,
                    CodeF = GenerateCodeF(fac.Caisse, "AV"),
                    Timbre = fac.Timbre, // Inverting Timbre
                    DateEcheance = fac.DateEcheance,
                    DateFermuture = fac.DateFermuture,
                    Etat = "✏️ Avoir Sur " + fac.CodeF,
                    PaymentMethod = fac.PaymentMethod,
                    Remise = fac.Remise, // Inverting Remise
                    MontantTotalHTApresRemise = -1 * fac.MontantTotalHTApresRemise, // Inverting MontantTotalHTApresRemise
                    RestTotal = -1 * fac.RestTotal, // Inverting RestTotal
                    Rib = fac.Rib,
                    Rip = fac.Rip
                };

                _context.Factures.Add(facAvoir);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);


                // ne pas supprimer les items inclus ds Facture anc pour garder les tracabilités de la facture ancienne
                //_context.FacProducts.RemoveRange(fac.FacProducts);
                //await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                // reStocker les elements de la facture ancienne


                foreach (var item in vc.VenteComptoirIncludedProducts)
                {
                    var stockMatch = await _context.Stocks

                                        .Where(u => u.Designaation == item.Designation)
                                        .FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);
                    var flp = new FacProducts
                    {
                        Id = Guid.NewGuid(),
                        FactureId = facAvoir.Id,
                        Designation = item.Designation,
                        Qte = item.Qte,
                        MontantHT = -1 * item.MontantHT,
                        MontantTTC = -1 * item.MontantTTC,
                        MontantTVA = item.MontantTVA,
                        Puv = -1 * item.Puv,
                        Image = item.Image,
                        SelectedStockId = stockMatch.Id,
                        SelectedStock = stockMatch
                    };
                    _context.FacProducts.Add(flp);
                    await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                }









                // ADD NEW FACTURE AFTER AVOIR 


                var newFacture = new Facture()
                {
                    Date = facAvoir.Date,
                    Heure = facAvoir.Date.ToShortTimeString(),
                    VendeurId = facAvoir.VendeurId,
                    NomCaissier = request.NomCaissier,
                    Caisse = request.Caisse,
                    ConditionPaiement = request.ConditionDePaiment,
                    CouponPrice = request.CouponPrice,
                    MontantTotalHT = request.MontantTotalHT, // Inverting MontantTotalHT
                    MontantTotalTTC = request.MontantTotalTTC, // Inverting MontantTotalTTC
                    MontantTotalTVA = request.MontantTotalTVA, // Inverting MontantTotalTVA
                    ClientId = clientForReq.Id,
                    Client = clientForReq,
                    TotalReglement = request.TotalReglement,
                    Numero = 0,
                    CodeF = GenerateCodeF(request.Caisse, "F"),
                    Timbre = request.Timbre, // Inverting Timbre
                    DateEcheance = request.DateEcheance,
                    DateFermuture = request.DateFermuture,
                    Etat = request.RestTotal == 0 ? "Reglé" : "Non Réglé",
                    PaymentMethod = request.PaymentMethod,
                    Remise = request.Remise, // Inverting Remise
                    MontantTotalHTApresRemise = request.MontantTotalHTApresRemise, // Inverting MontantTotalHTApresRemise
                    RestTotal = request.RestTotal, // Inverting RestTotal
                    Rib = request.Rib,
                    Rip = request.Rip
                };

                _context.Factures.Add(newFacture);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);


                foreach (var item in request.VenteComptoirIncludedProducts)
                {
                    var stockMatch = await _context.Stocks

                    .Where(u => u.Designaation == item.Designation)
                    .FirstOrDefaultAsync(cancellationToken)
                    .ConfigureAwait(false);


                    var flp = new FacProducts
                    {
                        Id = Guid.NewGuid(),
                        FactureId = newFacture.Id,
                        Designation = item.Designation,
                        Qte = item.Qte,
                        MontantHT = item.MontantHT,
                        MontantTTC = item.MontantTTC,
                        MontantTVA = item.MontantTVA,
                        Puv = item.Puv,
                        Image = item.Image,
                        SelectedStockId = stockMatch.Id,
                        SelectedStock = stockMatch
                    };
                    _context.FacProducts.Add(flp);
                    await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                }

            }




















            // Update old vente Comptoir with the new values
            vc.MontantTotalHTApresRemise = request.MontantTotalHTApresRemise;
            vc.MontantTotalTTC = request.MontantTotalTTC;
            vc.MontantTotalTVA = request.MontantTotalTVA;
            vc.TotalReglement=request.TotalReglement;
            vc.Timbre=request.Timbre;
            vc.CouponPrice = request.CouponPrice;
            vc.MontantTotalHT = request.MontantTotalHT;
            vc.Remise = request.Remise;
            vc.NomVehicule = request.NomVehicule;
            vc.LieuLivraison = request.LieuLivraison;
            vc.Conducteur = request.Conducteur;
            vc.MatriculeVeh = request.MatriculeVeh;
            vc.ConditionDePaiment = request.ConditionDePaiment;
            
            _context.VenteComptoirs.Update(vc);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return default;
        }
        public string GenerateCodeF(int caisse, string type)
        {
            if (type == "F")
            {
                const string codeFPrefix = "F";
                const int codeFLength = 6;

                // Format Numero as a string with leading zeros
                string formattedNumero = GetNextInvoiceNumberFromDatabase().ToString($"D{codeFLength - 1}");

                // Concatenate the prefix and formatted Numero
                return $"{codeFPrefix}{caisse}{formattedNumero}";
            }
            else if (type == "AV")
            {
                const string codeFPrefix = "AV";
                const int codeFLength = 6;

                // Format Numero as a string with leading zeros
                string formattedNumero = GetNextInvoiceNumberFromDatabase().ToString($"D{codeFLength - 1}");

                // Concatenate the prefix and formatted Numero
                return $"{codeFPrefix}{caisse}{formattedNumero}";
            }
            else
                return default;

        }

        public async Task Destocker(VenteComptoirProducts vcp, CancellationToken cancellationToken)
        {
            var DestockedProduct = await _context.Stocks
                .Where(p => p.Designaation == vcp.Designation)
                .FirstOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false);
            

            if (DestockedProduct != null)
            {
               
                DestockedProduct.QteRestante = DestockedProduct.QteRestante - vcp.Qte;
                _context.Stocks.Update(DestockedProduct);

                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
        }
        public async Task DestockerBL(BlProducts blp, CancellationToken cancellationToken)
        {
            var DestockedProduct = _context.Stocks.Where(p => p.Designaation == blp.Designation).FirstOrDefault();

            DestockedProduct.QteRestante = DestockedProduct.QteRestante - blp.Qte;
            _context.Stocks.Update(DestockedProduct);
        }
        public async Task AddSortieStock(VenteComptoirProducts vcp,Domain.Entities.VenteComptoir venteComptoir, CancellationToken cancellationToken)
        {
            var SortieProduct = await _context.Stocks
                .Where(p => p.Designaation == vcp.Designation)
                .FirstOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false);


            MouvementStock mvt = new MouvementStock
            {
                DateMvt = venteComptoir.Date,
                ProduitId = SortieProduct.Id,
                ProduitName = SortieProduct.Designaation,
                Qte = vcp.Qte,
                TypeMouvement = TypeMouv.Sortie
            };
            _context.MouvementStocks.Add(mvt);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task DestockerBl(BlProducts blp, CancellationToken cancellationToken)
        {
            
                var DestockedProduct = _context.Stocks
                    .Where(p => p.Designaation == blp.Designation)
                    .FirstOrDefault();

                if (DestockedProduct != null)
                {
                    // Update the entity without trying to detach it
                    DestockedProduct.QteRestante = DestockedProduct.QteRestante - blp.Qte;

                    // Save changes to the database
                    await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                }
            
        }

        public async Task Restorer(VenteComptoirProducts vcp, CancellationToken cancellationToken)
        {
            var RestoredProduct = await _context.Stocks
                .FirstOrDefaultAsync(p => p.Designaation == vcp.Designation, cancellationToken)
                .ConfigureAwait(false);

            if (RestoredProduct != null)
            {
                RestoredProduct.QteRestante = RestoredProduct.QteRestante + vcp.Qte;
                _context.Stocks.Update(RestoredProduct);

                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }


        }



    }
}