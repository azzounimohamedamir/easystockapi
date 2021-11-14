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
        IRequestHandler<GetIllnessByIdQuery, IllnessDto>
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

            var Illness = await _context.Illnesses
               .Include(x => x.IngredientIllnesses)
               .ThenInclude(x => x.Ingredient)
               .Where(u => u.IllnessId == Guid.Parse(request.Id))
               .FirstOrDefaultAsync()
               .ConfigureAwait(false);
            if (Illness == null)
                throw new NotFoundException(nameof(Illness), request.Id);

            var IllnessDto = _mapper.Map<IllnessDto>(Illness);
            return IllnessDto;
        }
    }
}
