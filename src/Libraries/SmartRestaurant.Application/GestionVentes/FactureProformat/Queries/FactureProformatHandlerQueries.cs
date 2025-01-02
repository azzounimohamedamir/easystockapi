using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.GestionVentes.FactureProformat.Queries.FilterStrategy;
using SmartRestaurant.Application.GestionVentes.VenteComptoir.Queries.FilterStrategy;
using SmartRestaurant.Application.GestionVentes.VenteParBl.Queries.FilterStrategy;
using SmartRestaurant.Application.GestionVentes.VenteParFac.Queries.FilterStrategy;
using SmartRestaurant.Application.Stock.Queries;
using SmartRestaurant.Application.Stock.Queries.FilterStrategy;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.GestionVentes.FactureProformat.Queries
{
    public class FactureProformatHandlerQueries :
        IRequestHandler<GetFacturesProListQuery, PagedListDto<FactureProformatDto>>

    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FactureProformatHandlerQueries(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<PagedListDto<FactureProformatDto>> Handle(GetFacturesProListQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetFacturesProListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var filter = FacProStrategies.GetFilterStrategy();
            var query = filter.FetchData(_context.factureProformats, request);

            var data = _mapper.Map<List<FactureProformatDto>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));

            foreach (var item in data)
            {
                var facProductsList = _context.FacProProducts.Where(fac => fac.FactureProformatId == item.Id).ToList();
                item.FacProProducts = _mapper.Map<List<FacProProductsDto>>(facProductsList);

                foreach (var facProItem in item.FacProProducts)
                {
                    var selectedStock = _context.Stocks.FirstOrDefault(s => s.Id == facProItem.SelectedStockId);
                    facProItem.SelectedStock = _mapper.Map<StockDto> (selectedStock);
                }
            }

            return new PagedListDto<FactureProformatDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }



    }
        }
    