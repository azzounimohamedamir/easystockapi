using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Domain.Entities;
using System.Linq;

namespace SmartRestaurant.Application.CommissionsMonthlyFees.Queries.FilterStrategy
{
    public class FilterCommissionsMonthlyFeesByFoodBusinessesName : ICommissionsMonthlyFeesFilterStrategy
    {
        public PagedResultBase<MonthlyCommission> FetchData(IApplicationDbContext context, IIdentityContext identityContext,
            GetMonthlyCommissionListBySmartRestaurantUserQuery request)
        {
            var searchKey = string.IsNullOrWhiteSpace(request.SearchKey) ? "" : request.SearchKey;

            return context.MonthlyCommission
                .Include(x => x.FoodBusiness)
                .Where(x => x.FoodBusiness.Name.Contains(searchKey))
                .OrderBy(x => x.Status)
                .ThenByDescending(x => x.Month)
                .GetPaged(request.Page, request.PageSize);
        }
    }
}
