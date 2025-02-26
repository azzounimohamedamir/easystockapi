using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;

namespace SmartRestaurant.Application.GestionVentes.FactureProformat.Queries.FilterStrategy
{
    public interface IFacProFilterStrategy
    {
        public PagedResultBase<Domain.Entities.FactureProformat> FetchData(DbSet<Domain.Entities.FactureProformat> fac, GetFacturesProListQuery request);

    }

}

