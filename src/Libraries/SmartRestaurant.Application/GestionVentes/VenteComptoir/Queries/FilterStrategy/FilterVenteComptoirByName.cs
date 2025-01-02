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

            if(request.Caisse==0 && string.IsNullOrEmpty(request.CurrentFilter))
            {
                return vc
                
               .Include(v => v.VenteComptoirIncludedProducts).ThenInclude(p => p.SelectedStock).Include(c=>c.Client)
               .OrderByDescending(s => s.Date)

                      .GetPaged(request.Page, request.PageSize);
            }
           else if (request.Caisse != 0 && request.CurrentFilter==null)
            {
                return vc.Where(v => v.Caisse == request.Caisse)
             .Include(v => v.VenteComptoirIncludedProducts).ThenInclude(p => p.SelectedStock).Include(c => c.Client)
             .OrderByDescending(s => s.Date)
             .GetPaged(request.Page, request.PageSize);
            }
            else if (request.Caisse != 0 && !string.IsNullOrEmpty(request.CurrentFilter))
            {
                return vc.Where(v => v.Caisse == request.Caisse && v.NomCaissier.Contains(request.CurrentFilter))
             .Include(v => v.VenteComptoirIncludedProducts).ThenInclude(p => p.SelectedStock).Include(c => c.Client)
             .OrderByDescending(s => s.Date)
             .GetPaged(request.Page, request.PageSize);
            }
            else if(request.Caisse == 0 && !string.IsNullOrEmpty(request.CurrentFilter) && request.CurrentFilter !="paginate")
                {
                return vc.Where(v => v.NomCaissier.Contains(request.CurrentFilter))
             .Include(v => v.VenteComptoirIncludedProducts).ThenInclude(p => p.SelectedStock).Include(c => c.Client)
             .OrderByDescending(s => s.Date)
             .GetPaged(request.Page, request.PageSize);
            }
            else if (request.CurrentFilter == "paginate")
            {
                return vc
             .Include(v => v.VenteComptoirIncludedProducts).ThenInclude(p => p.SelectedStock).Include(c => c.Client)
             .OrderByDescending(s => s.Date)
             .GetPaged(request.Page, request.PageSize);
            }
            else if (request.Caisse == 0 && string.IsNullOrEmpty(request.CurrentFilter))
            {
                return vc.Where(v => v.Caisse == request.Caisse)
             .Include(v => v.VenteComptoirIncludedProducts).ThenInclude(p => p.SelectedStock).Include(c => c.Client)
             .OrderByDescending(s => s.Date)
             .GetPaged(request.Page, request.PageSize);
            }
            else
            {
                return vc
             .Include(v => v.VenteComptoirIncludedProducts).ThenInclude(p => p.SelectedStock).Include(c => c.Client)
             .OrderByDescending(s => s.Date)
             .GetPaged(request.Page, request.PageSize);
            }

           
            
        }

      

    }
}
