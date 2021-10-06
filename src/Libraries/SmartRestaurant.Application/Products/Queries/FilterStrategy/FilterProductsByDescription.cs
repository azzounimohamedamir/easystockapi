using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Domain.Entities;
using System.Linq;

namespace SmartRestaurant.Application.Products.Queries.FilterStrategy
{
    public class FilterProductsByDescription : IProductFilterStrategy
    {
        public PagedResultBase<Product> FetchData(DbSet<Product> products, GetProductListQuery reques)
        {
            var searchKey = string.IsNullOrWhiteSpace(reques.SearchKey) ? "" : reques.SearchKey;
            var sortOrder = string.IsNullOrWhiteSpace(reques.SortOrder) ? "acs" : reques.SortOrder;

            switch (sortOrder)
            {
                case "acs":
                    return products
                       .Where(product => product.Description.Contains(searchKey))
                       .OrderBy(product => product.Description)
                       .GetPaged(reques.Page, reques.PageSize);

                case "desc":
                    return products
                       .Where(product => product.Description.Contains(searchKey))
                       .OrderByDescending(product => product.Description)
                       .GetPaged(reques.Page, reques.PageSize);

                default:
                    return products
                       .Where(product => product.Description.Contains(searchKey))
                       .OrderBy(product => product.Description)
                       .GetPaged(reques.Page, reques.PageSize);
            }
        }

    }
}
