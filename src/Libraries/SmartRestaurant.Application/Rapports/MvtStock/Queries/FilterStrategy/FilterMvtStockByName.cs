using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SmartRestaurant.Application.Rapports.MvtStock.Queries.FilterStrategy
{
    public class FilterMvtStockByName : IMvtStockFilterStrategy
    {
        public PagedResultBase<Domain.Entities.MouvementStock> FetchData(DbSet<Domain.Entities.MouvementStock> bon, GetMvtStockListQuery request)
        {



            return bon
                 .Where(v => v.DateMvt.Date <= request.DateFin.Date && v.DateMvt.Date >= request.DateDebut.Date)
                 .Where(Condition(request))
                .OrderByDescending(s => s.DateMvt)
                .GetPaged(request.Page, request.PageSize);

        }

        private static Expression<Func<MouvementStock, bool>> Condition(GetMvtStockListQuery request)
        {
            if (request.CurrentFilter == "0")
                return product => (product.TypeMouvement == TypeMouv.Entree);
            else if (request.CurrentFilter == "1")
                return product => (product.TypeMouvement == TypeMouv.Sortie);
            else
                return product => true;

        }



    }
}
