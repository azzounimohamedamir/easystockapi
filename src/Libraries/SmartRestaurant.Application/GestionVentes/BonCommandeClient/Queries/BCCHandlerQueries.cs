using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.GestionVentes.BonCommandeClient.Queries.FilterStrategy;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.GestionVentes.BonCommandeClient.Queries
{
    public class BCCHandlerQueries :
        IRequestHandler<GetBCCListQuery, PagedListDto<BonCommandeClientDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BCCHandlerQueries(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<PagedListDto<BonCommandeClientDto>> Handle(GetBCCListQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetBCCListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var filter = BCCStrategies.GetFilterStrategy();
            var query = filter.FetchData(_context.BonCommandeClients, request);

            var data = _mapper.Map<List<BonCommandeClientDto>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));

            foreach (var item in data)
            {
                var bonProductsList = _context.BcProducts.Where(fac => fac.BcId == item.Id).ToList();
                item.BcProducts = _mapper.Map<List<BcProductsDto>>(bonProductsList);

                foreach (var BonProItem in item.BcProducts)
                {
                    var selectedStock = _context.Stocks.FirstOrDefault(s => s.Id == BonProItem.SelectedStockId);
                    BonProItem.SelectedStock = _mapper.Map<StockDto>(selectedStock);
                }
            }

            return new PagedListDto<BonCommandeClientDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }


    }
}
