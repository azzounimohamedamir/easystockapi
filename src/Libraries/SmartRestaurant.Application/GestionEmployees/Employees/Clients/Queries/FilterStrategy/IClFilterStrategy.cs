using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.GestionAchats.Employees.Clients.Queries;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.GestionEmployees.Employees.Clients.Queries.FilterStrategy
{
    public interface IClFilterStrategy
    {
        public PagedResultBase<Client> FetchData(DbSet<Client> employes, GetClientListQuery request);
        public PagedResultBase<CreanceAssainie> FetchCreances(DbSet<CreanceAssainie> creances, GetCreancesAssainiesListQuery request);
    }
}
