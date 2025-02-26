using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Domain.Identity.Entities;
using System.Linq;

namespace SmartRestaurant.Application.AdminArea.Queries.FilterStrategy
{
#pragma warning disable CS0535 // 'FilterClByName' n'implémente pas le membre d'interface 'IClFilterStrategy.FetchData(DbSet<MyClients>, GetClientsAppListQuery)'
    public class FilterClAppByName : IClAppFilterStrategy
#pragma warning restore CS0535 // 'FilterClByName' n'implémente pas le membre d'interface 'IClFilterStrategy.FetchData(DbSet<MyClients>, GetClientsAppListQuery)'
    {
        public PagedResultBase<MyClients> FetchData(DbSet<MyClients> client, GetClientsAppListQuery request)
        {



            return client
               .OrderBy(s => s.FullName)
               .GetPaged(request.Page, request.PageSize);

        }
        public PagedResultBase<LicenceKeys> FetchLicences(DbSet<LicenceKeys> lics, GetAllLicencesClientsListQuery request)
        {



            return lics
               .OrderBy(s => s.ClientName)
               .GetPaged(request.Page, request.PageSize);

        }



    }
}
