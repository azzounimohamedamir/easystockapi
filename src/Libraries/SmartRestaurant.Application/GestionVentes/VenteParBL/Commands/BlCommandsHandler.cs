using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Application.GestionVentes.VenteComptoir.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ValidationException = SmartRestaurant.Application.Common.Exceptions.ValidationException;

namespace SmartRestaurant.Application.GestionVentes.VenteParBl.Commands
{
    public class BlCommandsHandler :
        IRequestHandler<CreateBlCommand, Created>,
        IRequestHandler<RegroupBlCommand, Bl>,
        IRequestHandler<TransformerBLenFactureCommand, Created>,
        IRequestHandler<UpdateBlCommand, NoContent>,
        IRequestHandler<DeleteBlCommand, NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BlCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Created> Handle(CreateBlCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateBlCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var client = _context.Clients.Where(c => c.Id == request.ClientId).FirstOrDefault();
            var bl = new Domain.Entities.Bl()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Heure = DateTime.Now.ToString("hh:mm:ss"),
                Conducteur = request.Conducteur,
                MatriculeVeh = request.MatriculeVeh,
                LieuLivraison = request.LieuLivraison,
                NomVehicule = request.NomVehicule,
                VendeurId = new Guid(),
                NomCaissier = request.NomCaissier,
                Caisse = request.Caisse,
                MontantTotalHT = decimal.Parse(request.MontantTotalHT.ToString()),
                MontantTotalTTC = decimal.Parse(request.MontantTotalTTC.ToString()),
                MontantTotalTVA = decimal.Parse(request.MontantTotalTVA.ToString()),
                ClientId = request.ClientId,
                Client = client,
                TotalReglement = request.TotalReglement,
                Numero = request.Numero,
                CodeBl = GenerateCodeBl(request.Caisse),
                Timbre = request.Timbre,
                DateEcheance = request.DateEcheance,
                DateFermuture = request.DateFermuture,
                Etat = request.Etat,
                PaymentMethod = request.PaymentMethod,
                Remise = request.Remise,
                MontantTotalHTApresRemise = decimal.Parse(request.MontantTotalHTApresRemise.ToString()),
                RestTotal = decimal.Parse(request.RestTotal.ToString()),
                Rib = request.Rib,
                Rip = request.Rip,

            };
            _context.Bls.Add(bl);
            request.BlProducts.ForEach(async item =>
            {
                var stockMatch = _context.Stocks.Where(u => u.Designaation == item.Designation).FirstOrDefault();
                var blp = new BlProducts
                {
                    BlId = bl.Id,
                    Designation = item.Designation,
                    Qte = item.Qte,
                    MontantHT = item.MontantHT,
                    MontantTTC = item.MontantTTC,
                    MontantTVA = item.MontantTVA,
                    HasReduction = item.HasReduction,
                    LastPuv = item.LastPuv,
                    Reduction = item.Reduction,
                    Puv = item.Puv,
                    Image = stockMatch.Image,
                    SelectedStockId = stockMatch.Id,
                    SelectedStock = stockMatch
                };
                _context.BlProducts.Add(blp);
                await AddSortieStock(blp, bl, cancellationToken);
                await Destocker(blp, cancellationToken);

            }
            );

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task AddSortieStock(BlProducts blp, Domain.Entities.Bl bl, CancellationToken cancellationToken)
        {



            MouvementStock mvt = new MouvementStock
            {
                DateMvt = bl.Date,
                ProduitId = blp.SelectedStock.Id,
                ProduitName = blp.SelectedStock.Designaation,
                Qte = blp.Qte,
                TypeMouvement = TypeMouv.Sortie
            };
            _context.MouvementStocks.Add(mvt);
        }
        public string GenerateCodeBl(int caisse)
        {
            const string codeBlPrefix = "BL";
            const int codeBlLength = 6;

            // Format Numero as a string with leading zeros
            string formattedNumero = GetNextInvoiceNumberFromDatabase().ToString($"D{codeBlLength - 1}");

            // Concatenate the prefix and formatted Numero
            return $"{codeBlPrefix}{caisse}{formattedNumero}";
        }


