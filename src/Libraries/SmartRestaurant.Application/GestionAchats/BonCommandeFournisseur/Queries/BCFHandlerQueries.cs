using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.GestionAchats.BonCommandeFournisseur.Queries.FilterStrategy;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.GestionAchats.BonCommandeFournisseur.Queries
{
    public class BCFHandlerQueries :
        IRequestHandler<GetBCFListQuery, PagedListDto<Domain.Entities.BonCommandeFournisseur>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BCFHandlerQueries(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<PagedListDto<Domain.Entities.BonCommandeFournisseur>> Handle(GetBCFListQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetBCFListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var filter = BCFStrategies.GetFilterStrategy();
            var query = filter.FetchData(_context.BonCommandeFournisseurs, request);

            var data = _mapper.Map<List<Domain.Entities.BonCommandeFournisseur>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));

            foreach (var item in data)
            {
                var bonProductsList = _context.AbcProducts.Where(abc => abc.BcaId == item.Id).ToList();
                item.AbcProducts = bonProductsList;

                foreach (var BonProItem in item.AbcProducts)
                {
                    var selectedStock = _context.Stocks.FirstOrDefault(s => s.Id == BonProItem.SelectedStockId);
                    BonProItem.SelectedStock = selectedStock;
                }
            }

            return new PagedListDto<Domain.Entities.BonCommandeFournisseur>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }


    }
}
