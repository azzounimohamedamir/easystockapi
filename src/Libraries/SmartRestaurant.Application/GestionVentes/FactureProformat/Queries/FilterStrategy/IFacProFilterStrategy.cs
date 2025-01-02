using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.GestionVentes.VenteComptoir.Queries;
using SmartRestaurant.Application.GestionVentes.VenteParFac.Queries;
using SmartRestaurant.Application.Stock.Queries;
using SmartRestaurant.Domain.Entities;
using System;

namespace SmartRestaurant.Application.GestionVentes.FactureProformat.Queries.FilterStrategy
{
    public interface IFacProFilterStrategy
    {     
        public PagedResultBase<Domain.Entities.FactureProformat> FetchData(DbSet<Domain.Entities.FactureProformat> fac, GetFacturesProListQuery request);

    }

}

