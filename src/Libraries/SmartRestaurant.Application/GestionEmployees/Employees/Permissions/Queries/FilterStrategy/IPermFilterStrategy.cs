using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Famille.Queries;
using SmartRestaurant.Application.GestionAchats.Employees.Clients.Queries;
using SmartRestaurant.Application.GestionEmployees.Employees.Clients.Queries;
using SmartRestaurant.Application.Stock.Queries;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.GestionEmployees.Employees.Permissions.Queries.FilterStrategy
{
    public interface IPermFilterStrategy
    {
        public PagedResultBase<Domain.Identity.Entities.Permissions> FetchData(DbSet<Domain.Identity.Entities.Permissions> employes, GetPermissionsListQuery request);
      
    }
}
