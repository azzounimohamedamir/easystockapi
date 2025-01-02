using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
using SmartRestaurant.Application.GestionStock.Stock.Commands;
using SmartRestaurant.Application.Stock.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;
using ValidationException = SmartRestaurant.Application.Common.Exceptions.ValidationException;

namespace SmartRestaurant.Application.Stock.Commands
{
    public class StockCommandsHandler :
        IRequestHandler<ImportStockFromExcelCommand>,
        IRequestHandler<CreateProductOnStockCommand, Created>,
        IRequestHandler<AddAttrForCategoryCommand, Created>,
        IRequestHandler<AddValuesForAttributCommand, Created>,
        IRequestHandler<UpdateProductOnStockCommand, NoContent>,
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
            if (request.IsPerissable == false)
            {
                request.DatePeremption = DateTime.Now;
                request.JourAlerte = 0;
            }

            var config = await _context.DefaultConfigLogs.FirstOrDefaultAsync().ConfigureAwait(false);
            if (config == null) throw new InvalidOperationException("Configuration not found.");


                // CASE: Single product without variants
                var stock = _mapper.Map<Domain.Entities.Stock>(request);

                // Retrieve related entities asynchronously
                stock.Category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == request.CategoryId, cancellationToken).ConfigureAwait(false);
               

                // Handle product attributes (if any)
                if (request.ProductAttributeValues != null && request.ProductAttributeValues.Any())
                {
                    var productAttributeValues = request.ProductAttributeValues.Select(attr => new ProductAttributeValue
                    {
                        Id = Guid.NewGuid(),
                        ProductAttributeId = attr.Id,
                        Value = attr.ValueId.ToString(),
                    }).ToList();

                    // Add all ProductAttributeValues to the context
                    stock.ProductAttributeValues = productAttributeValues;
                }
                

                // Add the stock entity and save changes
                _context.Stocks.Add(stock);
               await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            

            return default;
        }






        public async Task<Created> Handle(AddAttrForCategoryCommand request, CancellationToken cancellationToken)
        {
            // Validate the request
            var validator = new AddAttrForCategoryCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            // Handle non-perishable products

            var newattribute = new Domain.Entities.ProductAttribute
            {
                Id = Guid.NewGuid(),
                Name = request.AttributName
            };
            _context.ProductAttributes.Add(newattribute);

            var catattr = new Domain.Entities.CategoryAttribute
            {
                CategoryId = request.CategoryId,
                ProductAttributeId = newattribute.Id,
                Category = _context.Categories.FirstOrDefault(c => c.Id == request.CategoryId),
                ProductAttribute=newattribute
            };
            _context.ProductAttributes.Add(newattribute);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

           


            // Add the stock entity and save changes


            return default;
        }


        public async Task<Created> Handle(AddValuesForAttributCommand request, CancellationToken cancellationToken)
        {
            // Validate the request
            var validator = new AddValuesForAttributCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            // Handle non-perishable products

            if(request.Values.Count != 0)
            {
                foreach (var item in request.Values)
                {
                    var attrvalue = new AttributeValue
                    {
                        Id = Guid.NewGuid(),
                        Value = item,
                        ProductAttributeId = request.AttributId,
                        ProductAttribute = _context.ProductAttributes.FirstOrDefault(pr => pr.Id == request.AttributId)
                    };
                    _context.AttributeValues.Add(attrvalue);
                    await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                }
            }

         
            return default;
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
                        stockEntity.Rayonnage = worksheet.Cells[row, 2].Value?.ToString();

                        stockEntity.Image = worksheet.Cells[row, 2].Value?.ToString();
                        stockEntity.CodeBar = Math.Floor(new Random().NextDouble() * 1000000).ToString();
                       
                        stockEntity.QteAlerte = Convert.ToInt32(worksheet.Cells[row, 4].Value);
                        stockEntity.QteInitiale = Convert.ToInt32(worksheet.Cells[row, 3].Value);
                        stockEntity.QteRestante = Convert.ToInt32(worksheet.Cells[row, 5].Value);
                        stockEntity.PrixVenteDetail = Convert.ToDecimal(worksheet.Cells[row, 6].Value);
                        stockEntity.PrixAchat = Convert.ToDecimal(worksheet.Cells[row, 8].Value);
                        stockEntity.PrixVenteGros = Convert.ToDecimal(worksheet.Cells[row, 7].Value);
                        stockEntity.Tva = 19;
                        stockEntity.IsPerissable = Convert.ToBoolean(worksheet.Cells[row, 9].Value);
                        stockEntity.DatePeremption = Convert.ToDateTime(worksheet.Cells[row, 16].Value);
                        stockEntity.JourAlerte = Convert.ToInt32(worksheet.Cells[row, 17].Value);

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
            if(request.IsPerissable == false)
            {
                request.DatePeremption = DateTime.Now;
                request.JourAlerte = 0;
            }

            var entity = _mapper.Map<Domain.Entities.Stock>(request);
            _context.Stocks.Update(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

    }
}