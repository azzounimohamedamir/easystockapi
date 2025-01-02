using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.GestionVentes.VenteComptoir.Queries;
using SmartRestaurant.Application.GestionVentes.VenteParFac.Queries;
using SmartRestaurant.Application.Stock.Queries;
using SmartRestaurant.Domain.Entities;
using System;

namespace SmartRestaurant.Application.GestionVentes.BonCommandeClient.Queries.FilterStrategy
{
    public interface IBCCFilterStrategy
    {     
        public PagedResultBase<Domain.Entities.BonCommandeClient> FetchData(DbSet<Domain.Entities.BonCommandeClient> bon,GetBCCListQuery request);
      

    }

}

