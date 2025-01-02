using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Depenses.Queries;
using SmartRestaurant.Application.Famille.Queries;
using SmartRestaurant.Application.Stock.Queries;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Depenses.Queries.FilterStrategy
{
    public interface IDepenseFilterStrategy
    {     
        public PagedResultBase<Domain.Entities.Depense> FetchData(DbSet<Domain.Entities.Depense> stock, GetDepensesListQuery request);
    }
}
