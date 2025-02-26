using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using System.Linq;

namespace SmartRestaurant.Application.GestionVentes.FacturesAvoirs.Queries.FilterStrategy
{
    public class FilterAvoirbyName : IAvoirFilterStrategy
    {
        public PagedResultBase<Domain.Entities.FactureAvoir> FetchData(DbSet<Domain.Entities.FactureAvoir> bon, GetListOfFactureAvoirQuery request)
        {



            return bon
                .Include(v => v.MotifsAvoir).Include(c => c.ProduitsRetournes).Include(c => c.ProduitsAjouterAuStock).Include(f => f.OriginalFacture)
                .OrderByDescending(s => s.NumeroAvoir)
                .ThenBy(s => s.DateAvoir)
                .GetPaged(request.Page, request.PageSize);

        }





    }
}
