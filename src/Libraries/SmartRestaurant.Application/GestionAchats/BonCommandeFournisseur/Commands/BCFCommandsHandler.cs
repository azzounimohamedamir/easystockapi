using AutoMapper;
using FluentValidation;
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
using ValidationException = SmartRestaurant.Application.Common.Exceptions.ValidationException;

namespace SmartRestaurant.Application.GestionAchats.BonCommandeFournisseur.Commands
{
    public class BCFCommandsHandler :
        IRequestHandler<CreateBCFCommand, Created>,
        IRequestHandler<TransformerBCFenBACommand, Created>,
        IRequestHandler<UpdateBCFCommand, NoContent>,
        IRequestHandler<DeleteBCFCommand, NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BCFCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public string GenerateCodeBC()
        {
            const string codeBCprefix = "BC";
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
            if (_context.BonCommandeFournisseurs.Count() == 0) return 1;
            else
                return _context.BonCommandeFournisseurs.Max(f => f.Numero) + 1;
        }
        public async Task<Created> Handle(CreateBCFCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateBCFCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var fr = _context.Fournisseurs.Where(c => c.Id == request.FournisseurId).FirstOrDefault();
            var boncommandefournisseur = new Domain.Entities.BonCommandeFournisseur()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Heure = DateTime.Now.ToShortTimeString(),
                VendeurId = new Guid(),
                CreatedBy = request.CreatedBy,
                CodeBC = GenerateCodeBC(),
                MontantTotalHT = decimal.Parse(request.MontantTotalHT.ToString()),
                MontantTotalTTC = decimal.Parse(request.MontantTotalTTC.ToString()),
                MontantTotalTVA = decimal.Parse(request.MontantTotalTVA.ToString()),
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
                MontantTotalHTApresRemise = decimal.Parse(request.MontantTotalHTApresRemise.ToString()),
                RestTotal = decimal.Parse(request.RestTotal.ToString()),
                Rib = request.Rib,
                Rip = request.Rip,

            };
            _context.BonCommandeFournisseurs.Add(boncommandefournisseur);
            request.AbcProducts.ForEach(async item =>
            {
                var stockMatch = _context.Stocks.Where(u => u.Designaation == item.Designation).AsNoTracking().FirstOrDefault();
                var bcp = new AbcProducts
                {
                    BcaId = boncommandefournisseur.Id,
                    Designation = item.Designation,
                    Qte = item.Qte,
                    MontantHT = item.MontantHT,
                    MontantTTC = item.MontantTTC,
                    MontantTVA = item.MontantTVA,
                    Pua = item.Pua,
                    Image = stockMatch.Image,
                    SelectedStockId = stockMatch.Id,
                };
                _context.AbcProducts.Add(bcp);
            }
            );
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }






        public async Task<Created> Handle(TransformerBCFenBACommand request, CancellationToken cancellationToken)
        {
            var validator = new TransformerBCFenBACommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var newBAId = Guid.NewGuid(); // Generate a new unique Id

            // Check if a Bl with the same Id already exists (optional, depending on your requirements)
            var existingBA = await _context.BonAchats.FindAsync(newBAId);
            if (existingBA != null)
            {
                // Handle the case where a Bl with the same Id already exists
                // You can update the existing Bl or handle it according to your application logic
            }
            else
            {
                // Ensure that request.Client is not null and contains valid data
                if (request.Employe != null && request.Employe.Id != Guid.Empty)
                {
                    // Create a new Bl entity
                    var ba = new Domain.Entities.BonAchats()
                    {
                        Id = newBAId, // Use the generated Id
                        Date = request.Bon.Date,
                        Heure = request.Bon.Date.ToShortTimeString(),
                        VendeurId = new Guid(),
                        CreatedBy = request.Bon.CreatedBy,
                        MontantTotalHTApresRemise = request.Bon.MontantTotalHTApresRemise,
                        MontantTotalHT = request.Bon.MontantTotalHT,
                        Remise = request.Bon.Remise,
                        FournisseurId = request.Employe.Id, // Assign the ClientId property
                        Fournisseur = null, // Assign the Client property
                        Timbre = 0,
                        DateEcheance = DateTime.Now,
                        DateFermuture = DateTime.Now,
                        Etat = "Acheté",
                        PaymentMethod = request.Bon.PaymentMethod,
                        RestTotal = request.Bon.MontantTotalTTC,
                        Rib = 0,
                        Rip = 0,
                        MontantTotalTTC = request.Bon.MontantTotalTTC,
                        MontantTotalTVA = request.Bon.MontantTotalTVA,
                        TotalReglement = request.Bon.TotalReglement
                    };

                    // Add the new Ba to the context
                    _context.BonAchats.Add(ba);
                    await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);



                    foreach (var item in request.Bon.AbcProducts)
                    {
                        var stockMatch = await _context.Stocks
                            .Where(u => u.Designaation == item.Designation)
                            .FirstOrDefaultAsync(cancellationToken);

                        if (stockMatch != null)
                        {
                            var blp = new BAProducts
                            {
                                BAId = ba.Id,
                                Designation = item.Designation,
                                Qte = item.Qte,
                                MontantHT = item.MontantHT,
                                MontantTTC = item.MontantTTC,
                                MontantTVA = item.MontantTVA,
                                Pua = item.Pua,
                                Image = stockMatch.Image,
                                SelectedStockId = stockMatch.Id,
                                SelectedStock = stockMatch
                            };
                            _context.BAProducts.Add(blp);
                            await AlimenterStock(blp, cancellationToken);


                        }


                    }
                    await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                    try
                    {




                        // Retrieve the VenteComptoir entity you want to delete
                        var BonCommandeUpdateEtatToReceptionne = _context.BonCommandeFournisseurs
                            .Where(a => a.Id == request.Bon.Id)
                            .FirstOrDefault();

                        if (BonCommandeUpdateEtatToReceptionne != null)
                        {
                            BonCommandeUpdateEtatToReceptionne.Etat = "Receptionné";

                            // Remove the related items from the collection


                            // Delete the VenteComptoir entity
                            _context.BonCommandeFournisseurs.Update(BonCommandeUpdateEtatToReceptionne);

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


        public async Task AlimenterStock(BAProducts bap, CancellationToken cancellationToken)
        {
            var StockedProduct = _context.Stocks.Where(p => p.Designaation == bap.Designation).FirstOrDefault();
            StockedProduct.QteRestante = StockedProduct.QteRestante + bap.Qte;
            _context.Stocks.Update(StockedProduct);
        }
        public async Task<NoContent> Handle(DeleteBCFCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteBCFCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var bon = _context.BonCommandeFournisseurs.Include(v => v.AbcProducts).FirstOrDefault();
            if (bon == null)
                throw new NotFoundException(nameof(BonCommandeFournisseur), request.Id);

            _context.BonCommandeFournisseurs.Remove(bon);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(UpdateBCFCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBCFCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var bonToUpdate = await _context.BonCommandeFournisseurs
                .Include(vp => vp.AbcProducts)
                .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken)
                .ConfigureAwait(false);

            if (bonToUpdate == null)
                throw new NotFoundException(nameof(Domain.Entities.BonCommandeFournisseur), request.Id);



            // Remove old products included in vc
            _context.AbcProducts.RemoveRange(bonToUpdate.AbcProducts);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // Add new products included in request
            foreach (var item in request.AbcProducts)
            {
                var stockMatch = _context.Stocks
                    .Where(u => u.Designaation == item.Designation)
                    .FirstOrDefault();

                var flp = new AbcProducts
                {
                    BcaId = request.Id,
                    Designation = item.Designation,
                    Qte = item.Qte,
                    MontantTTC = item.MontantTTC,
                    MontantHT = item.MontantHT,
                    MontantTVA = item.MontantTVA,
                    Pua = item.Pua,
                    Image = stockMatch.Image,
                    SelectedStockId = stockMatch.Id,
                    SelectedStock = stockMatch
                };
                _context.AbcProducts.Add(flp);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }

            // Update old vente Comptoir with the new values

            var entity = _mapper.Map<Domain.Entities.BonCommandeFournisseur>(request);

            bonToUpdate.MontantTotalHT = request.MontantTotalHT;
            bonToUpdate.MontantTotalTVA = request.MontantTotalTVA;
            bonToUpdate.MontantTotalTTC = request.MontantTotalTTC;
            bonToUpdate.Fournisseur = request.Fournisseur;
            bonToUpdate.Heure = request.Heure;
            bonToUpdate.CreatedBy = request.CreatedBy;
            bonToUpdate.Date = request.Date;
            bonToUpdate.Numero = request.Numero;
            bonToUpdate.VendeurId = request.VendeurId;
            bonToUpdate.FournisseurId = request.FournisseurId;
            bonToUpdate.Timbre = request.Timbre;
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return default;
        }






    }
}