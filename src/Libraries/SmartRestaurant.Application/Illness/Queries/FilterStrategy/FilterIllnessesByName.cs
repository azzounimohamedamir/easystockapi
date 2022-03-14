using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using System.Linq;

namespace SmartRestaurant.Application.Illness.Queries.FilterStrategy
{
    public class FilterIllnessesByName : IIllnessFilterStrategy
    {
        public PagedResultBase<Domain.Entities.Illness> FetchData(DbSet<Domain.Entities.Illness> illnesses, GetIllnessesListQuery request)
        {
            var searchKey = string.IsNullOrWhiteSpace(request.SearchKey) ? "" : request.SearchKey;
            var sortOrder = string.IsNullOrWhiteSpace(request.SortOrder) ? "acs" : request.SortOrder;

            switch (sortOrder)
            {
                case "acs":
                    return illnesses
                        .Where(illness => illness.Name.Contains(searchKey))
                       .OrderBy(illness => illness.Name)
                       .GetPaged(request.Page, request.PageSize);

                case "desc":
                    return illnesses
                       .Where(illnesses => illnesses.Name.Contains(searchKey))
                       .OrderByDescending(product => product.Name)
                       .GetPaged(request.Page, request.PageSize);

                default:
                    return illnesses
                       .Where(illnesses => illnesses.Name.Contains(searchKey))
                       .OrderBy(illness => illness.Name)
                       .GetPaged(request.Page, request.PageSize);
            }
        }
    }
}
