using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Application.GestionStock.Stock.Commands;
using SmartRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ValidationException = SmartRestaurant.Application.Common.Exceptions.ValidationException;

namespace SmartRestaurant.Application.Stock.Commands
{
    public class StockCommandsHandler :
        IRequestHandler<ImportStockFromExcelCommand>,
        IRequestHandler<CreateProductOnStockCommand, Created>,
        IRequestHandler<AddCategoryCommand, Created>,
        IRequestHandler<UpdateProductOnStockCommand, NoContent>,
        IRequestHandler<AddProductToFavorite, NoContent>,
        IRequestHandler<DeleteProductFromStockCommand, NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public StockCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Created> Handle(CreateProductOnStockCommand request, CancellationToken cancellationToken)
        {
            // Validate the request
            var validator = new CreateProductOnStockCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            // Handle non-perishable products
            if (!request.IsPerissable)
            {
                request.DatePeremption = DateTime.Now.AddYears(100);
                request.JourAlerte = 0;
            }

            var config = await _context.DefaultConfigLogs.FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);
            if (config == null) throw new InvalidOperationException("Configuration not found.");

            // CASE: Single product without variants
            var stock = _mapper.Map<Domain.Entities.Stock>(request);
            stock.IsFavoris = false;

            // Add the stock entity and save changes
            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            if (request.QteInitiale != 0)
            {
                var lastBonAchat = await _context.BonAchats.OrderByDescending(a => a.Numero).FirstOrDefaultAsync(cancellationToken);
                var selectedNumero = (lastBonAchat?.Numero ?? 0) + 1;

                var fr = await _context.Fournisseurs.FindAsync(request.FournisseurId);
                if (fr == null) throw new InvalidOperationException("Fournisseur not found.");

                var montantTotal = request.QteInitiale * request.PrixAchat;

                var bonachat = new Domain.Entities.BonAchats
                {
                    Date = DateTime.Now,
                    Heure = DateTime.Now.ToShortTimeString(),
                    VendeurId = Guid.NewGuid(),
                    CodeBA = GenerateCodeBA(),
                    CreatedBy = "Admin",
                    MontantTotalHT = montantTotal,
                    MontantTotalTTC = montantTotal,
                    MontantTotalTVA = 0,
                    FournisseurId = request.FournisseurId,
                    Fournisseur = fr,
                    TotalReglement = montantTotal,
                    Timbre = 0,
                    DateEcheance = DateTime.Now.AddYears(20),
                    DateFermuture = DateTime.Now.AddYears(20),
                    Etat = "Acheté",
                    PaymentMethod = "Espece",
                    Remise = 0,
                    MontantTotalHTApresRemise = montantTotal,
                    RestTotal = 0,
                    Rib = 52154125421,
                    Rip = 65561515455,
                };

                _context.BonAchats.Add(bonachat);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                var bcp = new BAProducts
                {
                    BAId = bonachat.Id,
                    Newpua = request.PrixAchat,
                    Pmp = request.PrixAchat,
                    Designation = request.Designaation,
                    Qte = request.QteInitiale,
                    MontantHT = montantTotal,
                    MontantTTC = montantTotal,
                    MontantTVA = 0,
                    Pua = request.PrixAchat,
                    Image = stock?.Image,
                    SelectedStock = stock,
                    SelectedStockId = stock.Id,
                };

                _context.BAProducts.Add(bcp);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                var existingStock = await _context.Stocks.FirstOrDefaultAsync(u => u.Designaation == request.Designaation, cancellationToken);
                if (existingStock != null && config != null)
                {
                    existingStock.PrixAchat = request.PrixAchat;
                    var margBenifDetail = (decimal.Parse(config.MargeBenifDetail)) / 100 * existingStock.PrixAchat;
                    var margBenifGros = (decimal.Parse(config.MargeBenifGros)) / 100 * existingStock.PrixAchat;

                    existingStock.PrixVenteDetail = Math.Round(existingStock.PrixAchat + margBenifDetail);
                    existingStock.PrixVenteGros = Math.Round(existingStock.PrixAchat + margBenifGros);
                    existingStock.QteRestante = request.QteInitiale;

                    _context.Stocks.Update(existingStock);
                    await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                }

            }

