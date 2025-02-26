using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.GestionVentes.VenteParBl.Queries.FilterStrategy
{
    public interface IBlFilterStrategy
    {
        public PagedResultBase<Bl> FetchData(DbSet<Bl> bl, GetBonLivraisonsListQuery request);
    }

}

