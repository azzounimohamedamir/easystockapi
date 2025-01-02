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
using SmartRestaurant.Application.Famille.Queries;
using SmartRestaurant.Application.ProgrammeFidelite.Queries.FilterStrategy;
using SmartRestaurant.Application.Stock.Queries;
using SmartRestaurant.Application.Stock.Queries.FilterStrategy;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.ProgrammeFidelite.Queries
{
    public class FideliteHandlerQueries :
        IRequestHandler<GetClientFideliteListQuery, PagedListDto<ClientFideliteDto>>,
        IRequestHandler<GetNiveauxFideliteListQuery, PagedListDto<NiveauFideliteDto>>,
        IRequestHandler<GetClientFideliteByIdQuery, ClientFideliteDto>


    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FideliteHandlerQueries(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       
        public async Task<PagedListDto<ClientFideliteDto>> Handle(GetClientFideliteListQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetClientFideliteListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

           

            var filter = FideliteStrategies.GetFilterStrategy(request.CurrentFilter);
            var query = filter.FetchData(_context.ClientFidelites, request);

            var data = _mapper.Map<List<ClientFideliteDto>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));

            return new PagedListDto<ClientFideliteDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }


        public async Task<ClientFideliteDto> Handle(GetClientFideliteByIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetClientFideliteByIdQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var clientFid = _context.ClientFidelites.FirstOrDefault(a=>a.Id== request.Id);
                

            var data = _mapper.Map<ClientFideliteDto>(clientFid);

            return data;
        }

        public async Task<PagedListDto<NiveauFideliteDto>> Handle(GetNiveauxFideliteListQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetNiveauxFideliteListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);



            var filter = FideliteStrategies.GetFilterStrategy(request.CurrentFilter);
            var query = filter.FetchNiveauFidelite(_context.NiveauFidelites, request);

            var data = _mapper.Map<List<NiveauFideliteDto>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));

            return new PagedListDto<NiveauFideliteDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }


    }
        }
    