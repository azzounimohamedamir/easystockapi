using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Stock.Queries;

namespace SmartRestaurant.Application.GestionVentes.VenteComptoir.Queries.FilterStrategy
{
    public interface IVenteComptoirFilterStrategy
    {
        public PagedResultBase<Domain.Entities.VenteComptoir> FetchData(DbSet<Domain.Entities.VenteComptoir> vc, GetVenteComptoirListQuery request);
    }

}

