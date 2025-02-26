using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.GestionEmployees.Employees.Permissions.Queries.FilterStrategy;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.GestionEmployees.Employees.Permissions.Queries
{
    public class PermissionHandlerQueries :
        IRequestHandler<GetPermissionsListQuery, PagedListDto<Domain.Identity.Entities.Permissions>>,
        IRequestHandler<GetPermissionByRoleQuery, Domain.Identity.Entities.Permissions>

    {
        private readonly IIdentityContext _identcontext;
        private readonly IMapper _mapper;

        public PermissionHandlerQueries(IIdentityContext context, IMapper mapper)
        {
            _identcontext = context;
            _mapper = mapper;
        }


        public async Task<PagedListDto<Domain.Identity.Entities.Permissions>> Handle(GetPermissionsListQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetPermissionsListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);



            var filter = PermStrategies.GetFilterStrategy(request.CurrentFilter);
            var query = filter.FetchData(_identcontext.Permissions, request);

            var data = _mapper.Map<List<Domain.Identity.Entities.Permissions>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));

            return new PagedListDto<Domain.Identity.Entities.Permissions>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }


        public async Task<Domain.Identity.Entities.Permissions> Handle(GetPermissionByRoleQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetPermissionByRoleQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var permission = _identcontext.Permissions.FirstOrDefault(p => p.Role == request.Role);


            if (permission == null)
                throw new NotFoundException(nameof(permission), "ss");




            return permission;
        }











    }
}
