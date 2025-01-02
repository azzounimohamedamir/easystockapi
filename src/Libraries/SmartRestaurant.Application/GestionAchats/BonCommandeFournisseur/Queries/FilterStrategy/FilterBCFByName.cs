using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.GestionVentes.VenteParFac.Queries;
using SmartRestaurant.Application.GestionVentes.VenteParFac.Queries.FilterStrategy;
using SmartRestaurant.Application.Stock.Queries;
using SmartRestaurant.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SmartRestaurant.Application.GestionAchats.BonCommandeFournisseur.Queries.FilterStrategy
{
    public class FilterBCFByName : IBCFFilterStrategy
    {
        public PagedResultBase<Domain.Entities.BonCommandeFournisseur> FetchData(DbSet<Domain.Entities.BonCommandeFournisseur> bon, GetBCFListQuery request)
        {

            if ( string.IsNullOrEmpty(request.CurrentFilter))
            {
                return bon
                .Include(v => v.AbcProducts).ThenInclude(p => p.SelectedStock).Include(c => c.Fournisseur)
                .OrderBy(s => s.Date)
                .GetPaged(request.Page, request.PageSize);
            }
            else
            {
                return bon.Where(b=>b.CreatedBy==request.CurrentFilter)
               .Include(v => v.AbcProducts).ThenInclude(p => p.SelectedStock).Include(c => c.Fournisseur)
               .OrderBy(s => s.Date)
               .GetPaged(request.Page, request.PageSize);
            }
        }



    }
}
