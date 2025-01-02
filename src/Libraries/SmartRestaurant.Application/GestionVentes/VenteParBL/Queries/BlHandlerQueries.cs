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
using SmartRestaurant.Application.GestionVentes.VenteParBl.Queries.FilterStrategy;
using SmartRestaurant.Application.Stock.Queries;
using SmartRestaurant.Application.Stock.Queries.FilterStrategy;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.GestionVentes.VenteParBl.Queries
{
    public class BlHandlerQueries :
        IRequestHandler<GetBonLivraisonsListQuery, PagedListDto<Bl>>,
        IRequestHandler<GetFacturebyIdBlQuery, FactureDto>

    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BlHandlerQueries(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       
        public async Task<PagedListDto<Bl>> Handle(GetBonLivraisonsListQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetBonLivraisonsListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

           

            var filter = BlStrategies.GetFilterStrategy(request.CurrentFilter);
            var query = filter.FetchData(_context.Bls, request);

            var data = _mapper.Map<List<Bl>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));
                
            return new PagedListDto<Bl>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }


        public async Task<FactureDto> Handle(GetFacturebyIdBlQuery request, CancellationToken cancellationToken)
        {
            var facture = await _context.Factures.Include(v => v.FacProducts).ThenInclude(p => p.SelectedStock).Include(c => c.Client).FirstOrDefaultAsync(f => f.BlId == request.BlId);
             
            return _mapper.Map<FactureDto>(facture);
        }



    }
}
    