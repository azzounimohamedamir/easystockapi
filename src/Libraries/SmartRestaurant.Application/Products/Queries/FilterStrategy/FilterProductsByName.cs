using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

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
                       .Where(Condition(reques.FoodBusinessId, searchKey))
                       .OrderBy(product => product.Name)
                       .GetPaged(reques.Page, reques.PageSize);

                case "desc":
                    return products
                       .Where(Condition(reques.FoodBusinessId, searchKey))
                       .OrderByDescending(product => product.Name)
                       .GetPaged(reques.Page, reques.PageSize);

                default:
                    return products
                       .Where(Condition(reques.FoodBusinessId, searchKey))
                       .OrderBy(product => product.Name)
                       .GetPaged(reques.Page, reques.PageSize);
            }
        }

        private static Expression<Func<Product, bool>> Condition(string foodBusinessId, string searchKey)
        {
            if(foodBusinessId == null)
                return product => product.Name.Contains(searchKey) && product.FoodBusinessId == null;
            else 
                return product => product.Name.Contains(searchKey) && product.FoodBusinessId == Guid.Parse(foodBusinessId);
        }

    }
}
