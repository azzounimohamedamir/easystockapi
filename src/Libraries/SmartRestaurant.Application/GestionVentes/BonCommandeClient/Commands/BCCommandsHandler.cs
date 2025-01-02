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

namespace SmartRestaurant.Application.GestionVentes.BonCommandeClient.Commands
{
    public class BCCommandsHandler :
        IRequestHandler<CreateBCCommand, Created>,
        IRequestHandler<TransformerBCenBLCommand, Created>,
        IRequestHandler<UpdateBCCommand, NoContent>,
        IRequestHandler<DeleteBCCommand, NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BCCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }




        public async Task<Created> Handle(CreateBCCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateBCCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var client = _context.Clients.Where(c => c.Id == request.ClientId).FirstOrDefault();
            var boncommande = new Domain.Entities.BonCommandeClient()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Heure = DateTime.Now.ToShortTimeString(),
                VendeurId = new Guid(),
                CreatedBy=request.CreatedBy,
                CodeBC=GenerateCodeBC(),
                MontantTotalHT = decimal.Parse(request.MontantTotalHT.ToString()),
                MontantTotalTTC = decimal.Parse(request.MontantTotalTTC.ToString()),
                MontantTotalTVA = decimal.Parse(request.MontantTotalTVA.ToString()),
                MontantTotalHTApresRemise = decimal.Parse(request.MontantTotalHTApresRemise.ToString()),
                RestTotal = decimal.Parse(request.RestTotal.ToString()),
                ClientId =request.ClientId,
                Client = client,
                TotalReglement=request.TotalReglement,
                Numero=request.Numero,
                Timbre=request.Timbre,
                DateEcheance=request.DateEcheance,
                DateFermuture=request.DateFermuture,
                Etat=request.Etat,
                PaymentMethod=request.PaymentMethod,
                Remise=request.Remise,
                Rib=request.Rib,
                Rip=request.Rip,
             
            };
            _context.BonCommandeClients.Add(boncommande);
            request.BcProducts.ForEach(async item =>
            {
                var stockMatch = _context.Stocks.Where(u => u.Designaation == item.Designation).AsNoTracking().FirstOrDefault();
                var bcp = new BcProducts
                {
                    BcId = boncommande.Id,
                    Designation = item.Designation,
                    Qte = item.Qte,
                    MontantHT= item.MontantHT,
                    MontantTTC=item.MontantTTC,
                    MontantTVA=item.MontantTVA,
                    Puv = item.Puv,
                    Image = stockMatch.Image,
                    SelectedStockId= stockMatch.Id,
                };
                _context.BcProducts.Add(bcp);
            }
            );
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }






        public async Task<Created> Handle(TransformerBCenBLCommand request, CancellationToken cancellationToken)
        {
            var validator = new TransformerBCenBLCommandValidator();
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
                        Date = request.Bon.Date,
                        Heure = request.Bon.Date.ToShortTimeString(),
                        VendeurId = new Guid(),
                        NomCaissier = request.Bon.CreatedBy!=""? request.Bon.CreatedBy:"",
                        MontantTotalHTApresRemise = request.Bon.MontantTotalHTApresRemise,
                        MontantTotalHT = request.Bon.MontantTotalHT,
                        Remise = request.Bon.Remise,
                        ClientId = request.Client.Id, // Assign the ClientId property
                        Client = null, // Assign the Client property
                        Timbre = 0,
                        DateEcheance = DateTime.Now,
                        DateFermuture = DateTime.Now,
                        Etat = "Non Réglé",
                        PaymentMethod = request.Bon.PaymentMethod,
                        RestTotal = request.Bon.MontantTotalTTC,
                        Rib = 0,
                        Rip = 0,
                        MontantTotalTTC = request.Bon.MontantTotalTTC,
                        MontantTotalTVA = request.Bon.MontantTotalTVA,
                        TotalReglement = request.Bon.TotalReglement
                    };

                    // Add the new Bl to the context
                    _context.Bls.Add(bl);
                    await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                    foreach (var item in request.Bon.BcProducts)
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
                        var BCUpdateEtatToLivre = _context.BonCommandeClients
                            .Where(a => a.Id==request.Bon.Id)
                            .FirstOrDefault();

                        if (BCUpdateEtatToLivre != null)
                        {
                            BCUpdateEtatToLivre.Etat = "Livré";

                            // Remove the related items from the collection
                            

                            // Delete the VenteComptoir entity
                            _context.BonCommandeClients.Update(BCUpdateEtatToLivre);

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
            if (_context.BonCommandeClients.Count() == 0) return 1;
            else
                return _context.BonCommandeClients.Max(f => f.Numero) + 1;
        }

        public async Task<NoContent> Handle(DeleteBCCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteBCCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var bon =  _context.BonCommandeClients.Include(v=>v.BcProducts).FirstOrDefault();
            if (bon == null)
                throw new NotFoundException(nameof(BonCommandeClient), request.Id);

            _context.BonCommandeClients.Remove(bon);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(UpdateBCCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBCCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var bonToUpdate = await _context.BonCommandeClients
                .Include(vp => vp.BcProducts)
                .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken)
                .ConfigureAwait(false);

            if (bonToUpdate == null)
                throw new NotFoundException(nameof(Domain.Entities.BonCommandeClient), request.Id);

           

            // Remove old products included in vc
            _context.BcProducts.RemoveRange(bonToUpdate.BcProducts);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // Add new products included in request
            foreach (var item in request.BcProducts)
            {
                var stockMatch = _context.Stocks
                    .Where(u => u.Designaation == item.Designation)
                    .FirstOrDefault();

                var flp = new BcProducts
                {
                    BcId = request.Id,
                    Designation = item.Designation,
                    Qte = item.Qte,
                    MontantTTC = item.MontantTTC,
                    MontantHT= item.MontantHT,
                    MontantTVA= item.MontantTVA,
                    Puv = item.Puv,
                    Image = stockMatch.Image,
                    SelectedStockId = stockMatch.Id,
                    SelectedStock = stockMatch
                };
                _context.BcProducts.Add(flp);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }

            // Update old vente Comptoir with the new values

            var entity = _mapper.Map<Domain.Entities.BonCommandeClient>(request);

            bonToUpdate.MontantTotalHT = decimal.Parse(request.MontantTotalHT.ToString());
                bonToUpdate.MontantTotalTTC = decimal.Parse(request.MontantTotalTTC.ToString());
            bonToUpdate.MontantTotalTVA = decimal.Parse(request.MontantTotalTVA.ToString());
            bonToUpdate.MontantTotalHTApresRemise = decimal.Parse(request.MontantTotalHTApresRemise.ToString());
            bonToUpdate.RestTotal = decimal.Parse(request.RestTotal.ToString());
            bonToUpdate.Client=request.Client;
            bonToUpdate.Remise = request.Remise;
            bonToUpdate.CreatedBy=request.CreatedBy;
            bonToUpdate.Heure=request.Heure;
            bonToUpdate.Date=request.Date;
            bonToUpdate.Numero=request.Numero;
            bonToUpdate.VendeurId=request.VendeurId;
            bonToUpdate.ClientId=request.ClientId;
            bonToUpdate.Timbre=request.Timbre;
            bonToUpdate.TotalReglement=request.TotalReglement;
            _context.BonCommandeClients.Update(bonToUpdate);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return default;
        }





     
    }
}