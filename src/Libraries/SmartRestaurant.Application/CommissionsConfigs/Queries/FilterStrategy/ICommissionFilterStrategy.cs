using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.commisiones.Queries;
using SmartRestaurant.Application.Common.Extensions;

namespace SmartRestaurant.Application.Commissions.Queries.FilterStrategy
{
    public interface ICommissionFilterStrategy
    {     
        public PagedResultBase<Domain.Entities.FoodBusiness> FetchData(DbSet<Domain.Entities.FoodBusiness> foodBusinesses, GetCommissionConfigsListQuery request);
    }
}
