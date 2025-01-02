using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.GestionVentes.VenteComptoir.Queries;
using SmartRestaurant.Application.Stock.Queries;
using SmartRestaurant.Domain.Entities;
using System;

namespace SmartRestaurant.Application.GestionVentes.VenteParBl.Queries.FilterStrategy
{
    public interface IBlFilterStrategy
    {     
        public PagedResultBase<Bl> FetchData(DbSet<Bl> bl,GetBonLivraisonsListQuery request);
    }
    
}

