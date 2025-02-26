using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;

namespace SmartRestaurant.Application.GestionStock.Inventaire.Queries.FilterStrategy
{
    public interface IInvFilterStrategy
    {
        public PagedResultBase<Domain.Entities.Inventaire> FetchData(DbSet<Domain.Entities.Inventaire> stock, GetInventoryValidatedListQuery request);

        public PagedResultBase<Domain.Entities.LignesInventaireFinal> FetchLignesFinal(DbSet<Domain.Entities.LignesInventaireFinal> stock, GetInventoryLignesFinalListQuery request);
    }

}

