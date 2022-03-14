using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Products.Queries.FilterStrategy;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Ingredients.Queries
{
    public class
        IngredientsQueriesHandler : IRequestHandler<GetIngredientByIdQuery, IngredientDto>,
            IRequestHandler<GetIngredientsListQuery, PagedListDto<IngredientDto>>

    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public IngredientsQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IngredientDto> Handle(GetIngredientByIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetIngredientByIdQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var ingredient = await _context.Ingredients.FindAsync(Guid.Parse(request.Id));
            if (ingredient == null) throw new NotFoundException(nameof(Ingredient), request.Id);
            return _mapper.Map<IngredientDto>(ingredient);
        }

        public async Task<PagedListDto<IngredientDto>> Handle(GetIngredientsListQuery request,
            CancellationToken cancellationToken)
        {
            var validator = new GetIngredientsListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var filter = IngredientStrategies.GetFilterStrategy(request.CurrentFilter);
            var query = filter.FetchData(_context.Ingredients, request);

            var data = _mapper.Map<List<IngredientDto>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));

            return new PagedListDto<IngredientDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);          
        }
    }
}