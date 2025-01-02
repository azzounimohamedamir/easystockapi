using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Stock.Queries;
using SmartRestaurant.Domain.Entities;
using System;

namespace SmartRestaurant.Application.GestionStock.Inventaire.Queries.FilterStrategy
{
    public interface IInvFilterStrategy
    {     
        public PagedResultBase<Domain.Entities.Inventaire> FetchData(DbSet<Domain.Entities.Inventaire> stock,GetInventoryValidatedListQuery request);

        public PagedResultBase<Domain.Entities.LignesInventaireFinal> FetchLignesFinal(DbSet<Domain.Entities.LignesInventaireFinal> stock, GetInventoryLignesFinalListQuery request);
    }
    
}

