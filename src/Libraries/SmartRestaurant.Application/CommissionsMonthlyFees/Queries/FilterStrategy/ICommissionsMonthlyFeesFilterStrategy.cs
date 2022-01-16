using Microsoft.AspNetCore.Identity;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Identity.Entities;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.CommissionsMonthlyFees.Queries.FilterStrategy
{
    public interface ICommissionsMonthlyFeesFilterStrategy
    {     
        public PagedResultBase<MonthlyCommission> FetchData(IApplicationDbContext context, IIdentityContext identityContext,
            GetMonthlyCommissionListBySmartRestaurantUserQuery request);
    }
}
