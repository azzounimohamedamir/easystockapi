using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Common.Interfaces;


namespace SmartRestaurant.Application.FoodBusinessClient.Queries
{
    public class FoodBusinessClientsQueriesHandler :
        IRequestHandler<GetFoodBusinesClientListQuery, PagedListDto<FoodBusinessClientDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FoodBusinessClientsQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PagedListDto<FoodBusinessClientDto>> Handle(GetFoodBusinesClientListQuery request, CancellationToken cancellationToken)
        {
            var query =
                _context.FoodBusinessClients
                    .GetPaged(request.Page, request.PageSize);

            var data = _mapper.Map<List<FoodBusinessClientDto>>(await query.Data.ToListAsync(cancellationToken)
                .ConfigureAwait(false));

            var pagedResult = new PagedListDto<FoodBusinessClientDto>(query.CurrentPage, query.PageCount, query.PageSize,
                query.RowCount, data);
            return pagedResult;
        }
    }

    
    
}