        public string GenerateCodeF(int caisse)
        {
            const string codeFPrefix = "F";
            const int codeFLength = 6;

            // Format Numero as a string with leading zeros
            string formattedNumero = GetNextInvoiceNumberFromDatabase().ToString($"D{codeFLength - 1}");

            // Concatenate the prefix and formatted Numero
            return $"{codeFPrefix}{caisse}{formattedNumero}";
        }
        private int GetNextInvoiceNumberFromDatabase()
        {
            // Retrieve the current invoice number from the database
            // This could involve querying the database or using a dedicated service to manage invoice numbers
            // In this example, let's assume you have a method to retrieve the next sequential number
            // You may need to implement this based on your database structure and business rules
            // For simplicity, I'm using a placeholder value here

            if (_context.Bls.Count() == 0)
            {
                return 1;
            }
            else
            {
                return _context.Bls.Max(f => f.Numero) + 1;
            }
        }

        public async Task Destocker(BlProducts blp, CancellationToken cancellationToken)
        {
            var DestockedProduct = _context.Stocks.Where(p => p.Designaation == blp.Designation).FirstOrDefault();

            DestockedProduct.QteRestante = DestockedProduct.QteRestante - blp.Qte;
            _context.Stocks.Update(DestockedProduct);
        }



        public async Task Restorer(BlProducts blp, CancellationToken cancellationToken)
        {
            var RestoredProduct = _context.Stocks.Where(p => p.Designaation == blp.Designation).FirstOrDefault();

            RestoredProduct.QteRestante = RestoredProduct.QteRestante + blp.Qte;
            _context.Stocks.Update(RestoredProduct);
        }

