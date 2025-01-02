using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Famille.Queries;
using SmartRestaurant.Application.GestionEmployees.Employees.Fournisseurs.Queries;
using SmartRestaurant.Application.Stock.Queries;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.GestionEmployees.Employees.Fournisseurs.Queries.FilterStrategy
{
    public interface IFrFilterStrategy
    {
        public PagedResultBase<Fournisseur> FetchData(DbSet<Fournisseur> employes, GetFournisseurListQuery request);
    }
}
