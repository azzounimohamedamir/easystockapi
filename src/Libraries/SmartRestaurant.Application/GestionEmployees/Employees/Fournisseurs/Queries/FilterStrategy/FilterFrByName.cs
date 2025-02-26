using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Domain.Entities;
using System.Linq;

namespace SmartRestaurant.Application.GestionEmployees.Employees.Fournisseurs.Queries.FilterStrategy
{
    public class FilterFrByName : IFrFilterStrategy
    {
        public PagedResultBase<Fournisseur> FetchData(DbSet<Fournisseur> fournisseur, GetFournisseurListQuery request)
        {



            return fournisseur
               .OrderBy(s => s.FullName)
               .GetPaged(request.Page, request.PageSize);

        }



    }
}
