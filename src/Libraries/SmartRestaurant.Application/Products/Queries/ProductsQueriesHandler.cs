using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Products.Queries
{
    public class ProductsQueriesHandler :
         IRequestHandler<GetProductByIdQuery, ProductDto>

    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductsQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetProductByIdQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var product = await _context.Products.AsNoTracking().FirstOrDefaultAsync(r => r.ProductId == Guid.Parse(request.Id), cancellationToken).ConfigureAwait(false);
            if (product == null)
                throw new NotFoundException(nameof(Product), request.Id);

            return _mapper.Map<ProductDto>(product);
        }
    }
}
