using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Stock.Queries;
using SmartRestaurant.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SmartRestaurant.Application.GestionVentes.VenteParBl.Queries.FilterStrategy
{
    public class FilterBlByName : IBlFilterStrategy
    {
        public PagedResultBase<Bl> FetchData(DbSet<Bl> bl, GetBonLivraisonsListQuery request)
        {



            if (request.Caisse == 0 && string.IsNullOrEmpty(request.CurrentFilter))
            {
                return bl

               .Include(v => v.BlProducts).ThenInclude(p => p.SelectedStock).Include(c => c.Client)
               .OrderBy(s => s.Date)

                      .GetPaged(request.Page, request.PageSize);
            }
            else if (request.Caisse != 0 && request.CurrentFilter == null)
            {
                return bl.Where(v => v.Caisse == request.Caisse)
             .Include(v => v.BlProducts).ThenInclude(p => p.SelectedStock).Include(c => c.Client)
             .OrderBy(s => s.Date)
             .GetPaged(request.Page, request.PageSize);
            }
            else if (request.Caisse != 0 && !string.IsNullOrEmpty(request.CurrentFilter))
            {
                return bl.Where(v => v.Caisse == request.Caisse && v.NomCaissier.Contains(request.CurrentFilter))
             .Include(v => v. BlProducts).ThenInclude(p => p.SelectedStock).Include(c => c.Client)
             .OrderBy(s => s.Date)
             .GetPaged(request.Page, request.PageSize);
            }
            else if (request.Caisse == 0 && !string.IsNullOrEmpty(request.CurrentFilter))
            {
                return bl.Where(v => v.NomCaissier.Contains(request.CurrentFilter))
             .Include(v => v.BlProducts).ThenInclude(p => p.SelectedStock).Include(c => c.Client)
             .OrderBy(s => s.Date)
             .GetPaged(request.Page, request.PageSize);
            }
            else if (request.Caisse == 0 && string.IsNullOrEmpty(request.CurrentFilter))
            {
                return bl.Where(v => v.Caisse == request.Caisse)
             .Include(v => v.BlProducts).ThenInclude(p => p.SelectedStock).Include(c => c.Client)
             .OrderBy(s => s.Date)
             .GetPaged(request.Page, request.PageSize);
            }
            else
            {
                return bl
             .Include(v => v.BlProducts).ThenInclude(p => p.SelectedStock).Include(c => c.Client)
             .OrderBy(s => s.Date)
             .GetPaged(request.Page, request.PageSize);
            }

        }

      

    }
}
