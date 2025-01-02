using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Stock.Queries;
using SmartRestaurant.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SmartRestaurant.Application.GestionVentes.VenteComptoir.Queries.FilterStrategy
{
    public class FilterVenteComptoirByName : IVenteComptoirFilterStrategy
    {
        public PagedResultBase<Domain.Entities.VenteComptoir> FetchData(DbSet<Domain.Entities.VenteComptoir> vc, GetVenteComptoirListQuery request)
        {



            return vc
                .Include(v=>v.VenteComptoirIncludedProducts).ThenInclude(p=>p.SelectedStock)
                .OrderBy(s => s.Date)
              
                       .GetPaged(request.Page, request.PageSize);
            
        }

      

    }
}
