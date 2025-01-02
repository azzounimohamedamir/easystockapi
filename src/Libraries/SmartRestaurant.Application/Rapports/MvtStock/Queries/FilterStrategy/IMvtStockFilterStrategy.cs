using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.GestionVentes.VenteComptoir.Queries;
using SmartRestaurant.Application.GestionVentes.VenteParFac.Queries;
using SmartRestaurant.Application.Rapports.MvtStock.Queries;
using SmartRestaurant.Application.Stock.Queries;
using SmartRestaurant.Domain.Entities;
using System;

namespace SmartRestaurant.Application.Rapports.MvtStock.Queries.FilterStrategy
{
    public interface IMvtStockFilterStrategy
    {     
        public PagedResultBase<Domain.Entities.MouvementStock> FetchData(DbSet<Domain.Entities.MouvementStock> bon,GetMvtStockListQuery request);
      

    }

}

