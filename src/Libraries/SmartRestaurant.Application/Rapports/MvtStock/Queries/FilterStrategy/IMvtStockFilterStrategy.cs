using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;

namespace SmartRestaurant.Application.Rapports.MvtStock.Queries.FilterStrategy
{
    public interface IMvtStockFilterStrategy
    {
        public PagedResultBase<Domain.Entities.MouvementStock> FetchData(DbSet<Domain.Entities.MouvementStock> bon, GetMvtStockListQuery request);


    }

}

