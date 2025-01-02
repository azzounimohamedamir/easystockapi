using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Famille.Queries;
using SmartRestaurant.Application.GestionAchats.Employees.Clients.Queries;
using SmartRestaurant.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SmartRestaurant.Application.GestionEmployees.Employees.Clients.Queries.FilterStrategy
{
    public class FilterClByName : IClFilterStrategy
    {
        public PagedResultBase<Client> FetchData(DbSet<Client> client, GetClientListQuery request)
        {



            return client
               .OrderBy(s => s.FullName)
               .GetPaged(request.Page, request.PageSize);

        }
        public PagedResultBase<CreanceAssainie> FetchCreances(DbSet<CreanceAssainie> creances, GetCreancesAssainiesListQuery request)
        {



            return creances
               .OrderBy(s => s.NomClient)
               .GetPaged(request.Page, request.PageSize);

        }



    }
}
