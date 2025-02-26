using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;

namespace SmartRestaurant.Application.Stock.Queries.FilterStrategy
{
    public interface IStockFilterStrategy
    {
        public PagedResultBase<Domain.Entities.Stock> FetchData(DbSet<Domain.Entities.Stock> stock, GetStockListQuery request);
    }

}

