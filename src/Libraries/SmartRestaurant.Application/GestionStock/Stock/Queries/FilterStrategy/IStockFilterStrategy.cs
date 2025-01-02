using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Stock.Queries;
using SmartRestaurant.Domain.Entities;
using System;

namespace SmartRestaurant.Application.Stock.Queries.FilterStrategy
{
    public interface IStockFilterStrategy
    {     
        public PagedResultBase<Domain.Entities.Stock> FetchData(DbSet<Domain.Entities.Stock> stock,GetStockListQuery request);
    }
    
}

