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
using SmartRestaurant.Application.GestionVentes.FactureProformat.Commands;

namespace SmartRestaurant.Application.GestionVentes.VenteParFac.Commands
{
    public class FactureProformatCommandsHandler :
        IRequestHandler<CreateFactureProformatCommand, Created>,
        IRequestHandler<UpdateFactureProformatCommand, NoContent>,
        IRequestHandler<DeleteFactureProformatCommand, NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FactureProformatCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public string GenerateCodeFP()
        {
            const string codeBCprefix = "FP";
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
            if (_context.factureProformats.Count() == 0) return 1;
            else
                return _context.factureProformats.Max(f => f.Numero) + 1;
        }
        public async Task<Created> Handle(CreateFactureProformatCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateFactureProformatCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var client = _context.Clients.Where(c => c.Id == request.ClientId).FirstOrDefault();
            var fac = new Domain.Entities.FactureProformat()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Heure = DateTime.Now.ToShortTimeString(),
                VendeurId = new Guid(),
                CodeFP=GenerateCodeFP(),
                MontantTotalHT = decimal.Parse(request.MontantTotalHT.ToString()),
                MontantTotalTTC = decimal.Parse(request.MontantTotalTTC.ToString()),
                MontantTotalTVA = decimal.Parse(request.MontantTotalTVA.ToString()),
                ClientId=request.ClientId,
                CreatedBy=request.CreatedBy,
                Client = client,
                TotalReglement=request.TotalReglement,
                Numero=request.Numero,
                Timbre=request.Timbre,
                DateEcheance=request.DateEcheance,
                DateFermuture=request.DateFermuture,
                Etat=request.Etat,
                PaymentMethod=request.PaymentMethod,
                Remise=request.Remise,
                MontantTotalHTApresRemise= decimal.Parse(request.MontantTotalHTApresRemise.ToString()),
                RestTotal= decimal.Parse(request.RestTotal.ToString()),
                Rib=request.Rib,
                Rip=request.Rip,
             
            };
            _context.factureProformats.Add(fac);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            request.FacProProducts.ForEach( item =>
            {
                var stockMatch = _context.Stocks.Where(u => u.Designaation == item.Designation).AsNoTracking().FirstOrDefault();
                var flp = new FacProProducts
                {
                    FactureProformatId = fac.Id,
                    Designation = item.Designation,
                    Qte = item.Qte,
                    MontantHT= item.MontantHT,
                    MontantTTC=item.MontantTTC,
                    MontantTVA=item.MontantTVA,
                    Puv = item.Puv,
                    Image = stockMatch.Image,
                    SelectedStockId = stockMatch.Id,
                   
                };
                _context.FacProProducts.Add(flp);
            }
  );
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }




       
      
        
        public async Task<NoContent> Handle(DeleteFactureProformatCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteFactureProformatCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var facpro =  _context.factureProformats.Include(v=>v.FacProProducts).FirstOrDefault();
            if (facpro == null)
                throw new NotFoundException(nameof(Stock), request.Id);

           
            _context.factureProformats.Remove(facpro);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(UpdateFactureProformatCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateFactureProformatCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var fac = await _context.factureProformats
                .Include(vp => vp.FacProProducts)
                .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken)
                .ConfigureAwait(false);

            if (fac == null)
                throw new NotFoundException(nameof(Stock), request.Id);

          

            // Remove old products included in vc
            _context.FacProProducts.RemoveRange(fac.FacProProducts);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // Add new products included in request
            foreach (var item in request.FacProProducts)
            {
                var stockMatch = _context.Stocks
                    .Where(u => u.Designaation == item.Designation)
                    .FirstOrDefault();

                var flp = new FacProducts
                {
                    FactureId = request.Id,
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
                _context.FacProducts.Add(flp);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);


            }

            // Update old vente Comptoir with the new values

            var entity = _mapper.Map<Domain.Entities.FactureProformat>(request);

            fac.MontantTotalHT = request.MontantTotalHT;
            fac.MontantTotalTVA = request.MontantTotalTVA;
            fac.MontantTotalTTC = request.MontantTotalTTC;
            fac.Client=request.Client;
            fac.CreatedBy = request.CreatedBy;
            fac.Heure=request.Heure;
            fac.Date=request.Date;
            fac.Numero=request.Numero;
            fac.VendeurId=request.VendeurId;
            fac.ClientId=request.ClientId;
            fac.Timbre=request.Timbre;
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return default;
        }





     

    }
}