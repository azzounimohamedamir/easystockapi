using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Famille.Queries;
using SmartRestaurant.Application.Stock.Queries;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.ProgrammeFidelite.Queries.FilterStrategy
{
    public interface IFideliteFilterStrategy
    {     
        public PagedResultBase<Domain.Entities.ClientFidelite> FetchData(DbSet<Domain.Entities.ClientFidelite> fidelite, GetClientFideliteListQuery request);
        public PagedResultBase<Domain.Entities.NiveauFidelite> FetchNiveauFidelite(DbSet<Domain.Entities.NiveauFidelite> niveau, GetNiveauxFideliteListQuery request);
    }
}
