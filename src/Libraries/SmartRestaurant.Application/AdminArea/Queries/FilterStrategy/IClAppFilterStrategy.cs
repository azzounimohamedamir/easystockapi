using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Famille.Queries;
using SmartRestaurant.Application.GestionAchats.Employees.Clients.Queries;
using SmartRestaurant.Application.GestionEmployees.Employees.Clients.Queries;
using SmartRestaurant.Application.Stock.Queries;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Identity.Entities;

namespace SmartRestaurant.Application.AdminArea.Queries.FilterStrategy
{
    public interface IClAppFilterStrategy
    {
        public PagedResultBase<MyClients> FetchData(DbSet<MyClients> employes, GetClientsAppListQuery request);
        public PagedResultBase<LicenceKeys> FetchLicences(DbSet<LicenceKeys> creances, GetAllLicencesClientsListQuery request);
    }
}
