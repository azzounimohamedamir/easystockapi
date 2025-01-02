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
using SmartRestaurant.Application.GestionVentes.BonCommandeClient.Queries;
using SmartRestaurant.Application.GestionVentes.BonCommandeClient.Queries.FilterStrategy;
using SmartRestaurant.Application.GestionVentes.FactureProformat.Queries.FilterStrategy;
using SmartRestaurant.Application.GestionVentes.FactureProformat.Queries;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Application.GestionAchats.BonsAchat.Queries.FilterStrategy;
using SmartRestaurant.Application.GestionVentes.VenteParFac.Queries.FilterStrategy;
using SmartRestaurant.Application.GestionVentes.VenteParFac.Queries;
using SmartRestaurant.Application.GestionAchats.BonsAchat.Queries;
using SmartRestaurant.Application.GestionVentes.RetourProduits.Queries.FilterStrategy;

namespace SmartRestaurant.Application.GestionVentes.RetourProduits.Queries
{
    public class RetourProduitHandlerQueries :
        IRequestHandler<GetListOfRetourProduitsQuery, PagedListDto<Domain.Entities.RetourProduitClient>>
     


    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RetourProduitHandlerQueries(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<PagedListDto<Domain.Entities.RetourProduitClient>> Handle(GetListOfRetourProduitsQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetListOfRetourProduitsQueryValidator();
            
            
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var filter = RPStrategies.GetFilterStrategy();
            var list = _context.RetourProduitClients.ToList();
            var query = filter.FetchData(_context.RetourProduitClients, request);

            var data = await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false);

            

            return new PagedListDto<Domain.Entities.RetourProduitClient>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }

        public async Task<PagedListDto<Reglement_Acompte_BA_Fournisseur>> Handle(GetListOfRegAcompteFournisseurByBaIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetListOfRegAcompteFournisseurByBaIdQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);



            var filter = BAStrategies.GetFilterStrategy();
            var query = filter.FetchRegelementsOfFournisseurByBA(_context.Reglement_Acompte_BA_Fournisseurs, request);

            var data = await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false);

            return new PagedListDto<Reglement_Acompte_BA_Fournisseur>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }


        public async Task<PagedListDto<Reglement_Acompte_BA_Fournisseur>> Handle(GetListOfRegAcompteFournisseurs request, CancellationToken cancellationToken)
        {
            var validator = new GetListOfRegAcompteFournisseursValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);



            var filter = BAStrategies.GetFilterStrategy();
            var query = filter.FetchAllReglementsFr(_context.Reglement_Acompte_BA_Fournisseurs, request);
            var list = query.Data.ToList();
            var data = _mapper.Map<List<Reglement_Acompte_BA_Fournisseur>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));

            return new PagedListDto<Reglement_Acompte_BA_Fournisseur>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }



    }
}
    