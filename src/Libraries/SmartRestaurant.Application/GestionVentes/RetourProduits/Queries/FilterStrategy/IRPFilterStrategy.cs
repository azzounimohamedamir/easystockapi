using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;

namespace SmartRestaurant.Application.GestionVentes.RetourProduits.Queries.FilterStrategy
{
    public interface IRPFilterStrategy
    {
        public PagedResultBase<Domain.Entities.RetourProduitClient> FetchData(DbSet<Domain.Entities.RetourProduitClient> bon, GetListOfRetourProduitsQuery request);


    }

}

