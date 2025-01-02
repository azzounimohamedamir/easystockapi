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

            var venteCompt = new Domain.Entities.VenteComptoir()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                CodeVc=GenerateCodeVC(),
                Heure = DateTime.Now.ToShortTimeString(),
                VendeurId = new Guid(),
                MontantAprRemise = request.MontantAprRemise,
                MontantTotal = request.MontantTotal, // Typo: Should be "MontantTotal"
                Remise = request.Remise
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
                        Montant = item.Montant,
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
        public string GenerateCodeVC()
        {
            const string codeVCprefix = "VC";
            const int codeVCLength = 6;

            // Format Numero as a string with leading zeros
            string formattedNumero = GetNextInvoiceNumberFromDatabase().ToString($"D{codeVCLength - 1}");

            // Concatenate the prefix and formatted Numero
            return $"{codeVCprefix}{formattedNumero}";
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
                    // Create a new Bl entity
                    var bl = new Domain.Entities.Bl()
                    {
                        Id = newBlId, // Use the generated Id
                        Date = request.Vc.Date,
                        Heure = request.Vc.Date.ToShortTimeString(),
                        VendeurId = new Guid(),
                        MontantTotalHTApresRemise = request.Vc.MontantAprRemise,
                        MontantTotalHT = request.Vc.MontantTotal,
                        Remise = request.Vc.Remise,
                        ClientId = request.Client.Id, // Assign the ClientId property
                        Client = null, // Assign the Client property
                        Timbre = 0,
                        DateEcheance = DateTime.Now,
                        DateFermuture = DateTime.Now,
                        Etat = "Non Réglé",
                        PaymentMethod = "Espèce",
                        RestTotal = request.Vc.MontantAprRemise,
                        Rib = 0,
                        Rip = 0,
                        MontantTotalTTC = request.Vc.MontantAprRemise,
                        MontantTotalTVA = 0,
                        TotalReglement = 0
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
                                MontantTTC = item.Montant,
                                Puv = item.Puv,
                                Image = stockMatch.Image,
                                SelectedStockId = stockMatch.Id,
                                SelectedStock = stockMatch
                            };
                            _context.BlProducts.Add(blp);
                            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);


                        }


                    }

                    try
                    {
                        // Retrieve the VenteComptoir entity you want to delete
                        var venteComptoirToDelete = _context.VenteComptoirs
                            .Include(vc => vc.VenteComptoirIncludedProducts) // Include the related collection
                            .FirstOrDefault(vc => vc.Id == request.Vc.Id);

                        if (venteComptoirToDelete != null)
                        {
                            // Remove the related items from the collection
                            venteComptoirToDelete.VenteComptoirIncludedProducts.Clear();

                            // Delete the VenteComptoir entity
                            _context.VenteComptoirs.Remove(venteComptoirToDelete);

                            // Save the changes to the database
                            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions if needed
                    }

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
                .Include(v => v.VenteComptoirIncludedProducts)
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
                    MontantHT = item.Montant,
                    Puv = item.Puv,
                    SelectedStock = item.SelectedStock,
                    SelectedStockId = item.SelectedStockId,
                    MontantTTC = item.Montant,
                    Qte = item.Qte,
                    MontantTVA = 0,
                    
                };
          
                    retours.Add(retour);
            }



            _context.VenteComptoirs.Remove(vc);



            var client = _context.Clients.Where(cl => cl.FullName == "VC").FirstOrDefault();



            var retourProduitClient = new RetourProduitClient
            {
                Id = new Guid(),
                DocumentId = vc.Id,
                ReturnedFrom="Vente Comptoir ( Suppression )",
                Client= client,
                Date=DateTime.Now.Date,
                Heure = DateTime.Now.ToString("HH:mm:ss"),
                MontantTotalTTC=vc.MontantTotal,
                Numero=vc.Numero,
                RestTotal=vc.MontantTotal,
                RetourProducts=retours,
                ClientId= client.Id
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
            var client = _context.Clients.Where(cl => cl.FullName == "VC").FirstOrDefault();

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
                        Montant = item.Montant,
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

            // Update old vente Comptoir with the new values
            var entity = _mapper.Map<Domain.Entities.VenteComptoir>(request);
            vc.MontantAprRemise = request.MontantAprRemise;
            vc.MontantTotal = request.MontantTotal;
            vc.Remise = request.Remise;
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

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