using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Domain.Entities;
using System.Linq;

namespace SmartRestaurant.Application.Products.Queries.FilterStrategy
{
    public class FilterProductsByName : IProductFilterStrategy
    {
        public PagedResultBase<Product> FetchData(DbSet<Product> products, GetProductListQuery reques)
        {
            var searchKey = string.IsNullOrWhiteSpace(reques.SearchKey) ? "" : reques.SearchKey;
            var sortOrder = string.IsNullOrWhiteSpace(reques.SortOrder) ? "acs" : reques.SortOrder;

            switch (sortOrder)
            {
                case "acs":
                    return products
                       .Where(product => product.Name.Contains(searchKey))
                       .OrderBy(product => product.Name)
                       .GetPaged(reques.Page, reques.PageSize);

                case "desc":
                    return products
                       .Where(product => product.Name.Contains(searchKey))
                       .OrderByDescending(product => product.Name)
                       .GetPaged(reques.Page, reques.PageSize);

                default:
                    return products
                       .Where(product => product.Name.Contains(searchKey))
                       .OrderBy(product => product.Name)
                       .GetPaged(reques.Page, reques.PageSize);
            }
        }
    }
}
