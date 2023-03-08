using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Application.Orders.Commands;
using SmartRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Products.Commands
{
    public class ProductsCommandsHandler :
         IRequestHandler<CreateProductCommand, Created>,
        IRequestHandler<UpdateProductCommand, NoContent>,
        IRequestHandler<DeleteProductCommand, NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly ISaleOrderRepository _saleOrderRepository;

        public ProductsCommandsHandler(IApplicationDbContext context, IMapper mapper, IUserService userService, ISaleOrderRepository saleOrderRepository)
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
            
            if (request.FoodBusinessId != null)
            {
                var foodBusiness = await _context.FoodBusinesses.AsNoTracking()
                    .FirstOrDefaultAsync(r => r.FoodBusinessId == Guid.Parse(request.FoodBusinessId), cancellationToken).ConfigureAwait(false);
                if (foodBusiness == null)
                    throw new NotFoundException(nameof(FoodBusiness), request.FoodBusinessId);

                var odooId= await CreateOdooProduct(request, foodBusiness);

                var product = _mapper.Map<Product>(request);
                using (var ms = new MemoryStream())
                {
                    request.Picture.CopyTo(ms);
                    product.Picture = ms.ToArray();
                    product.CreatedBy = userId;
                    product.CreatedAt = DateTime.Now;
                    product.OdooId = odooId;
                }
                _context.Products.Add(product);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            
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

            var odooId = await UpdateOdooProduct(request, foodBusiness,product.OdooId);

            _mapper.Map(request, product);
            using (var ms = new MemoryStream())
            {
                request.Picture.CopyTo(ms);
                product.Picture = ms.ToArray();
                product.LastModifiedBy = userId;
                product.LastModifiedAt = DateTime.Now;
            }

            _context.Products.Update(product);
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
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        private async Task<long> CreateOdooProduct(CreateProductCommand request, SmartRestaurant.Domain.Entities.FoodBusiness foodBusiness)
        {
            var product_pic = new byte[0];
            using (var ms = new MemoryStream())
            {
                request.Picture.CopyTo(ms);
                product_pic = ms.ToArray();
            }
            var data = new Dictionary<string, object>
            {
                { "name", request.Name},
                { "detailed_type", "consu"},
                { "list_price", request.Price},
                { "pos_categ_id", 2},
                { "available_in_pos", 1},
                { "image_1920",product_pic }
            };

            await _saleOrderRepository.Authenticate(foodBusiness.Odoo);
            return await _saleOrderRepository.CreateAsync("product.template", data);
        }

        private async Task<long> UpdateOdooProduct(UpdateProductCommand request, SmartRestaurant.Domain.Entities.FoodBusiness foodBusiness,long odooId)
        {
            var product_pic = new byte[0];
            using (var ms = new MemoryStream())
            {
                request.Picture.CopyTo(ms);
                product_pic = ms.ToArray();
            }
            var data = new Dictionary<string, object>
            {
                { "name", request.Name},
                { "detailed_type", "consu"},
                { "list_price", request.Price},
                { "pos_categ_id", 2},
                { "available_in_pos", 1},
                { "image_1920",product_pic }
            };

            await _saleOrderRepository.Authenticate(foodBusiness.Odoo);
            return await _saleOrderRepository.UpdateAsync("product.template",odooId, data);
        }
    }
}
