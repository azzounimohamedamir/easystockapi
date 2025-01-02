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
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;
using System.Net.Mail;
using System.Net;
using SendGrid.Helpers.Mail;
using SendGrid;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using DinkToPdf.Contracts;
using DinkToPdf;
using static SmartRestaurant.Application.GestionVentes.VenteParFac.Commands.FactureCommandsHandler;
using EllipticCurve.Utils;
using System.Text;
using SendGrid.Helpers.Mail.Model;
using Aspose.Pdf;
using Org.BouncyCastle.Asn1.Ocsp;

namespace SmartRestaurant.Application.GestionVentes.VenteParFac.Commands
{
    public class FactureCommandsHandler :
        IRequestHandler<CreateFactureCommand, Created>,
        IRequestHandler<RegroupFactureCommand, Facture>,
        IRequestHandler<AjouterRegAcompteFactureCommand, Created>,
        IRequestHandler<SendFactureByEmailCommand, Created>,
        IRequestHandler<UpdateFactureCommand, NoContent>,
        IRequestHandler<DeleteFactureCommand, NoContent>
    {
        private readonly IApplicationDbContext _context;

        private readonly IApplicationDbContext _context2;
        private readonly IMapper _mapper;
        private readonly string _sendGridKey;
        private readonly string _sendGridUser;
        private readonly IConfiguration _configuration;
        public FactureCommandsHandler( IConverter pdfConverter,IConfiguration configuration, IApplicationDbContext context , IApplicationDbContext context2, IMapper mapper)
        {

            _context = context;
            _context2 = context2;
            _configuration = configuration;
            _mapper = mapper;

    }

    public async Task<Created> Handle(CreateFactureCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateFactureCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var client = _context.Clients.Where(c => c.Id == request.ClientId).FirstOrDefault();
            var fac = new Facture()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Heure = DateTime.Now.ToShortTimeString(),
                VendeurId = new Guid(),
                NomCaissier = request.NomCaissier,
                Caisse = request.Caisse,
                CouponPrice=request.CouponPrice,
                MontantTotalHT = decimal.Parse(request.MontantTotalHT.ToString()),
                MontantTotalTTC = decimal.Parse(request.MontantTotalTTC.ToString()),
                MontantTotalTVA = decimal.Parse(request.MontantTotalTVA.ToString()),
                ClientId = request.ClientId,
                Client = client,
                TotalReglement = request.TotalReglement,
                Numero = request.Numero,
                CodeF = GenerateCodeF(request.Caisse,"F"),
                Timbre = request.Timbre,
                DateEcheance = request.DateEcheance,
                DateFermuture = request.DateFermuture,
                Etat = request.RestTotal == 0 ? "Reglé" : "Non Réglé",
                PaymentMethod = request.PaymentMethod,
                Remise = request.Remise,
                MontantTotalHTApresRemise = decimal.Parse(request.MontantTotalHTApresRemise.ToString()),
                RestTotal = decimal.Parse(request.RestTotal.ToString()),
                Rib = request.Rib,
                Rip = request.Rip,

            };

            _context.Factures.Add(fac);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            if(request.CouponPrice!=0)
            {
                var clientRemoveCoupon = _context.ClientFidelites.FirstOrDefault(c => c.Id == fac.ClientId);
                clientRemoveCoupon.Withdraw = 0;
                clientRemoveCoupon.NiveauFidelite = _context.NiveauFidelites.Where(a => a.MinPointsRequis == 0).FirstOrDefault();
                clientRemoveCoupon.NiveauFideliteId = _context.NiveauFidelites.Where(a => a.MinPointsRequis == 0).FirstOrDefault().Id;
                clientRemoveCoupon.Points = 0;
                _context.ClientFidelites.Update(clientRemoveCoupon);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }


            request.FacProducts.ForEach(async item =>
            {
                var stockMatch = _context.Stocks.Where(u => u.Designaation == item.Designation).AsNoTracking().FirstOrDefault();
                var flp = new FacProducts
                {
                    FactureId = fac.Id,
                    Designation = item.Designation,
                    Qte = item.Qte,
                    MontantHT = item.MontantHT,
                    MontantTTC = item.MontantTTC,
                    MontantTVA = item.MontantTVA,
                    Puv = item.Puv,
                    LastPuv= item.LastPuv,
                    Reduction= item.Reduction,
                    HasReduction=item.HasReduction,
                    Image = stockMatch.Image,
                    SelectedStockId = stockMatch.Id,
                    SelectedStock = stockMatch
                };
                _context.FacProducts.Add(flp);
                await AddSortieStock(flp, fac, cancellationToken);

                await Destocker(flp, cancellationToken);

            });
            

            
            if (request.RestTotal == 0) // avances encore existe
            {
                await UpdateAvanceClient(request.Client, cancellationToken);
            }
            else // client n'as pas davance =0 , donc son credit augmente
            {

                await UpdateCreditClient(fac, null,client, cancellationToken);
            }

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }


