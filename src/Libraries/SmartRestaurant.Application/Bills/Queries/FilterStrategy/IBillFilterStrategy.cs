using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Domain.Entities;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Bills.Queries.FilterStrategy
{
    public interface IBillFilterStrategy
    {     
        public PagedResultBase<Order> FetchData(DbSet<Order> orders, GetBillsListQuery request);
        public List<Order> FetchTotalRevenue(DbSet<Order> orders, GetBillsListQuery request);

    }
}
