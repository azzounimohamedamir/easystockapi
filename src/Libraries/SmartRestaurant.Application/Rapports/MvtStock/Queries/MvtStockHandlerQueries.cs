using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Rapports.MvtStock.Queries;
using SmartRestaurant.Application.Rapports.MvtStock.Queries.FilterStrategy;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.GestionVentes.BonCommandeClient.Queries
{
    public class MvtStockHandlerQueries :
        IRequestHandler<GetMvtStockListQuery, PagedListDto<Domain.Entities.MouvementStock>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MvtStockHandlerQueries(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<PagedListDto<Domain.Entities.MouvementStock>> Handle(GetMvtStockListQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetMvtStockListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var filter = MvtStockStrategies.GetFilterStrategy();
            var query = filter.FetchData(_context.MouvementStocks, request);
            var data = _mapper.Map<List<Domain.Entities.MouvementStock>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));


            return new PagedListDto<Domain.Entities.MouvementStock>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }


    }
}
