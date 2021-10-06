using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Entities;
using System;
using System.IO;
using System.Linq;
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

        public ProductsCommandsHandler(IApplicationDbContext context, IMapper mapper, IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }
        public async Task<Created> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateProductCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var userId = ChecksHelper.GetUserIdFromToken_ThrowExceptionIfUserIdIsNullOrEmpty(_userService);
            
            var product = _mapper.Map<Product>(request);          
            using (var ms = new MemoryStream())
            {
                request.Picture.CopyTo(ms);
                product.Picture = ms.ToArray();
                product.CreatedBy = userId;
                product.CreatedAt = DateTime.Now;
            }

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
    }
}
