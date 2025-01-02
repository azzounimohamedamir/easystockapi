using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Famille.Queries;
using SmartRestaurant.Application.GestionAchats.Employees.Clients.Queries;
using SmartRestaurant.Application.GestionEmployees.Employees.Permissions.Queries.FilterStrategy;
using SmartRestaurant.Application.GestionEmployees.Employees.Permissions.Queries;
using SmartRestaurant.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SmartRestaurant.Application.GestionEmployees.Employees.Permissions.Queries.FilterStrategy
{
    public class FilterPermissionsByName : IPermFilterStrategy
    {
        public PagedResultBase<Domain.Identity.Entities.Permissions> FetchData(DbSet<Domain.Identity.Entities.Permissions> perm, GetPermissionsListQuery request)
        {



            return perm
               .OrderBy(s => s.Role)
               .GetPaged(request.Page, request.PageSize);

        }
       



    }
}
