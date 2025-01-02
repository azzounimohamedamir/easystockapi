using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Stock.Queries;
using SmartRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SmartRestaurant.Application.Stock.Queries.FilterStrategy
{
    public class FilterStockByName : IStockFilterStrategy
    {
        public PagedResultBase<Domain.Entities.Stock> FetchData(DbSet<Domain.Entities.Stock> stock, GetStockListQuery request)
        {
            // Start building the query with necessary includes
            IQueryable<Domain.Entities.Stock> query = stock
                .Include(s => s.Category)
                .Include(s => s.ProductAttributeValues);

           

           

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
