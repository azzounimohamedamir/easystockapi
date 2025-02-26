using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;

namespace SmartRestaurant.Application.ProgrammeFidelite.Queries.FilterStrategy
{
    public interface IFideliteFilterStrategy
    {
        public PagedResultBase<Domain.Entities.ClientFidelite> FetchData(DbSet<Domain.Entities.ClientFidelite> fidelite, GetClientFideliteListQuery request);
        public PagedResultBase<Domain.Entities.NiveauFidelite> FetchNiveauFidelite(DbSet<Domain.Entities.NiveauFidelite> niveau, GetNiveauxFideliteListQuery request);
    }
}
