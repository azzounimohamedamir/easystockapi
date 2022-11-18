using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;

namespace SmartRestaurant.Application.FoodBusiness.Queries.FilterStrategy
{
    public interface IFoodBusinessFilterStrategy
    {     
        public PagedResultBase<Domain.Entities.FoodBusiness> FetchData(DbSet<Domain.Entities.FoodBusiness> foodBusinesses, GetFoodBusinessListQuery request);
        public PagedResultBase<Domain.Entities.FoodBusiness> FetchDataFbAcceptDelivery(DbSet<Domain.Entities.FoodBusiness> foodBusinesses, GetAllFoodBusinessAccpetsImportationQuery request);

    }
}
