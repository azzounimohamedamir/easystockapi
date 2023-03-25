using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Application.CurrencyExchange;
using SmartRestaurant.Application.Products.Queries;
using SmartRestaurant.Application.Products.Queries.FilterStrategy;
using SmartRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Products.Commands
{
    public class ProductsCommandsHandler :
         IRequestHandler<CreateProductCommand, Created>,
        IRequestHandler<UpdateProductCommand, NoContent>,
        IRequestHandler<DeleteProductCommand, NoContent>,
        IRequestHandler<SynchronizeOdooProductsCommand, PagedListDto<ProductDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IOdooRepository _saleOrderRepository;

        public ProductsCommandsHandler(IApplicationDbContext context, IMapper mapper, IUserService userService, IOdooRepository saleOrderRepository)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
            _saleOrderRepository = saleOrderRepository;
        }
        public async Task<Created> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateProductCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var userId = ChecksHelper.GetUserIdFromToken_ThrowExceptionIfUserIdIsNullOrEmpty(_userService);


            var foodBusiness = await _context.FoodBusinesses.AsNoTracking()
                .FirstOrDefaultAsync(r => r.FoodBusinessId == Guid.Parse(request.FoodBusinessId), cancellationToken).ConfigureAwait(false);
            if (foodBusiness == null)
                throw new NotFoundException(nameof(FoodBusiness), request.FoodBusinessId);

            

            var product = _mapper.Map<Product>(request);
            
            using (var ms = new MemoryStream())
            {
                request.Picture.CopyTo(ms);
                product.Picture = ms.ToArray();
                product.CreatedBy = userId;
                product.CreatedAt = DateTime.Now;
            }
            var odooId = await CreateOdooProduct(product, foodBusiness);
            product.OdooId = odooId;
            _context.Products.Add(product);
            
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return default;
        }

        public async Task<NoContent> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateProductCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var userId = ChecksHelper.GetUserIdFromToken_ThrowExceptionIfUserIdIsNullOrEmpty(_userService);

            var product = await _context.Products.AsNoTracking().FirstOrDefaultAsync(r => r.ProductId == Guid.Parse(request.Id), cancellationToken).ConfigureAwait(false);
            if (product == null)
                throw new NotFoundException(nameof(Product), request.Id);

            var foodBusiness = await _context.FoodBusinesses.AsNoTracking()
                    .FirstOrDefaultAsync(r => r.FoodBusinessId == product.FoodBusinessId, cancellationToken).ConfigureAwait(false);
            if (foodBusiness == null)
                throw new NotFoundException(nameof(FoodBusiness), product.FoodBusinessId);

           

            _mapper.Map(request, product);
            using (var ms = new MemoryStream())
            {
                request.Picture.CopyTo(ms);
                product.Picture = ms.ToArray();
                product.LastModifiedBy = userId;
                product.LastModifiedAt = DateTime.Now;
            }

            _context.Products.Update(product);
            var odooId = await UpdateOdooProduct(product, foodBusiness, product.OdooId);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteProductCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var product = await _context.Products.AsNoTracking().FirstOrDefaultAsync(r => r.ProductId == Guid.Parse(request.Id), cancellationToken).ConfigureAwait(false);
            if (product == null)
                throw new NotFoundException(nameof(Product), request.Id);

            _context.Products.Remove(product);
            //var foodBusiness = await _context.FoodBusinesses.AsNoTracking()
            //        .FirstOrDefaultAsync(r => r.FoodBusinessId == product.FoodBusinessId, cancellationToken).ConfigureAwait(false);
            //if (foodBusiness == null)
            //    throw new NotFoundException(nameof(FoodBusiness), product.FoodBusinessId);
            //await DeleteOdooProduct(foodBusiness,product.OdooId);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        private async Task<long> CreateOdooProduct(Product product, SmartRestaurant.Domain.Entities.FoodBusiness foodBusiness)
        {
            var odooId = (long)0;
            if (foodBusiness.Odoo != null)
            {
                var loggedIn = await _saleOrderRepository.Authenticate(foodBusiness.Odoo);
                if (loggedIn)
                {

                    long categoryId = await getProductCategoryId();
                    var data = new Dictionary<string, object>
                    {
                        { "name", product.Name},
                        { "detailed_type", product.IsQuantityChecked ? "product" : "consu"},
                        { "list_price", product.Price},
                        { "pos_categ_id", categoryId},
                        { "available_in_pos", 1},
                        { "image_1920",product.Picture },
                        { "taxes_id",null }
                    };


                    odooId = await _saleOrderRepository.CreateAsync("product.template", data);
                }
            }
            return odooId;
        }

        private async Task<long> UpdateOdooProduct(Product product, SmartRestaurant.Domain.Entities.FoodBusiness foodBusiness, long odooId)
        {
            if (foodBusiness.Odoo != null)
            {
                var loggedIn = await _saleOrderRepository.Authenticate(foodBusiness.Odoo);
                if (loggedIn)
                {
                    long categoryId = await getProductCategoryId();


                    var data = new Dictionary<string, object>
                    {
                        { "name", product.Name},
                        { "detailed_type", product.IsQuantityChecked ? "product" : "consu"},
                        { "list_price", product.Price},
                        { "pos_categ_id", categoryId},
                        { "available_in_pos", 1},
                        { "image_1920",product.Picture },
                        { "taxes_id",null }
                    };

                    return await _saleOrderRepository.UpdateAsync("product.template", odooId, data);
                }

            }

            return (long)0;
        }

        //private async Task<long> DeleteOdooProduct(SmartRestaurant.Domain.Entities.FoodBusiness foodBusiness, long odooId)
        //{
        //    await _saleOrderRepository.Authenticate(foodBusiness.Odoo);

        //    return await _saleOrderRepository.DeleteAsync("product.template", odooId);
        //}

        private async Task<long> getProductCategoryId()
        {
            var result = await _saleOrderRepository.Search<List<int>>("pos.category", "name", "product", 1);
            long categoryId = 0;
            if (result != null && result.Count > 0)
            {
                categoryId = result[0];
            }
            else
            {
                var categoryData = new Dictionary<string, object>
                {
                    { "name", "product"}
                };
                categoryId = await _saleOrderRepository.CreateAsync("pos.category", categoryData);
            }

            return categoryId;
        }

        public async Task<PagedListDto<ProductDto>> Handle(SynchronizeOdooProductsCommand request, CancellationToken cancellationToken)
        {
            var validator = new SynchronizeOdooProductsCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var foodBusiness = await _context.FoodBusinesses.AsNoTracking()
                    .FirstOrDefaultAsync(r => r.FoodBusinessId == Guid.Parse(request.FoodBusinessId), cancellationToken).ConfigureAwait(false);
            if (foodBusiness == null)
                throw new NotFoundException(nameof(FoodBusiness), request.FoodBusinessId);

            if (foodBusiness.Odoo != null)
            {
                var loggedIn = await _saleOrderRepository.Authenticate(foodBusiness.Odoo);
                if (loggedIn)
                {
                    var products = _context.Products.Where(r => r.FoodBusinessId == Guid.Parse(request.FoodBusinessId));

                    foreach (var product in products)
                    {
                        if (product.SyncFromOdoo)
                        {
                            if (product.OdooId != 0)
                            {
                                var p = await _saleOrderRepository.Read<List<Dictionary<string, object>>>("product.template", product.OdooId);
                                product.Name = p[0]["name"].ToString();
                                product.Price = float.Parse(p[0]["list_price"].ToString());
                                product.IsQuantityChecked = p[0]["detailed_type"].ToString() == "product" ? true : false;
                                product.Picture = Convert.FromBase64String(p[0]["image_512"].ToString());
                                if (p[0]["detailed_type"].ToString() == "product")
                                {
                                    product.Quantity = int.Parse(p[0]["virtual_available"].ToString());
                                }
                                _context.Products.Update(product);
                            }
                            else
                            {
                                var productOdooIds = await _saleOrderRepository.Search<List<int>>("product.template", "name", product.Name, 1);
                                long productOdooId;
                                if (productOdooIds.Count > 0)
                                {
                                    productOdooId = productOdooIds[0];
                                    var p = await _saleOrderRepository.Read<List<Dictionary<string, object>>>("product.template", productOdooId);
                                    product.Name = p[0]["name"].ToString();
                                    product.Price = float.Parse(p[0]["list_price"].ToString());
                                    product.IsQuantityChecked = p[0]["detailed_type"].ToString() == "product" ? true : false;
                                    product.Picture = Convert.FromBase64String(p[0]["image_512"].ToString());
                                    if (p[0]["detailed_type"].ToString() == "product")
                                    {
                                        product.Quantity = int.Parse(p[0]["virtual_available"].ToString());
                                    }
                                    _context.Products.Update(product);
                                }

                            }
                        }
                        else
                        {
                            if (product.OdooId != 0)
                            {
                                await UpdateOdooProduct(product, foodBusiness, product.OdooId);
                            }
                            else
                            {
                                var productOdooIds = await _saleOrderRepository.Search<List<int>>("product.template", "name", product.Name, 1);
                                long productOdooId;
                                if (productOdooIds != null && productOdooIds.Count > 0)
                                {
                                    productOdooId = productOdooIds[0];
                                    await UpdateOdooProduct(product, foodBusiness, productOdooId);
                                }
                                else
                                {
                                    productOdooId = await CreateOdooProduct(product, foodBusiness);
                                }
                                product.OdooId = productOdooId;
                                _context.Products.Update(product);
                            }
                        }
                    }
                }
                else
                {
                    throw new ConflictException("Sorry,Could not synchronize with Odoo, verify your food business Odoo login informations.");
                }
            }
            else
            {
                throw new ConflictException("Sorry, Could not synchronize with Odoo, verify your food business Odoo login informations.");
            }



            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);


            var filter = ProductStrategies.GetFilterStrategy(request.CurrentFilter);
            var newQuery = _mapper.Map<GetProductListQuery>(request);
            var query = filter.FetchData(_context.Products, newQuery);

            var data = _mapper.Map<List<ProductDto>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));

            foreach (var product in data)
            {
                product.CurrencyExchange = CurrencyConverter.GetDefaultCurrencyExchangeList(product.Price, foodBusiness.DefaultCurrency);
            }
            return new PagedListDto<ProductDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }
    }
}
