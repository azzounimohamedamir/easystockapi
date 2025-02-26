using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Domain.Identity.Entities;

namespace SmartRestaurant.Application.AdminArea.Queries.FilterStrategy
{
    public interface IClAppFilterStrategy
    {
        public PagedResultBase<MyClients> FetchData(DbSet<MyClients> employes, GetClientsAppListQuery request);
        public PagedResultBase<LicenceKeys> FetchLicences(DbSet<LicenceKeys> creances, GetAllLicencesClientsListQuery request);
    }
}
