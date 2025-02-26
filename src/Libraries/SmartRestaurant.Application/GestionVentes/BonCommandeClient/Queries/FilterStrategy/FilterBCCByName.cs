using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using System.Linq;

namespace SmartRestaurant.Application.GestionVentes.BonCommandeClient.Queries.FilterStrategy
{
    public class FilterBCCByName : IBCCFilterStrategy
    {
        public PagedResultBase<Domain.Entities.BonCommandeClient> FetchData(DbSet<Domain.Entities.BonCommandeClient> bon, GetBCCListQuery request)
        {


            if (string.IsNullOrEmpty(request.CurrentFilter))
            {
                return bon
                .Include(v => v.BcProducts).ThenInclude(p => p.SelectedStock).Include(c => c.Client)
                .OrderBy(s => s.Date)
                .GetPaged(request.Page, request.PageSize);
            }
            else
            {
                return bon.Where(bc => bc.CreatedBy == request.CurrentFilter)
                .Include(v => v.BcProducts).ThenInclude(p => p.SelectedStock).Include(c => c.Client)
                .OrderBy(s => s.Date)
                .GetPaged(request.Page, request.PageSize);
            }
        }



    }
}
