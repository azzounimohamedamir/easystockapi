using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using System.Linq;

namespace SmartRestaurant.Application.Illness.Queries.FilterStrategy
{
    public class FilterIllnessesByIdinless : IIllnessUserFilterStrategy
    {
        public PagedResultBase<Domain.Entities.IlnessUser> FetchData(DbSet<Domain.Entities.IlnessUser> illnesses, GetIlnessessbyUserQuery request)
        {
            var searchKey = string.IsNullOrWhiteSpace(request.SearchKey) ? "" : request.SearchKey;
            var sortOrder = string.IsNullOrWhiteSpace(request.SortOrder) ? "acs" : request.SortOrder;

            switch (sortOrder)
            {
                case "acs":
                    return illnesses
                        .Where(illness => illness.Illness.Name.Contains(searchKey))
                       .OrderBy(illness => illness.Illness.Name)
                       .GetPaged(request.Page, request.PageSize);

                case "desc":
                    return illnesses
                       .Where(illnesses => illnesses.Illness.Name.Contains(searchKey))
                       .OrderByDescending(p => p.Illness.Name)
                       .GetPaged(request.Page, request.PageSize);

                default:
                    return illnesses.Where(illnesses => illnesses.Illness.Name.Contains(searchKey))
                                               .GetPaged(request.Page, request.PageSize);




            }
        }
    }
}
