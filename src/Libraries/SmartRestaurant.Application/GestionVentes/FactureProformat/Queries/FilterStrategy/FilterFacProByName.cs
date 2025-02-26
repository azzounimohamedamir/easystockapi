using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using System.Linq;

namespace SmartRestaurant.Application.GestionVentes.FactureProformat.Queries.FilterStrategy
{
    public class FilterFacProByName : IFacProFilterStrategy
    {
        public PagedResultBase<Domain.Entities.FactureProformat> FetchData(DbSet<Domain.Entities.FactureProformat> fac, GetFacturesProListQuery request)
        {
            if (string.IsNullOrEmpty(request.CurrentFilter))
            {
                return fac
                   .Include(v => v.FacProProducts)
                   .ThenInclude(p => p.SelectedStock)
                   .Include(c => c.Client)
                   .OrderBy(s => s.Date)
                   .GetPaged(request.Page, request.PageSize);
            }
            else
            {
                return fac.Where(pro => pro.CreatedBy == request.CurrentFilter)
                   .Include(v => v.FacProProducts)
                   .ThenInclude(p => p.SelectedStock)
                   .Include(c => c.Client)
                   .OrderBy(s => s.Date)
                   .GetPaged(request.Page, request.PageSize);
            }
        }




    }
}