        public async Task<NoContent> Handle(DeleteBlCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteBlCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var bl = _context.Bls.Include(v => v.BlProducts).FirstOrDefault();
            if (bl == null)
                throw new NotFoundException(nameof(Stock), request.Id);

            bl.BlProducts.ForEach(async item =>

            {
                await Restorer(item, cancellationToken);
            }
           );
            var retourProduitClient = new RetourProduitClient
            {
                DocumentId = bl.Id,
                ReturnedFrom = "Bon de Livraison (Suppression)",
                Client = bl.Client,
                Date = DateTime.Now.Date,
                Heure = DateTime.Now.ToString("HH:mm:ss"),
                MontantTotalTTC = bl.MontantTotalTTC,
                Numero = bl.Numero,
                RestTotal = bl.RestTotal,
                RetourProducts = _mapper.Map<List<Domain.Entities.RetourProducts>>(bl.BlProducts),
                ClientId = bl.ClientId,


            };
            _context.RetourProduitClients.Add(retourProduitClient);


            _context.Bls.Remove(bl);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(UpdateBlCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBlCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var bl = await _context.Bls
                .Include(vp => vp.BlProducts).Include(c => c.Client)
                .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken)
                .ConfigureAwait(false);
            var client = _context.Clients.Where(c => c.Id == request.ClientId).FirstOrDefault();
            if (bl == null)
                throw new NotFoundException(nameof(Stock), request.Id);



            // Restore old products quantities to stock
            foreach (var item in bl.BlProducts)
            {
                await Restorer(item, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }




            // Remove old products included in bl
            _context.BlProducts.RemoveRange(bl.BlProducts);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // Add new products included in request
            foreach (var item in request.BlProducts)
            {
                var stockMatch = _context.Stocks
                    .Where(u => u.Designaation == item.Designation)
                    .FirstOrDefault();

                var blp = new BlProducts
                {
                    BlId = request.Id,
                    Designation = item.Designation,
                    Qte = item.Qte,
                    MontantHT = item.MontantHT,
                    MontantTTC = item.MontantTTC,
                    MontantTVA = item.MontantTVA,
                    Puv = item.Puv,
                    Image = stockMatch.Image,
                    SelectedStockId = stockMatch.Id,
                    SelectedStock = stockMatch
                };




                _context.BlProducts.Add(blp);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);





                try
                {
                    // Check if a record with the same FactureId already exists
                    var existingRecord = await _context.BlProducts
                        .FirstOrDefaultAsync(fp => fp.BlId == bl.Id, cancellationToken);

                    if (existingRecord != null)
                    {
                        await Destocker(existingRecord, cancellationToken);

                        // Handle the case where a record with the same FactureId already exists
                        // You might want to throw an exception, log an error, or take appropriate action
                    }
                    else
                    {
                        // Proceed with adding the new FacProducts record
                        var flp = new BlProducts
                        {
                            BlId = bl.Id,
                            Designation = item.Designation,
                            Qte = item.Qte,
                            MontantTTC = item.MontantTTC,
                            MontantHT = item.MontantHT,
                            MontantTVA = item.MontantTVA,
                            Puv = item.Puv,
                            Image = stockMatch?.Image,
                            SelectedStockId = stockMatch.Id,
                            SelectedStock = stockMatch
                        };

                        _context.BlProducts.Add(flp);
                        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                        await Destocker(flp, cancellationToken);
                    }
                }
                catch (Exception ex)
                {

                    // Handle exceptions (log, notify, etc.)
                    Console.WriteLine($"Error: {ex.Message}");
                    // You might want to rethrow the exception or take appropriate action based on your application's needs
                    throw;
                }

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
            bl.Heure = request.Heure;
            bl.Date = request.Date;
            bl.Conducteur = request.Conducteur;
            bl.MatriculeVeh = request.MatriculeVeh;
            bl.LieuLivraison = request.LieuLivraison;
            bl.NomVehicule = request.NomVehicule;
            bl.VendeurId = request.VendeurId;
            bl.ClientId = client.Id;
            bl.Timbre = request.Timbre;
            bl.Heure = bl.Heure;
            _context.Bls.Update(bl);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return default;
        }





        public async Task<Bl> Handle(RegroupBlCommand request, CancellationToken cancellationToken)
        {
            var validator = new RegroupBlCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var Bls = _context.Bls.Where(c => c.ClientId == request.Client.Id && c.Date <= request.Datef && c.Date >= request.Dated).Include(a => a.BlProducts).ToList();
            var blgrouped = new Domain.Entities.Bl()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Heure = DateTime.Now.ToShortTimeString(),
                VendeurId = new Guid(),
                MontantTotalHTApresRemise = Bls.Select(s => s.MontantTotalHTApresRemise).Sum(),
                MontantTotalTTC = Bls.Select(s => s.MontantTotalTTC).Sum(),
                MontantTotalTVA = Bls.Select(s => s.MontantTotalTVA).Sum(),
                DateEcheance = DateTime.Now,
                DateFermuture = DateTime.Now,
                MontantTotalHT = Bls.Select(s => s.MontantTotalHT).Sum(),
                Remise = Bls.Select(s => s.Remise).Sum(),
                ClientId = request.Client.Id,
                Client = request.Client,
                RestTotal = 0,
                BlProducts = null
            };

            blgrouped.BlProducts = Bls
                .SelectMany(bl => bl.BlProducts ?? Enumerable.Empty<BlProducts>()) // Flatten the BlProducts from all Bls, and handle null BlProducts collections
                .Where(product => product != null) // Filter out any null BlProducts
                .GroupBy(product => product?.Designation) // Group by Designation, handle null Designation
                .Where(group => group.Key != null) // Filter out groups with null Designation
                .Select(group => new BlProducts
                {
                    BlId = blgrouped?.Id ?? Guid.Empty, // Handle null blgrouped.Id by using a default value (e.g., Guid.Empty)
                    Designation = group.Key, // No need for null-checking here, as we filtered out null keys
                    Qte = group.Sum(product => product?.Qte ?? 0), // Handle null Qte by using a default value (e.g., 0)
                    MontantHT = group.Sum(product => product?.MontantHT ?? 0),
                    MontantTTC = group.Sum(product => product?.MontantTTC ?? 0),
                    MontantTVA = group.Sum(product => product?.MontantTVA ?? 0),
                    // Handle null Montant by using a default value (e.g., 0)
                    Puv = group.First()?.Puv ?? 0, // Handle null Puv by using a default value (e.g., 0)
                    Image = group.First()?.Image                             // Image and SelectedStock properties can be set similarly
                })
                .ToList();
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return blgrouped;
        }

