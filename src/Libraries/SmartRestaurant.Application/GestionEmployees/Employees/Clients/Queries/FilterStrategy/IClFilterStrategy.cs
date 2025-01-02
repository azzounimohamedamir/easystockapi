using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.AdminArea.Queries;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Famille.Queries;
using SmartRestaurant.Application.GestionAchats.Employees.Clients.Queries;
using SmartRestaurant.Application.GestionEmployees.Employees.Clients.Queries;
using SmartRestaurant.Application.Stock.Queries;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Identity.Entities;

namespace SmartRestaurant.Application.GestionEmployees.Employees.Clients.Queries.FilterStrategy
{
    public interface IClFilterStrategy
    {
        public PagedResultBase<Client> FetchData(DbSet<Client> employes, GetClientListQuery request);
        public PagedResultBase<CreanceAssainie> FetchCreances(DbSet<CreanceAssainie> creances, GetCreancesAssainiesListQuery request);
    }
}
