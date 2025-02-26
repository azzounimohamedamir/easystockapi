using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using System.Linq;

namespace SmartRestaurant.Application.GestionVentes.Caisses.Queries.FilterStrategy
{
    public class FilterCaissesByName : ICaissesFilterStrategy
    {
        public PagedResultBase<Domain.Entities.Caisses> FetchData(DbSet<Domain.Entities.Caisses> cs, GetCaissesListQuery request)
        {



            return cs
                .OrderBy(s => s.Numero)

                       .GetPaged(request.Page, request.PageSize);

        }



    }
}