        public async Task AddSortieStock(FacProducts flp, Domain.Entities.Facture fac, CancellationToken cancellationToken)
        {
            var SortieProduct =  _context.Stocks
                .Where(p => p.Designaation == flp.Designation)
                .FirstOrDefault();


            MouvementStock mvt = new MouvementStock
            {
                Id = Guid.NewGuid(),
                DateMvt = fac.Date,
                ProduitId = SortieProduct.Id,
                ProduitName = SortieProduct.Designaation,
                Qte = flp.Qte,
                TypeMouvement = TypeMouv.Sortie
            };
            _context.MouvementStocks.Add(mvt);
        }
        public string GenerateCodeF(int caisse , string type)
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


        public int generateAvoirNumero (int facNum)
        {
            // Generate a random number between 0 and 99
            Random rnd = new Random();
            int randomSuffix = rnd.Next(0, 100);

            // Concatenate the original invoice number with the random suffix
            string invoiceNumber = $"{facNum}{randomSuffix}";

            // Convert the concatenated string to an integer
            int newInvoiceNumber = int.Parse(invoiceNumber);
            return newInvoiceNumber;
        }
        private int GetNextInvoiceNumberFromDatabase()
        {
            // Retrieve the current invoice number from the database
            // This could involve querying the database or using a dedicated service to manage invoice numbers
            // In this example, let's assume you have a method to retrieve the next sequential number
            // You may need to implement this based on your database structure and business rules
            // For simplicity, I'm using a placeholder value here
            if (_context.Factures.Count() == 0) return 1;
            else
                return _context.Factures.Max(f => f.Numero) + 1;
        }


