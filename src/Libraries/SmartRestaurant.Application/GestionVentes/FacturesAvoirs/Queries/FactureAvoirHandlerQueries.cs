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
using SmartRestaurant.Application.GestionVentes.FacturesAvoirs.Queries.FilterStrategy;

namespace SmartRestaurant.Application.GestionVentes.FacturesAvoirs.Queries
{
    public class FactureAvoirHandlerQueries :
        IRequestHandler<GetListOfFactureAvoirQuery, PagedListDto<FactureAvoirDto>>
     


    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FactureAvoirHandlerQueries(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<PagedListDto<FactureAvoirDto>> Handle(GetListOfFactureAvoirQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetListOfFactureAvoirQueryValidator();
            
            
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var filter = AvoirStrategies.GetFilterStrategy();
            var query = filter.FetchData(_context.FactureAvoirs, request);


            var data = _mapper.Map<List<FactureAvoirDto>>(query.Data.ToList());

             

            return new PagedListDto<FactureAvoirDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }

       



    }
}
    