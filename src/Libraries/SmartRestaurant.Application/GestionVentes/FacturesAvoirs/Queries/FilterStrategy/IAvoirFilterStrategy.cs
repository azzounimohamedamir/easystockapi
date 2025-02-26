using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;

namespace SmartRestaurant.Application.GestionVentes.FacturesAvoirs.Queries.FilterStrategy
{
    public interface IAvoirFilterStrategy
    {
        public PagedResultBase<Domain.Entities.FactureAvoir> FetchData(DbSet<Domain.Entities.FactureAvoir> bon, GetListOfFactureAvoirQuery request);


    }

}

