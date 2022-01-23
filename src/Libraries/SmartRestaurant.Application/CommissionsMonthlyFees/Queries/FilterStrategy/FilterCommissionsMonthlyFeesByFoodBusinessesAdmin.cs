using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Identity.Enums;
using System.Linq;

namespace SmartRestaurant.Application.CommissionsMonthlyFees.Queries.FilterStrategy
{
    public class FilterCommissionsMonthlyFeesByFoodBusinessesAdmin : ICommissionsMonthlyFeesFilterStrategy
    {
        public PagedResultBase<MonthlyCommission> FetchData(IApplicationDbContext context, IIdentityContext identityContext, 
            GetMonthlyCommissionListBySmartRestaurantUserQuery request)
        {
            var searchKey = string.IsNullOrWhiteSpace(request.SearchKey) ? "" : request.SearchKey;

            var usersIds = identityContext.UserRoles.Include(u => u.Role)
                .Where(u => u.Role.Name == Roles.FoodBusinessAdministrator.ToString() 
                && u.User.Email.StartsWith(searchKey))
                .Select(u => u.User.Id)
                .ToList();

            var foodBusinessesIds = context.FoodBusinesses
               .Where(x => usersIds.Contains(x.FoodBusinessAdministratorId))
               .Select(x => x.FoodBusinessId)
               .ToList();

            return context.MonthlyCommission
                .Include(x => x.FoodBusiness)
                .Where(x => foodBusinessesIds.Contains(x.FoodBusiness.FoodBusinessId))
                .OrderBy(x => x.Status)
                .ThenByDescending(x => x.Month)
                .GetPaged(request.Page, request.PageSize);
        }
    }
}
