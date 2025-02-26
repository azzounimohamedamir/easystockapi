using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Domain.Entities;
using System.Linq;

namespace SmartRestaurant.Application.ProgrammeFidelite.Queries.FilterStrategy
{
    public class FilterFideliteByName : IFideliteFilterStrategy
    {
        public PagedResultBase<ClientFidelite> FetchData(DbSet<ClientFidelite> fidelite, GetClientFideliteListQuery request)
        {



            return fidelite
                
               .OrderByDescending(s => s.Points)
               .GetPaged(request.Page, request.PageSize);

        }


        public PagedResultBase<NiveauFidelite> FetchNiveauFidelite(DbSet<NiveauFidelite> niveau, GetNiveauxFideliteListQuery request)
        {



            return niveau
               .OrderByDescending(s => s.MaxPointsRequis)
               .GetPaged(request.Page, request.PageSize);

        }



    }
}
