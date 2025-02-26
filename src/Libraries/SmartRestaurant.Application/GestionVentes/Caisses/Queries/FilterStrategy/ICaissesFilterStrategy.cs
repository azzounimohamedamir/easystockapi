using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;

namespace SmartRestaurant.Application.GestionVentes.Caisses.Queries.FilterStrategy
{
    public interface ICaissesFilterStrategy
    {
        public PagedResultBase<Domain.Entities.Caisses> FetchData(DbSet<Domain.Entities.Caisses> vc, GetCaissesListQuery request);
    }

}

