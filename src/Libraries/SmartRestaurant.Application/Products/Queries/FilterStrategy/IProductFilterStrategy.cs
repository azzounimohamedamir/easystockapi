using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Products.Queries.FilterStrategy
{
    public interface IProductFilterStrategy
    {     
        public PagedResultBase<Product> FetchData(DbSet<Product> products, GetProductListQuery request);
    }
}
