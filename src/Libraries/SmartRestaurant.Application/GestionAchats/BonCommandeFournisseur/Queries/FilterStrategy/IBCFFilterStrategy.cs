using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;

namespace SmartRestaurant.Application.GestionAchats.BonCommandeFournisseur.Queries.FilterStrategy
{
    public interface IBCFFilterStrategy
    {
        public PagedResultBase<Domain.Entities.BonCommandeFournisseur> FetchData(DbSet<Domain.Entities.BonCommandeFournisseur> bon, GetBCFListQuery request);


    }

}

