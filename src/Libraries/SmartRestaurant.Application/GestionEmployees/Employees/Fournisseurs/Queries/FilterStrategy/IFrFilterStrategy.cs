using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.GestionEmployees.Employees.Fournisseurs.Queries.FilterStrategy
{
    public interface IFrFilterStrategy
    {
        public PagedResultBase<Fournisseur> FetchData(DbSet<Fournisseur> employes, GetFournisseurListQuery request);
    }
}
