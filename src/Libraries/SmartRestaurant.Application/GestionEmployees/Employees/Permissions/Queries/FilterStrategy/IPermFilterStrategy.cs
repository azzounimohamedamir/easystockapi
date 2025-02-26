using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;

namespace SmartRestaurant.Application.GestionEmployees.Employees.Permissions.Queries.FilterStrategy
{
    public interface IPermFilterStrategy
    {
        public PagedResultBase<Domain.Identity.Entities.Permissions> FetchData(DbSet<Domain.Identity.Entities.Permissions> employes, GetPermissionsListQuery request);

    }
}
