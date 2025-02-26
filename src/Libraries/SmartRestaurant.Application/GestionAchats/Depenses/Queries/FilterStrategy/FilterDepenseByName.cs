using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using System.Linq;

namespace SmartRestaurant.Application.Depenses.Queries.FilterStrategy
{
    public class FilterDepenseByName : IDepenseFilterStrategy
    {
        public PagedResultBase<Domain.Entities.Depense> FetchData(DbSet<Domain.Entities.Depense> depense, GetDepensesListQuery request)
        {



            return depense
               .OrderBy(s => s.CreatedAt)
               .GetPaged(request.Page, request.PageSize);

        }



    }
}
