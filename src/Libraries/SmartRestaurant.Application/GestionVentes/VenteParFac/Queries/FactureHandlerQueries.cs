using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.GestionVentes.VenteParFac.Queries.FilterStrategy;
using SmartRestaurant.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.GestionVentes.VenteParFac.Queries
{
    public class FactureHandlerQueries :
        IRequestHandler<GetFacturesListQuery, PagedListDto<FactureDto>>,
        IRequestHandler<GetListOfRegAcompteClientByFactureIdQuery, PagedListDto<Reglement_Acompte_Facture_Client>>,
         IRequestHandler<GetListOfRegAcompteClients, PagedListDto<Reglement_Acompte_Facture_Client_Dto>>

    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FactureHandlerQueries(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<PagedListDto<FactureDto>> Handle(GetFacturesListQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetFacturesListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);



            var filter = FacStrategies.GetFilterStrategy();
            var query = filter.FetchData(_context.Factures, request);

            var data = _mapper.Map<List<FactureDto>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));

            return new PagedListDto<FactureDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }

        public async Task<PagedListDto<Reglement_Acompte_Facture_Client>> Handle(GetListOfRegAcompteClientByFactureIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetListOfRegAcompteClientByFactureIdQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);



            var filter = FacStrategies.GetFilterStrategy();
            var query = filter.FetchRegelementsOfClientByFacture(_context.Reglement_Acompte_Facture_Clients, request);

            var data = await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false);

            return new PagedListDto<Reglement_Acompte_Facture_Client>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }


        public async Task<PagedListDto<Reglement_Acompte_Facture_Client_Dto>> Handle(GetListOfRegAcompteClients request, CancellationToken cancellationToken)
        {
            var validator = new GetListOfRegAcompteClientsValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);



            var filter = FacStrategies.GetFilterStrategy();
            var query = filter.FetchAllReglements(_context.Reglement_Acompte_Facture_Clients, request);
            var list = query.Data.ToList();
            var data = _mapper.Map<List<Reglement_Acompte_Facture_Client_Dto>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));

            return new PagedListDto<Reglement_Acompte_Facture_Client_Dto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }


    }
}