            return new Created(); // Ensure a Created instance is returned
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

        public async Task<Created> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            // Validate the request
            var validator = new AddCategoryCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var checkIfExistOldCat = _context.Categories.Any();
            if (checkIfExistOldCat)
            {
                // Get all categories and remove them
                var allCategories = _context.Categories.ToList();
                _context.Categories.RemoveRange(allCategories);
                await _context.SaveChangesAsync(cancellationToken); // Don't forget to save changes to persist the deletion
            }

            // Create a new category entity
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Nom = request.Nom,
                CategorieAttributs = new List<Domain.Entities.CategoryAttribute>()
            };

            // Loop through each CategorieAttribut in the request
            foreach (var catAttr in request.CategorieAttributs)
            {
                var categoryAttribute = new Domain.Entities.CategoryAttribute
                {
                    Id = Guid.NewGuid(),
                    CategoryId = category.Id,
                    Category = category,
                    Nom = catAttr.Nom,
                    ProductsAttributes = new List<ProductAttribute>()
                };

                // Loop through each ProductsAttribute in the CategorieAttribut
                foreach (var prodAttr in catAttr.ProductsAttributes)
                {
                    var productAttribute = new ProductAttribute
                    {
                        Id = Guid.NewGuid(),
                        CategoryAttributeId = categoryAttribute.Id,
                        CategoryAttribute = categoryAttribute,
                        Nom = prodAttr.Nom,
                        AttributeValues = new List<AttributeValue>()
                    };

                    // Loop through each AttributeValue in the ProductsAttribute
                    foreach (var attrValue in prodAttr.AttributeValues)
                    {
                        var attributeValue = new AttributeValue
                        {
                            Id = Guid.NewGuid(),
                            ProductAttributeId = productAttribute.Id,
                            ProductAttribute = productAttribute,
                            Valeur = attrValue.Valeur
                        };

                        // Add the attribute value to the product attribute
                        productAttribute.AttributeValues.Add(attributeValue);
                    }

                    // Add the product attribute to the category attribute
                    categoryAttribute.ProductsAttributes.Add(productAttribute);
                }

                // Add the category attribute to the category
                category.CategorieAttributs.Add(categoryAttribute);
            }

            // Assuming you have a DbContext instance named _dbContext
            await _context.Categories.AddAsync(category, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);



            return default; // Assuming Created has an Id property
        }







        public async Task<Unit> Handle(ImportStockFromExcelCommand request, CancellationToken cancellationToken)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            try

            {

                // Load the Excel file data into an ExcelPackage
                using var excelPackage = new ExcelPackage(new MemoryStream(request.ExcelFileData));

                // Get the first worksheet of the Excel file
                var worksheet = excelPackage.Workbook.Worksheets[0];

                // Get the number of rows in the worksheet
                var rowCount = worksheet.Dimension.Rows;

                // Create a list to hold the Stock entities
                List<Domain.Entities.Stock> stocks = new List<Domain.Entities.Stock>();

                // Iterate through each row of data in the Excel file
                for (int row = 2; row <= rowCount; row++)
                {

                    var designation = worksheet.Cells[row, 1].Value?.ToString(); // Assuming Designation is the unique identifier

                    // Check if a stock with the same designation already exists in the database
                    var existingStock = await _context.Stocks.FirstOrDefaultAsync(s => s.Designaation == designation);

                    if (existingStock == null)
                    {
                        // Use AutoMapper to map properties from the command to a new Stock entity
                        var stockEntity = _mapper.Map<Domain.Entities.Stock>(request);

                        // Set additional properties manually from the Excel data
                        stockEntity.Id = Guid.NewGuid();
                        stockEntity.Designaation = worksheet.Cells[row, 1].Value?.ToString();
                        stockEntity.Image = worksheet.Cells[row, 2].Value?.ToString();
                        stockEntity.CodeBar = worksheet.Cells[row, 3].Value?.ToString() != "" ? worksheet.Cells[row, 3].Value?.ToString() : Math.Floor(new Random().NextDouble() * 1000000).ToString();
                        stockEntity.Rayonnage = worksheet.Cells[row, 4].Value?.ToString();

                        stockEntity.QteInitiale = Convert.ToInt32(worksheet.Cells[row, 4].Value);

                        stockEntity.QteAlerte = Convert.ToInt32(worksheet.Cells[row, 5].Value);
                        stockEntity.QteRestante = Convert.ToInt32(worksheet.Cells[row, 6].Value);
                        stockEntity.PrixVenteDetail = Convert.ToDecimal(worksheet.Cells[row, 7].Value);
                        stockEntity.PrixVenteGros = Convert.ToDecimal(worksheet.Cells[row, 8].Value);

                        stockEntity.PrixAchat = Convert.ToDecimal(worksheet.Cells[row, 9].Value);
                        stockEntity.Tva = 19;
                        stockEntity.IsPerissable = Convert.ToBoolean(worksheet.Cells[row, 9].Value);
                        stockEntity.DatePeremption = Convert.ToDateTime(worksheet.Cells[row, 16].Value);
                        stockEntity.JourAlerte = Convert.ToInt32(worksheet.Cells[row, 17].Value);
                        stockEntity.IsFavoris = false;
                        // Add the stock entity to the list
                        stocks.Add(stockEntity);
                    }
                }

                // Add the list of stock entities to the context and save changes
                _context.Stocks.AddRange(stocks);
                await _context.SaveChangesAsync(cancellationToken);

                // Return a successful result
                return Unit.Value;
            }

            catch (DbUpdateException ex)
            {
                // Get the inner exception
                Exception innerException = ex.InnerException;

                // Log or display the details of the inner exception
                Console.WriteLine($"Inner Exception Message: {innerException.Message}");
                Console.WriteLine($"Inner Exception Stack Trace: {innerException.StackTrace}");

                // If the inner exception has an inner exception, you can access it in a similar way
                if (innerException.InnerException != null)
                {
                    Console.WriteLine($"Inner Inner Exception Message: {innerException.InnerException.Message}");
                    Console.WriteLine($"Inner Inner Exception Stack Trace: {innerException.InnerException.StackTrace}");
                }

                // You might also want to throw a custom exception or handle this error
                throw; // Rethrow the exception or handle it as appropriate for your application

            }
        }
        public async Task<NoContent> Handle(DeleteProductFromStockCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteProductFromStockCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);



            var menu = await _context.Stocks.FindAsync(request.Id).ConfigureAwait(false);
            if (menu == null)
                throw new NotFoundException(nameof(Stock), request.Id);
            _context.Stocks.Remove(menu);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(UpdateProductOnStockCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateProductOnStockCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var product = await _context.Stocks.AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken)
                .ConfigureAwait(false);
            if (product == null)
                throw new NotFoundException(nameof(Stock), request.Id);
            if (request.IsPerissable == false)
            {
                request.DatePeremption = DateTime.Now;
                request.JourAlerte = 0;
            }

            var entity = _mapper.Map<Domain.Entities.Stock>(request);
            _context.Stocks.Update(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }
        public async Task<NoContent> Handle(AddProductToFavorite request, CancellationToken cancellationToken)
        {
            // Retrieve the product from the database
            var product = await _context.Stocks.AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken)
                .ConfigureAwait(false);

            // Check if the product exists
            if (product == null)
                throw new NotFoundException(nameof(Stock), request.Id);

            // Toggle the IsFavoris property
            product.IsFavoris = !product.IsFavoris;

            // Update the product in the context
            _context.Stocks.Update(product);

            // Save changes to the database
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return default; // Return NoContent
        }
    }
}