using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.CurrencyExchange;
using SmartRestaurant.Application.Products.Queries.FilterStrategy;
using SmartRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Products.Queries
{
    public class ProductsQueriesHandler :
         IRequestHandler<GetProductByIdQuery, ProductDto>,
        IRequestHandler<GetProductListQuery, PagedListDto<ProductDto>>

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

            var productDto =_mapper.Map<ProductDto>(product);

            if(product.FoodBusinessId != null)
            {
                var foodBusiness = await _context.FoodBusinesses.FindAsync(product.FoodBusinessId);
                if (foodBusiness != null)
                    productDto.CurrencyExchange = CurrencyConverter.GetDefaultCurrencyExchangeList(product.Price, foodBusiness.DefaultCurrency);
            }
            
            return productDto;
        }

        public async Task<PagedListDto<ProductDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetProductListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var filter = ProductStrategies.GetFilterStrategy(request.CurrentFilter);
            var query = filter.FetchData(_context.Products, request);

            var data = _mapper.Map<List<ProductDto>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));

            if (request.FoodBusinessId != null)
            {
                var foodBusiness = await _context.FoodBusinesses.FindAsync(Guid.Parse(request.FoodBusinessId));
                if (foodBusiness != null)
                {
                    foreach (var product in data)
                    {
                        product.CurrencyExchange = CurrencyConverter.GetDefaultCurrencyExchangeList(product.Price, foodBusiness.DefaultCurrency);
                    }

                }
            }

            return new PagedListDto<ProductDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }      
    }
}