        public async Task<Created> Handle(AjouterRegAcompteFactureCommand request, CancellationToken cancellationToken)
        {
            var validator = new AjouterRegAcompteFactureCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var facture = _context.Factures.Where(f => f.Id == request.FactureId).FirstOrDefault();
            var client = _context.Clients.Where(f => f.Id == request.Client.Id).FirstOrDefault();


            if (request.Type == "Acompte")
            {
                facture.RestTotal = facture.RestTotal - request.Montant;

                facture.TotalReglement = facture.TotalReglement + request.Montant;
                if (facture.RestTotal <= 0)
                {
                    facture.Etat = "Reglé";
                }


                _context.Factures.Update(facture).Property(x => x.Numero).IsModified = false;

                var acompte = _mapper.Map<Domain.Entities.Reglement_Acompte_Facture_Client>(request);
                acompte.Client = client;
                _context.Reglement_Acompte_Facture_Clients.Add(acompte);
                await UpdateCreditClient(null, acompte,client, cancellationToken);

                if(facture.BlId != Guid.Empty)
                {
                    var blAssocied = _context.Bls.FirstOrDefault(bl => bl.Id == facture.BlId);
                    blAssocied.TotalReglement = facture.RestTotal;
                    blAssocied.RestTotal = facture.RestTotal;
                    _context.Bls.Update(blAssocied);
                }
                

                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            else if (request.Type == "Reglement")
            {
                facture.RestTotal = 0;
                facture.Etat = "Reglé";
                facture.TotalReglement = facture.RestTotal;
                _context.Factures.Update(facture).Property(x => x.Numero).IsModified = false;
                


                var blAssocied = _context.Bls.FirstOrDefault(bl => bl.Id == facture.BlId);
                if ( blAssocied != null)
                 {    
                    blAssocied.TotalReglement = facture.RestTotal;
                    blAssocied.RestTotal = facture.RestTotal;
                    _context.Bls.Update(blAssocied);
                }
               
                var reglement = _mapper.Map<Domain.Entities.Reglement_Acompte_Facture_Client>(request);
                var clientReg = _context.Clients.FirstOrDefault(c => c.Id == client.Id);
                reglement.Client = clientReg;
                _context.Reglement_Acompte_Facture_Clients.Add(reglement);
                await UpdateCreditClient(null, reglement, clientReg, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }

            return default;

        }




       

          

        

        public async Task<Created> Handle(SendFactureByEmailCommand request, CancellationToken cancellationToken)
        {
            var validator = new SendFactureByEmailCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            try
            {
                // Validate email address
                if (string.IsNullOrEmpty(request.Email))
                {
                    throw new ArgumentException("Email address is required.");
                }

                // Retrieve SMTP client information from appsettings.json
                var smtpServer = _configuration["Smtp:Server"];
                var smtpEmail = _configuration["Smtp:Email"];
                var smtpPass = _configuration["Smtp:Pass"];
                var smtpPort = int.Parse(_configuration["Smtp:Port"]); // Convert port to integer

                // Convert HTML and CSS content to PDF byte array
                var pdfBytes = GeneratePdfFromHtml(request.PdfLink);

                var facture = _context.Factures.Where(fac => fac.Id == request.FactureId).Include(v => v.FacProducts).ThenInclude(p => p.SelectedStock).Include(c => c.Client).FirstOrDefault();

                var societe = _context.SocieteInfos.FirstOrDefault();

                // Create SMTP client
                using (var client = new SmtpClient(smtpServer, smtpPort))
                {
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(smtpEmail, smtpPass);
                    client.EnableSsl = true;

                    // Create and send email with attachment
                    using (var message = new MailMessage(new MailAddress(smtpEmail), new MailAddress(request.Email)))
                    {
                        message.Subject = "Votre facture";
                        message.IsBodyHtml = true;

                        // Build the email body with invoice details
                        StringBuilder bodyBuilder = new StringBuilder();
                        bodyBuilder.AppendLine($"<h2>Votre facture {facture.CodeF}</h2>");
                        bodyBuilder.AppendLine($"<p>Cher/Chère Client {facture.Client.FullName},</p>");
                        bodyBuilder.AppendLine($"<p>Nous espérons que vous allez bien. Nous tenons à vous remercier pour votre récente commande chez {societe.NomSociete}. Conformément à notre politique de facturation, veuillez trouver ci-joint votre facture pour la commande numéro {facture.Numero}, datée du {facture.Date}.</p>");
                        bodyBuilder.AppendLine("<h3>Détails de la facture :</h3>");
                        bodyBuilder.AppendLine("<ul>");
                        bodyBuilder.AppendLine($"<li><strong>Numéro de facture :</strong> {facture.Numero}</li>");
                        bodyBuilder.AppendLine($"<li><strong>Date d'émission :</strong> {facture.Date}</li>");
                        bodyBuilder.AppendLine($"<li><strong>Montant total :</strong> {facture.RestTotal}</li>");
                        bodyBuilder.AppendLine($"<li><strong>Méthode de paiement :</strong> {facture.PaymentMethod}</li>");
                        bodyBuilder.AppendLine("</ul>");
                        bodyBuilder.AppendLine($"<p>Veuillez noter que le paiement est dû dans un délai de {(int)(facture.DateEcheance - facture.Date).TotalDays} jours à compter de la date d'émission de la facture.</p>");
                        bodyBuilder.AppendLine($"<p>Pour régler votre facture, veuillez utiliser les informations de paiement fournies sur la facture ou visitez notre site Web <a href='{societe.Siteweb}'>{societe.Siteweb}</a> pour effectuer votre paiement en ligne de manière sécurisée.</p>");
                        bodyBuilder.AppendLine($"<p>Si vous avez des questions concernant cette facture ou si vous avez besoin d'une assistance supplémentaire, n'hésitez pas à nous contacter à l'adresse <a href='mailto:{societe.Email}'>{societe.Email}</a> ou par téléphone au {societe.Telephone}.</p>");
                        bodyBuilder.AppendLine("<p>Nous vous remercions encore pour votre confiance en notre entreprise et nous nous réjouissons de continuer à vous servir à l'avenir.</p>");
                        bodyBuilder.AppendLine("<p>Cordialement,</p>");
                        bodyBuilder.AppendLine($"<p>{societe.NomSociete}<br/>{societe.Adresse}<br/>{societe.Telephone}<br/><a href='mailto:{societe.Email}'>{societe.Email}</a><br/><a href='{societe.Siteweb}'>{societe.Siteweb}</a></p>");


                        message.Body = bodyBuilder.ToString();











                        // Attach the PDF byte array to the email
                        using (var stream = new MemoryStream(pdfBytes))
                        {
                            message.Attachments.Add(new System.Net.Mail.Attachment(stream, "facture.pdf", "application/pdf"));
                            await client.SendMailAsync(message);
                        }
                    }
                }

                return default;
            }
            catch (Exception ex)
            {
                // Handle exception
                throw new Exception("Failed to send email: " + ex.Message);
            }
        }


        public byte[] GeneratePdfFromHtml(string htmlContent)
        {
            using (MemoryStream outputStream = new MemoryStream())
            {
                // Initialize a new Document object.
                Document pdfDocument = new Document();

                // Create HtmlFragment from HTML string
                HtmlFragment htmlFragment = new HtmlFragment(htmlContent);
                HtmlLoadOptions htmlOptions = new HtmlLoadOptions();

                // Set page size to A4
                pdfDocument.PageInfo.Width = PageSize.A4.Width;
                pdfDocument.PageInfo.Height = PageSize.A4.Height;
                pdfDocument.PageInfo.Margin.Bottom = 5;
                pdfDocument.PageInfo.Margin.Top = 5;
                pdfDocument.PageInfo.Margin.Left = 5;
                pdfDocument.PageInfo.Margin.Right = 5;

                foreach (Page page in pdfDocument.Pages)
                {
                    page.CropBox = new Aspose.Pdf.Rectangle(0, 0, page.Rect.Width, page.Rect.Height);
                }


                // Add HtmlFragment to the page
                pdfDocument.Pages.Add().Paragraphs.Add(htmlFragment);

                // Save the PDF to the memory stream.
                pdfDocument.Save(outputStream);

                // Close the document.
                pdfDocument.Dispose();

                // Return the PDF byte array.
                return outputStream.ToArray();
            }
        }
        public async Task Destocker(FacProducts flp, CancellationToken cancellationToken)
        {
            var DestockedProduct = _context.Stocks.Where(p => p.Designaation == flp.Designation).FirstOrDefault();
           
            DestockedProduct.QteRestante = DestockedProduct.QteRestante - flp.Qte;
            _context.Stocks.Update(DestockedProduct);
        }


        public async Task UpdateCreditClient(Facture fac, Reglement_Acompte_Facture_Client reglement , Client client, CancellationToken cancellationToken)
        {

            if (fac != null && reglement == null)
            {
                if (fac.RestTotal >= fac.Client.TotalAvances)
                {
                    fac.Client.TotalAvances = 0;
                }
                if (fac.Client != null)
                    fac.Client.TotalCredits += fac.RestTotal;
                if (fac.Client.DateEcheance <= DateTime.Now && fac.Client.TotalCredits > 0)
                {
                    fac.Client.IsBanned = true;
                }

                else
                {
                    fac.Client.IsBanned = false;
                }
                _context.Clients.Update(fac.Client);
            }
            else if (reglement != null  && fac == null && client != null)
            {
                if (client != null)
                {
                    client.TotalCredits = client.TotalCredits - reglement.Montant;
                    if (reglement.Client.DateEcheance <= DateTime.Now && reglement.Client.TotalCredits > 0)
                    {
                        client.IsBanned = true;
                    }
                    else
                    {
                        client.IsBanned = false;
                    }
                }
                _context.Clients.Update(client);
            }
        }


        public async Task UpdateAvanceClient(Client cl, CancellationToken cancellationToken)
        {

            var client = _context.Clients.Where(c => c.Id == cl.Id).FirstOrDefault();
            client.TotalAvances = cl.TotalAvances;
            _context.Clients.Update(client);

        }



        public async Task Restorer(FacProducts flp, CancellationToken cancellationToken)
        {
            var RestoredProduct = _context.Stocks.Where(p => p.Designaation == flp.Designation).FirstOrDefault();
            RestoredProduct.QteRestante = RestoredProduct.QteRestante + flp.Qte;
            _context.Stocks.Update(RestoredProduct);



        }

        public async Task<NoContent> Handle(DeleteFactureCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteFactureCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var fac = _context.Factures
                .Where(f => f.Id == request.Id)
                .Include(v => v.FacProducts)
                .Include(c=>c.Client)
                .FirstOrDefault();
            fac.Etat = "Annulé";
            _context.Factures.Update(fac);
            if(fac.CouponPrice!=0 && fac.CouponPrice !=null)
            {
              var  restorPointToClient = _context.ClientFidelites.Where(c => c.Nom == fac.Client.FullName).FirstOrDefault();
                restorPointToClient.Withdraw= restorPointToClient.Points + (int)(fac.CouponPrice);
                _context.ClientFidelites.Update(restorPointToClient);
                restorPointToClient.Points = restorPointToClient.Points + (int)(fac.CouponPrice);
                _context.ClientFidelites.Update(restorPointToClient);
            }

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            if (fac == null)
                throw new NotFoundException(nameof(Stock), request.Id);


            var facAvoir = new Facture()
            {
                Date = DateTime.Now,
                Heure = DateTime.Now.ToShortTimeString(),
                VendeurId = Guid.NewGuid(),
                NomCaissier = fac.NomCaissier,
                Caisse = fac.Caisse,
                MontantTotalHT = -1 * fac.MontantTotalHT, // Inverting MontantTotalHT
                MontantTotalTTC = -1 * fac.MontantTotalTTC, // Inverting MontantTotalTTC
                MontantTotalTVA = -1 * fac.MontantTotalTVA, // Inverting MontantTotalTVA
                ClientId = fac.ClientId,
                Client = fac.Client,
                TotalReglement = fac.TotalReglement,
                Numero = 0,
                CodeF = GenerateCodeF(fac.Caisse, "AV"),
                Timbre = -1 * fac.Timbre, // Inverting Timbre
                DateEcheance = fac.DateEcheance,
                DateFermuture = fac.DateFermuture,
                Etat = "🗑 Avoir Sur " + fac.CodeF,
                PaymentMethod = fac.PaymentMethod,
                Remise = -1 * fac.Remise, // Inverting Remise
                MontantTotalHTApresRemise = -1 * fac.MontantTotalHTApresRemise, // Inverting MontantTotalHTApresRemise
                RestTotal = -1 * fac.RestTotal, // Inverting RestTotal
                Rib = fac.Rib,
                Rip = fac.Rip
            };

            _context.Factures.Add(facAvoir);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // Synchronously restore each item
            foreach (var item in fac.FacProducts)
            {   
                await Restorer(item, cancellationToken).ConfigureAwait(false);

                var stockAvoir = _context.Stocks.Where(u => u.Designaation == item.Designation).AsNoTracking().FirstOrDefault();
                var flp = new FacProducts
                {
                    Id= Guid.NewGuid(),
                    FactureId = facAvoir.Id,
                    Designation = item.Designation,
                    Qte = item.Qte,
                    MontantHT = -1*item.MontantHT,
                    MontantTTC = -1*item.MontantTTC,
                    MontantTVA = -1*item.MontantTVA,
                    Puv = -1*item.Puv,
                    Image = item.Image,
                    SelectedStockId = item.SelectedStock.Id,
                    SelectedStock = item.SelectedStock
                };
                _context.FacProducts.Add(flp);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);


            }
            // create Avoir Negatif to rectifier 

















            //        FactureAvoir avoir = new FactureAvoir
            //        {
            //            Id = Guid.NewGuid(),
            //            IsDeleted = false,
            //            IdFactureOriginal = fac.Id,
            //            DateAvoir = DateTime.Now,
            //            OriginalFacture= fac,
            //            HeureAvoir = DateTime.Now.ToString("HH:mm"),
            //            ProduitsRetournes = _mapper.Map<List<Domain.Entities.RetourProductsAvoir>>(fac.FacProducts),
            //            TypeAvoir = TypeAvoir.Suppression
            //        };

            //        // Now that avoir.Id is generated, use it to set IdAvoir in MotifModification
            //        avoir.MotifsAvoir = new List<MotifModification>
            //{
            //    new MotifModification
            //    {
            //        ModificationAt = DateTime.Now.ToString("HH:mm:ss"),
            //        Motif = Motif.Suppression,
            //        LigneFactureItem=LigneFactureItems.None,
            //        AncienneValeur = "",
            //        NouvelleValeur = "",
            //        IdAvoir = avoir.Id
            //    }
            //};







            //        // sauvegarder l'avoir de suppression sur facture 
            //        _context.FactureAvoirs.Add(avoir);
            //        fac.IsDeleted = true;
            //        // supprimer la facture originale
            //        _context.Factures.Update(fac);

            //        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);



            // creation d'une facture avoir d'annulation Négatif









            return default;
        }






        public async Task<NoContent> Handle(UpdateFactureCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateFactureCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid)
            {
                // Log validation errors or handle them appropriately
                throw new ValidationException(result);
            }

            var fac = await _context.Factures
                .Include(vp => vp.FacProducts)
                .ThenInclude(s=>s.SelectedStock)
                 .Include(vp => vp.FacProducts)
                .ThenInclude(s => s.SelectedStock)
                 .Include(vp => vp.FacProducts)
                .ThenInclude(s => s.SelectedStock)
                .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken)
                .ConfigureAwait(false);
            fac.Etat = "Modifié";
            _context.Factures.Update(fac);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);


            var clientForReq = _context.Clients.Where(c=>c.Id==request.ClientId).FirstOrDefault();


            if (fac == null)
            {
                // Log or handle the case where the Facture is not found
                throw new NotFoundException(nameof(Stock), request.Id);
            }

           
            // créer un avoir sur cette facture ancienne a partir des nouveeaux modification
            var facAvoir = new Facture()
            {
                Date = DateTime.Now,
                Heure = DateTime.Now.ToShortTimeString(),
                VendeurId = Guid.NewGuid(),
                NomCaissier = request.NomCaissier,
                Caisse = request.Caisse,
                CouponPrice=request.CouponPrice,
                MontantTotalHT = -1*request.MontantTotalHT, // Inverting MontantTotalHT
                MontantTotalTTC = -1 * request.MontantTotalTTC, // Inverting MontantTotalTTC
                MontantTotalTVA = -1 * request.MontantTotalTVA, // Inverting MontantTotalTVA
                ClientId = clientForReq.Id,
                Client = clientForReq,
                TotalReglement = -1 * request.TotalReglement,
                Numero = 0,
                CodeF = GenerateCodeF(request.Caisse, "AV"),
                Timbre = request.Timbre, // Inverting Timbre
                DateEcheance = request.DateEcheance,
                DateFermuture = request.DateFermuture,
                Etat = "✏️ Avoir Sur " + fac.CodeF,
                PaymentMethod = request.PaymentMethod,
                Remise = request.Remise, // Inverting Remise
                MontantTotalHTApresRemise = -1 * request.MontantTotalHTApresRemise, // Inverting MontantTotalHTApresRemise
                RestTotal = -1 * request.RestTotal, // Inverting RestTotal
                Rib = request.Rib,
                Rip = request.Rip
            };

            _context.Factures.Add(facAvoir);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);


            // ne pas supprimer les items inclus ds Facture anc pour garder les tracabilités de la facture ancienne
            //_context.FacProducts.RemoveRange(fac.FacProducts);
            //await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            // reStocker les elements de la facture ancienne
            foreach (var item in fac.FacProducts)
            {
                await Restorer(item, cancellationToken);
            }

            foreach (var item in request.FacProducts)
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
                    MontantHT =  -1*item.MontantHT,
                    MontantTTC = -1*item.MontantTTC,
                    MontantTVA =  -1*item.MontantTVA,
                    Puv =  -1*item.Puv,
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


            foreach (var item in request.FacProducts)
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
                    MontantHT =  item.MontantHT,
                    MontantTTC = item.MontantTTC,
                    MontantTVA = item.MontantTVA,
                    Puv =  item.Puv,
                    Image = item.Image,
                    SelectedStockId = stockMatch.Id,
                    SelectedStock = stockMatch
                };
                _context.FacProducts.Add(flp);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                await Destocker(flp, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            }



            // Update old vente Comptoir with the new values
            // UpdateFactureEntity(facAvoir, request);

            // Save changes to the database

            return default;
        }

        private FactureAvoir CreateAvoir(UpdateFactureCommand request, Facture fac)
        {
            var produitAjoutes = _mapper.Map<List<AjoutProductsAvoir>>(
                request.FacProducts
                    .Where(fp => !fac.FacProducts.Any(rfp => rfp.Designation == fp.Designation))
                    .ToList());

            FactureAvoir avoir = new FactureAvoir
            {
                Id = Guid.NewGuid(),
                IdFactureOriginal = fac.Id,
                DateAvoir = DateTime.Now,
                OriginalFacture = fac,
                HeureAvoir = DateTime.Now.ToString("HH:mm"),
                ProduitsRetournes = _mapper.Map<List<Domain.Entities.RetourProductsAvoir>>(
                    fac.FacProducts
                        .Where(fp => !request.FacProducts.Any(rfp => rfp.Designation == fp.Designation))
                        .ToList()),
                ProduitsAjouterAuStock = produitAjoutes
            };

            avoir.MotifsAvoir = CheckForModifications(fac, avoir, request);
            avoir.ProduitsAjouterAuStock.ForEach(prod =>
            {
                prod.FactureAvoir = avoir;
                prod.FactureAvoirId = avoir.Id;

            }
            );
            avoir.ProduitsRetournes.ForEach(prod =>
            {
                prod.FactureAvoirId = avoir.Id;
            }
            );
            _context.FactureAvoirs.Add(avoir);

            return avoir;
        }

        private async Task ProcessFacProduct(Facture fac,FacProducts item, CancellationToken cancellationToken)
        {
            var stockMatch = await _context.Stocks
           
                .Where(u => u.Designaation == item.Designation)
                .FirstOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false);



            try
            {
                // Check if a record with the same FactureId already exists
                var existingRecord = await _context.FacProducts
                    .FirstOrDefaultAsync(fp => fp.FactureId == fac.Id, cancellationToken);

                if (existingRecord != null)
                {
                    await Destocker(existingRecord, cancellationToken);

                    // Handle the case where a record with the same FactureId already exists
                    // You might want to throw an exception, log an error, or take appropriate action
                }
                else
                {
                    // Proceed with adding the new FacProducts record
                    var flp = new FacProducts
                    {
                        FactureId = fac.Id,
                        Facture = fac,
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

                    _context.FacProducts.Add(flp);
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

        private void UpdateFactureEntity(Facture fac, UpdateFactureCommand request)
        {
            fac.MontantTotalHT = request.MontantTotalHT;
            fac.MontantTotalTVA = request.MontantTotalTVA;
            fac.MontantTotalTTC = request.MontantTotalTTC;
            fac.Client = request.Client;
            fac.RestTotal = request.RestTotal;
            fac.Remise = request.Remise;

            fac.Heure = request.Heure;
            fac.Date = request.Date;
            fac.Numero = fac.Numero; // Verify if this is intended or should be updated from the request
            fac.VendeurId = request.VendeurId;
            fac.ClientId = request.ClientId;
            fac.Timbre = request.Timbre;
        }








        private List<MotifModification> CheckForModifications(Facture originalFacture, FactureAvoir avoir, UpdateFactureCommand updatedFacture)
        {
            List<MotifModification> motifModificationList = new List<MotifModification>();

            // Check for modifications in each property and add to motifModificationList
            foreach (Motif modificationType in Enum.GetValues(typeof(Motif)))
            {
                switch (modificationType)
                {
                    case Motif.Client:
                        CheckAndAddModification(avoir,originalFacture.Client, updatedFacture.Client, motifModificationList, modificationType);
                        break;

                    case Motif.Timbre:
                        CheckAndAddModification(avoir,originalFacture.Timbre, updatedFacture.Timbre, motifModificationList, modificationType);
                        break;

                    case Motif.Remise:
                        CheckAndAddModification(avoir,originalFacture.Remise, updatedFacture.Remise, motifModificationList, modificationType);
                        break;

                    case Motif.RestTotal:
                        CheckAndAddModification(avoir,originalFacture.RestTotal, updatedFacture.RestTotal, motifModificationList, modificationType);
                        break;

                    case Motif.TVA:
                        CheckAndAddModification(avoir,originalFacture.MontantTotalTVA, updatedFacture.MontantTotalTVA, motifModificationList, modificationType);
                        break;

                    case Motif.DateEcheance:
                        CheckAndAddModification(avoir,originalFacture.DateEcheance, updatedFacture.DateEcheance, motifModificationList, modificationType);
                        break;

                    case Motif.LigneFacture:
                        CheckAndAddLigneFactureModifications(avoir,originalFacture.FacProducts, updatedFacture.FacProducts, motifModificationList);
                        break;

                    // Add other cases for additional properties

                    default:
                        // Handle any unexpected enum values
                        break;
                }
            }

            return motifModificationList;
        }

        private void CheckAndAddLigneFactureModification( FactureAvoir avoir,FacProducts originalValue, FacProducts updatedValue, List<MotifModification> motifModificationList , Motif modificationtype)
        {

            // check QTE 
            if (!EqualityComparer<decimal>.Default.Equals(originalValue.Qte, updatedValue.Qte))
            {
                motifModificationList.Add(new MotifModification
                {
                    Id = Guid.NewGuid(),
                    Motif = modificationtype,
                    ModificationAt = DateTime.Now.ToString("HH:mm:ss"),
                    AncienneValeur = originalValue.Qte.ToString(),
                    NouvelleValeur = updatedValue.Qte.ToString(),
                    LigneFactureItem = LigneFactureItems.Qte,
                    IdAvoir=avoir.Id
                });
            }
            // check price changed 

            if (!EqualityComparer<decimal>.Default.Equals(originalValue.Puv, updatedValue.Puv))
            {
                motifModificationList.Add(new MotifModification
                {
                    Motif = modificationtype,
                    ModificationAt = DateTime.Now.ToString("HH:mm:ss"),
                    AncienneValeur = originalValue.Puv.ToString(),
                    NouvelleValeur = updatedValue.Puv.ToString(),
                    LigneFactureItem = LigneFactureItems.PrixUnitaireVente,
                    IdAvoir = avoir.Id
                });
            }
            // check product row changed 

            if (!EqualityComparer<string>.Default.Equals(originalValue.Designation, updatedValue.Designation))
            {
                motifModificationList.Add(new MotifModification
                {
                    Motif = modificationtype,
                    ModificationAt = DateTime.Now.ToString("HH:mm:ss"),
                    AncienneValeur = originalValue.Designation?.ToString(),
                    NouvelleValeur = updatedValue.Designation?.ToString(),
                    LigneFactureItem = LigneFactureItems.ProduitChange,
                    IdAvoir = avoir.Id
                });
            }
            //check montant HT
            if (!EqualityComparer<decimal>.Default.Equals(originalValue.MontantHT, updatedValue.MontantHT))
            {
                motifModificationList.Add(new MotifModification
                {
                    Motif = modificationtype,
                    AncienneValeur = originalValue.MontantHT.ToString(),
                    NouvelleValeur = updatedValue.MontantHT.ToString(),
                    LigneFactureItem = LigneFactureItems.MontantHT,
                    IdAvoir = avoir.Id
                });
            }
        }
        private void CheckAndAddLigneFactureModifications(FactureAvoir avoir,List<FacProducts> originalFacture,List<FacProducts> updatedFacture, List<MotifModification> motifModificationList)
        {
            // Your complex verification logic for "LigneFacture" case
            // You can access FacProducts or other relevant properties

            // Example:
            foreach (var originalLigneFacture in originalFacture)
            {
                var updatedLigneFacture = updatedFacture.FirstOrDefault(u => u.Designation == originalLigneFacture.Designation);

                if (updatedLigneFacture != null)
                {
                    // Compare properties and add modifications to motifModificationList
                    // ...

                    // Example:
                    CheckAndAddLigneFactureModification(avoir,originalLigneFacture, updatedLigneFacture, motifModificationList , Motif.LigneFacture);
                   
                }
            }
        }


        private void CheckAndAddModification<T>(FactureAvoir avoir,T originalValue, T updatedValue, List<MotifModification> motifModificationList, Motif modificationType)
        {
            if (!EqualityComparer<T>.Default.Equals(originalValue, updatedValue) && originalValue !=null && updatedValue!=null)
            {
                motifModificationList.Add(new MotifModification
                {
                    Id = Guid.NewGuid(),
                    ModificationAt = DateTime.Now.ToString("HH:mm:ss"),
                    Motif = modificationType,
                    AncienneValeur = originalValue?.ToString(),
                    NouvelleValeur = updatedValue?.ToString(),
                    IdAvoir = avoir.Id
                }); ; ;
            }
        }



        public async Task<Facture> Handle(RegroupFactureCommand request, CancellationToken cancellationToken)
        {
            var validator = new RegroupFactureCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var factures = _context.Factures.Where(c => c.ClientId == request.Client.Id && c.Date<=request.Datef && c.Date >= request.Dated).Include(a=>a.FacProducts).ToList();
            var facgrouped = new Domain.Entities.Facture()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Heure = DateTime.Now.ToShortTimeString(),
                VendeurId = new Guid(),
                MontantTotalHT= factures.Select(s => s.MontantTotalHT).Sum(),
                MontantTotalTTC = factures.Select(s => s.MontantTotalTTC).Sum(),
                MontantTotalTVA = factures.Select(s => s.MontantTotalTVA).Sum(),
                Numero= factures[0].Numero,
                ClientId = request.Client.Id,
                Client = request.Client,
                FacProducts= null
            };

            facgrouped.FacProducts = factures
                .SelectMany(fac => fac.FacProducts ?? Enumerable.Empty<FacProducts>()) // Flatten the BlProducts from all Bls, and handle null BlProducts collections
                .Where(fac => fac != null) // Filter out any null BlProducts
                .GroupBy(fac => fac?.Designation) // Group by Designation, handle null Designation
                .Where(group => group.Key != null) // Filter out groups with null Designation
                .Select(group => new FacProducts
                {
                    FactureId = facgrouped?.Id ?? Guid.Empty, // Handle null blgrouped.Id by using a default value (e.g., Guid.Empty)
                    Designation = group.Key, // No need for null-checking here, as we filtered out null keys
                    Qte = group.Sum(product => product?.Qte ?? 0), // Handle null Qte by using a default value (e.g., 0)
                    MontantHT = group.Sum(product => product?.MontantHT ?? 0), // Handle null Montant by using a default value (e.g., 0)
                    MontantTTC = group.Sum(product => product?.MontantTTC ?? 0), // Handle null Montant by using a default value (e.g., 0)
                    MontantTVA = group.Sum(product => product?.MontantTVA ?? 0), // Handle null Montant by using a default value (e.g., 0)
                    Puv = group.First()?.Puv ?? 0, // Handle null Puv by using a default value (e.g., 0)
                    Image= group.First()?.Image                             // Image and SelectedStock properties can be set similarly
                })
                .ToList();
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return facgrouped;
        }

    }
}