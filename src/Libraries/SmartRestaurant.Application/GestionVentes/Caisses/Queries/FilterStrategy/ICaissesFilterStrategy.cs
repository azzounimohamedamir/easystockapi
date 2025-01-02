using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.GestionVentes.VenteComptoir.Queries;
using SmartRestaurant.Application.Stock.Queries;
using SmartRestaurant.Domain.Entities;
using System;

namespace SmartRestaurant.Application.GestionVentes.Caisses.Queries.FilterStrategy
{
    public interface ICaissesFilterStrategy
    {     
        public PagedResultBase<Domain.Entities.Caisses> FetchData(DbSet<Domain.Entities.Caisses> vc,GetCaissesListQuery request);
    }
    
}

