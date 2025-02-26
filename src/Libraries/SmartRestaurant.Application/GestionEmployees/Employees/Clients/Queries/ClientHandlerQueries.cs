using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.GestionAchats.Employees.Clients.Queries;
using SmartRestaurant.Application.GestionEmployees.Employees.Clients.Queries.FilterStrategy;
using SmartRestaurant.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.GestionEmployees.Employees.Clients.Queries
{
    public class ClientHandlerQueries :
        IRequestHandler<GetClientListQuery, PagedListDto<Client>>,
       IRequestHandler<GetCreancesAssainiesListQuery, PagedListDto<CreanceAssainie>>

    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ClientHandlerQueries(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<PagedListDto<Client>> Handle(GetClientListQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetClientListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);



            var filter = ClStrategies.GetFilterStrategy(request.CurrentFilter);
            var query = filter.FetchData(_context.Clients, request);

            var data = _mapper.Map<List<Client>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));

            return new PagedListDto<Client>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }

        public async Task<PagedListDto<CreanceAssainie>> Handle(GetCreancesAssainiesListQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetCreancesAssainiesListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);



            var filter = ClStrategies.GetFilterStrategy(request.CurrentFilter);
            var query = filter.FetchCreances(_context.CreanceAssainies, request);

            var data = _mapper.Map<List<CreanceAssainie>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));

            return new PagedListDto<CreanceAssainie>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }









    }
}
