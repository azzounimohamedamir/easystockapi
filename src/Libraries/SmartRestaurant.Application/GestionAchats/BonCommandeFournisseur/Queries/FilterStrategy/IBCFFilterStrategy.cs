using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.GestionVentes.VenteComptoir.Queries;
using SmartRestaurant.Application.GestionVentes.VenteParFac.Queries;
using SmartRestaurant.Application.Stock.Queries;
using SmartRestaurant.Domain.Entities;
using System;

namespace SmartRestaurant.Application.GestionAchats.BonCommandeFournisseur.Queries.FilterStrategy
{
    public interface IBCFFilterStrategy
    {     
        public PagedResultBase<Domain.Entities.BonCommandeFournisseur> FetchData(DbSet<Domain.Entities.BonCommandeFournisseur> bon,GetBCFListQuery request);
      

    }

}

