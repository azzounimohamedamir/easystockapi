using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using System.Linq;

namespace SmartRestaurant.Application.GestionVentes.RetourProduits.Queries.FilterStrategy
{
    public class FilterRPbyName : IRPFilterStrategy
    {
        public PagedResultBase<Domain.Entities.RetourProduitClient> FetchData(DbSet<Domain.Entities.RetourProduitClient> bon, GetListOfRetourProduitsQuery request)
        {



            return bon
                .Include(v => v.RetourProducts).ThenInclude(p => p.SelectedStock).Include(c => c.Client)
                .OrderBy(s => s.Date)
                .GetPaged(request.Page, request.PageSize);

        }





    }
}
