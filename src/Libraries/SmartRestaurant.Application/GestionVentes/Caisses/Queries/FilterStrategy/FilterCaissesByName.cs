using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Stock.Queries;
using SmartRestaurant.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SmartRestaurant.Application.GestionVentes.Caisses.Queries.FilterStrategy
{
    public class FilterCaissesByName : ICaissesFilterStrategy
    {
        public PagedResultBase<Domain.Entities.Caisses> FetchData(DbSet<Domain.Entities.Caisses> cs, GetCaissesListQuery request)
        {



            return cs
                .OrderBy(s => s.Numero)
              
                       .GetPaged(request.Page, request.PageSize);
            
        }

      

    }
}
