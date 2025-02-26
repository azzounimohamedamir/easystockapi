using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.AdminArea.Queries.FilterStrategy;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Domain.Identity.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.AdminArea.Queries
{
#pragma warning disable CS0311 // Impossible d'utiliser le type 'SmartRestaurant.Application.AdminArea.Queries.GetAllLicencesClientsListQuery' comme paramètre de type 'TRequest' dans le type ou la méthode générique 'IRequestHandler<TRequest, TResponse>'. Il n'y a pas de conversion de référence implicite de 'SmartRestaurant.Application.AdminArea.Queries.GetAllLicencesClientsListQuery' en 'MediatR.IRequest<SmartRestaurant.Application.Common.Dtos.PagedListDto<SmartRestaurant.Domain.Identity.Entities.LicenceKeys>>'.
    public class ClientAppHandlerQueries :
#pragma warning restore CS0311 // Impossible d'utiliser le type 'SmartRestaurant.Application.AdminArea.Queries.GetAllLicencesClientsListQuery' comme paramètre de type 'TRequest' dans le type ou la méthode générique 'IRequestHandler<TRequest, TResponse>'. Il n'y a pas de conversion de référence implicite de 'SmartRestaurant.Application.AdminArea.Queries.GetAllLicencesClientsListQuery' en 'MediatR.IRequest<SmartRestaurant.Application.Common.Dtos.PagedListDto<SmartRestaurant.Domain.Identity.Entities.LicenceKeys>>'.
        IRequestHandler<GetClientsAppListQuery, PagedListDto<MyClients>>,
       IRequestHandler<GetAllLicencesClientsListQuery, PagedListDto<LicenceKeys>>

    {
        private readonly IIdentityContext _context;
        private readonly IMapper _mapper;

        public ClientAppHandlerQueries(IIdentityContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<PagedListDto<MyClients>> Handle(GetClientsAppListQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetClientsAppListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);



            var filter = ClAppStrategies.GetFilterStrategy(request.CurrentFilter);
            var query = filter.FetchData(_context.MyClients, request);

            var data = _mapper.Map<List<MyClients>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));

            return new PagedListDto<MyClients>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }

        public async Task<PagedListDto<LicenceKeys>> Handle(GetAllLicencesClientsListQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetAllLicencesClientsListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);



            var filter = ClAppStrategies.GetFilterStrategy(request.CurrentFilter);
            var query = filter.FetchLicences(_context.LicenceKeys, request);

            var data = _mapper.Map<List<LicenceKeys>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));

            return new PagedListDto<LicenceKeys>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }









    }
}
