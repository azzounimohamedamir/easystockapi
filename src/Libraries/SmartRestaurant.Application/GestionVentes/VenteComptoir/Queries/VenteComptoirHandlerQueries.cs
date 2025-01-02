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
using SmartRestaurant.Application.GestionVentes.VenteComptoir.Queries.FilterStrategy;
using SmartRestaurant.Application.Stock.Queries;
using SmartRestaurant.Application.Stock.Queries.FilterStrategy;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.GestionVentes.VenteComptoir.Queries
{
    public class VenteComptoiraHandlerQueries :
        IRequestHandler<GetVenteComptoirListQuery, PagedListDto<Domain.Entities.VenteComptoir>>,
        IRequestHandler<GetAllVenteComptoirListQuery, List<Domain.Entities.VenteComptoir>>


    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public VenteComptoiraHandlerQueries(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<PagedListDto<Domain.Entities.VenteComptoir>> Handle(GetVenteComptoirListQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetVenteComptoirListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var filter = VenteComptoirStrategies.GetFilterStrategy(request.CurrentFilter);
            var query = filter.FetchData(_context.VenteComptoirs, request);

                var data = _mapper.Map<List<Domain.Entities.VenteComptoir>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));
                return new PagedListDto<Domain.Entities.VenteComptoir>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
            
           
            
        }



        public async Task<List<Domain.Entities.VenteComptoir>> Handle(GetAllVenteComptoirListQuery request, CancellationToken cancellationToken)
        {
        

            var data = _context.VenteComptoirs.ToList();
            return data;

        }
    }
}
    