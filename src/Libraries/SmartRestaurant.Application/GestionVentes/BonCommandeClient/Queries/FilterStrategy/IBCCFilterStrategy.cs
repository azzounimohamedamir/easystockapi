using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;

namespace SmartRestaurant.Application.GestionVentes.BonCommandeClient.Queries.FilterStrategy
{
    public interface IBCCFilterStrategy
    {
        public PagedResultBase<Domain.Entities.BonCommandeClient> FetchData(DbSet<Domain.Entities.BonCommandeClient> bon, GetBCCListQuery request);


    }

}

