using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Famille.Queries;
using SmartRestaurant.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

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
