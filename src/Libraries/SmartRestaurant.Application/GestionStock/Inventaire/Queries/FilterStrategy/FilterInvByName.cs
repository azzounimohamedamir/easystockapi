using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.GestionStock.Inventaire.Queries.FilterStrategy;
using SmartRestaurant.Application.Stock.Queries;
using SmartRestaurant.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SmartRestaurant.Application.GestionStock.Inventaire.Queries.FilterStrategy
{
    public class FilterInvByName : IInvFilterStrategy
    {
        public PagedResultBase<Domain.Entities.Inventaire> FetchData(DbSet<Domain.Entities.Inventaire> inv, GetInventoryValidatedListQuery request)
        {



            return inv.Include(l=>l.LignesInventaire)
               .GetPaged(request.Page, request.PageSize);
            
        }
        public PagedResultBase<Domain.Entities.LignesInventaireFinal> FetchLignesFinal(DbSet<Domain.Entities.LignesInventaireFinal> inv, GetInventoryLignesFinalListQuery request)
        {



            return inv.Where(a=>a.QuantiteTrouveeA != a.QuantiteTrouveeB)
               .GetPaged(request.Page, request.PageSize);

        }



    }
}
