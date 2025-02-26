using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using System.Linq;

namespace SmartRestaurant.Application.GestionEmployees.Employees.Permissions.Queries.FilterStrategy
{
    public class FilterPermissionsByName : IPermFilterStrategy
    {
        public PagedResultBase<Domain.Identity.Entities.Permissions> FetchData(DbSet<Domain.Identity.Entities.Permissions> perm, GetPermissionsListQuery request)
        {



            return perm
               .OrderBy(s => s.Role)
               .GetPaged(request.Page, request.PageSize);

        }




    }
}
