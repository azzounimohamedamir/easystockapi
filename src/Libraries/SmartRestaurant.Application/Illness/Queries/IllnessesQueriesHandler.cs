using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Illness.Queries.FilterStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Illness.Queries
{
    public class IllnessesQueriesHandler : IRequestHandler<GetIllnessesListQuery, PagedListDto<IllnessDto>>,
        IRequestHandler<GetIllnessByIdQuery, IllnessDto>, IRequestHandler<GetDeshesIllnessQuery, IList<DisheIllnessDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public IllnessesQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagedListDto<IllnessDto>> Handle(GetIllnessesListQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetIllnessesListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var filter = IllnessStrategies.GetFilterStrategy(request.CurrentFilter);
            var query = filter.FetchData(_context.Illnesses, request);

            var data = _mapper.Map<List<IllnessDto>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));

            return new PagedListDto<IllnessDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }

        public async Task<IllnessDto> Handle(GetIllnessByIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetIllnessByIdQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var IllnessDto = await _context.Illnesses
               .Include(x => x.IngredientIllnesses)
               .ThenInclude(x => x.Ingredient)
               .Select(x => new IllnessDto
               {
                   IllnessId = x.IllnessId,
                   Name = x.Name,
                   Ingredients = _mapper.Map<List<IngredientDto>>(x.IngredientIllnesses.Select(i => i.Ingredient).ToList())
               })
               .Where(u => u.IllnessId == Guid.Parse(request.Id))
               .FirstOrDefaultAsync()
               .ConfigureAwait(false);
            if (IllnessDto == null)
                throw new NotFoundException(nameof(Illness), request.Id);
            return IllnessDto;
        }

        public async Task<IList<DisheIllnessDto>> Handle(GetDeshesIllnessQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetDeshesIllnessQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var deshes = _context.Dishes.AsNoTracking().Where(x => request.disheIds.Contains(x.DishId.ToString()))
                .Include(xx => xx.Ingredients).ThenInclude(xx => xx.Ingredient).
                ThenInclude(xx=>xx.IngredientIllnesses).ThenInclude(x=>x.Illness).ToList();
            if (deshes == null)
                return new List<DisheIllnessDto>();
            return deshes.Where(x => x.Ingredients != null && x.Ingredients.Count != 0)
            .Select(desh=> 
            {
                return new DisheIllnessDto()
                {
                    IdDishe = desh.DishId.ToString(),
                    IllnessIngredients = desh.Ingredients.Select(ingredient => 
                    {
                        return new IllnessIngredientCorrespondingDto() {

                            IngredientId = ingredient.Ingredient.IngredientId.ToString(),
                            Illness = ingredient.Ingredient.IngredientIllnesses.
                            Where(x=> request.illnesIds.Contains(x.IllnessId.ToString())).
                            Select(xx => new IllnessDto() { IllnessId = xx.IllnessId, Name = xx.Illness.Name }).ToList()
                        };
                    }).ToList() 
                };
            }).ToList();
        }
    }
}
