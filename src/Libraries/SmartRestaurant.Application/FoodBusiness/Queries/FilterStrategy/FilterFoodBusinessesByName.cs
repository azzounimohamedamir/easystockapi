using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using System.Linq;

namespace SmartRestaurant.Application.FoodBusiness.Queries.FilterStrategy
{
    public class FilterFoodBusinessesByName : IFoodBusinessFilterStrategy
    {
        public PagedResultBase<Domain.Entities.FoodBusiness> FetchData(DbSet<Domain.Entities.FoodBusiness> foodBusinesses, GetFoodBusinessListQuery request)
        {
            var searchKey = string.IsNullOrWhiteSpace(request.SearchKey) ? "" : request.SearchKey;
            var sortOrder = string.IsNullOrWhiteSpace(request.SortOrder) ? "acs" : request.SortOrder;

            switch (sortOrder)
            {
                case "acs":
                    return foodBusinesses
                       .Where(foodBusiness => foodBusiness.Name.Contains(searchKey))
                       .OrderBy(foodBusiness => foodBusiness.Name)
                       .GetPaged(request.Page, request.PageSize);

                case "desc":
                    return foodBusinesses
                       .Where(foodBusiness => foodBusiness.Name.Contains(searchKey))
                       .OrderByDescending(foodBusiness => foodBusiness.Name)
                       .GetPaged(request.Page, request.PageSize);

                default:
                    return foodBusinesses
                       .Where(foodBusiness => foodBusiness.Name.Contains(searchKey))
                       .OrderBy(foodBusiness => foodBusiness.Name)
                       .GetPaged(request.Page, request.PageSize);
            }
        }

        public PagedResultBase<Domain.Entities.FoodBusiness> FetchDataFbAcceptDelivery(DbSet<Domain.Entities.FoodBusiness> foodBusinesses, GetAllFoodBusinessAccpetsImportationQuery request)
        {
            var searchKey = string.IsNullOrWhiteSpace(request.SearchKey) ? "" : request.SearchKey;
            var sortOrder = string.IsNullOrWhiteSpace(request.SortOrder) ? "acs" : request.SortOrder;

            switch (sortOrder)
            {
                case "acs":
                    return foodBusinesses
                       .Where(foodBusiness => foodBusiness.Name.Contains(searchKey))
                       .OrderBy(foodBusiness => foodBusiness.Name)
                       .GetPaged(request.Page, request.PageSize);

                case "desc":
                    return foodBusinesses
                       .Where(foodBusiness => foodBusiness.Name.Contains(searchKey))
                       .OrderByDescending(foodBusiness => foodBusiness.Name)
                       .GetPaged(request.Page, request.PageSize);

                default:
                    return foodBusinesses
                       .Where(foodBusiness => foodBusiness.Name.Contains(searchKey))
                       .OrderBy(foodBusiness => foodBusiness.Name)
                       .GetPaged(request.Page, request.PageSize);
            }
        }
    }
}
