using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using System.Linq;

namespace SmartRestaurant.Application.Stock.Queries.FilterStrategy
{
    public class FilterStockByName : IStockFilterStrategy
    {
        public PagedResultBase<Domain.Entities.Stock> FetchData(DbSet<Domain.Entities.Stock> stock, GetStockListQuery request)
        {
            // Start building the query with necessary includes
            IQueryable<Domain.Entities.Stock> query = stock;


            if (request.CurrentFilter == "OnlyFavoris")
            {
                query = query.Where(v => v.IsFavoris == true);
            }


            // Filter by current filter (designation search) if provided
            if (!string.IsNullOrEmpty(request.CurrentFilter))
            {
                query = query.Where(v => v.Designaation.Contains(request.CurrentFilter));
            }

            // Order and paginate the results
            var result = query
                .OrderBy(s => s.Designaation)
                .GetPaged(request.Page, request.PageSize);

            // Handle potential nulls in ProductAttribute -> AttributeValues mapping


            return result;
        }




    }
}