        public async Task<Created> Handle(TransformerBLenFactureCommand request, CancellationToken cancellationToken)
        {
            var validator = new TransformerBLenFactureCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var newFactureId = Guid.NewGuid(); // Generate a new unique Id

            // Check if a Bl with the same Id already exists (optional, depending on your requirements)
            var existingFacture = await _context.Factures.FindAsync(newFactureId);
            if (existingFacture != null)
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
                    var facture = new Domain.Entities.Facture()
                    {
                        Id = newFactureId, // Use the generated Id
                        Date = request.Bl.Date,
                        BlId = request.Bl.Id,
                        VcId = request.Bl.VcId,
                        CodeF = GenerateCodeF(request.Bl.Caisse),
                        NomCaissier = request.Bl.NomCaissier,
                        Heure = request.Bl.Date.ToShortTimeString(),
                        VendeurId = new Guid(),
                        MontantTotalHTApresRemise = request.Bl.MontantTotalHTApresRemise,
                        MontantTotalHT = request.Bl.MontantTotalHT,
                        Remise = request.Bl.Remise,
                        CouponPrice = request.Bl.CouponPrice,
                        ClientId = request.Client.Id, // Assign the ClientId property
                        Client = null, // Assign the Client property
                        Timbre = 0,
                        DateEcheance = DateTime.Now,
                        DateFermuture = DateTime.Now,
                        Etat = "Non Réglé",
                        PaymentMethod = request.Bl.PaymentMethod,
                        RestTotal = request.Bl.MontantTotalTTC,
                        Rib = 0,
                        Rip = 0,
                        MontantTotalTTC = request.Bl.MontantTotalTTC,
                        MontantTotalTVA = request.Bl.MontantTotalTVA,
                        TotalReglement = request.Bl.TotalReglement
                    };

                    // Add the new Bl to the context
                    _context.Factures.Add(facture);
                    await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                    foreach (var item in request.Bl.BlProducts)
                    {
                        var stockMatch = await _context.Stocks
                            .Where(u => u.Designaation == item.Designation)
                            .FirstOrDefaultAsync(cancellationToken);

                        if (stockMatch != null)
                        {
                            var facp = new FacProducts
                            {
                                FactureId = facture.Id,
                                Designation = item.Designation,
                                Qte = item.Qte,
                                MontantHT = item.MontantHT,
                                MontantTTC = item.MontantTTC,
                                MontantTVA = item.MontantTVA,
                                Puv = item.Puv,
                                Image = stockMatch.Image,
                                SelectedStockId = stockMatch.Id,
                                SelectedStock = stockMatch
                            };
                            _context.FacProducts.Add(facp);
                            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);



                            var bl = _context.Bls.Where(code => code.Id == request.Bl.Id).FirstOrDefault();
                            bl.Etat = "Facturé";
                            _context.Bls.Update(bl);
                            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);


                        }


                    }

                    //try
                    //{
                    //    // Retrieve the VenteComptoir entity you want to delete
                    //    var BlToDelete = _context.Bls
                    //        .Include(bl => bl.BlProducts) // Include the related collection
                    //        .FirstOrDefault(vc => vc.Id == request.Bl.Id);

                    //    if (BlToDelete != null)
                    //    {
                    //        // Remove the related items from the collection
                    //        BlToDelete.BlProducts.Clear();

                    //        // Delete the VenteComptoir entity
                    //        _context.Bls.Remove(BlToDelete);

                    //        // Save the changes to the database
                    //        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                    //    }
                    //}
                    //catch (Exception ex)
                    //{
                    //    // Handle exceptions if needed
                    //}

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

    }
}