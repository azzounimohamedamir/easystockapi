using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.GestionVentes.VenteComptoir.Queries;
using SmartRestaurant.Application.GestionVentes.VenteParFac.Queries;
using SmartRestaurant.Application.Stock.Queries;
using SmartRestaurant.Domain.Entities;
using System;

namespace SmartRestaurant.Application.GestionAchats.BonsAchat.Queries.FilterStrategy
{
    public interface IBAFilterStrategy
    {     
        public PagedResultBase<Domain.Entities.BonAchats> FetchData(DbSet<Domain.Entities.BonAchats> bon,GetBAListQuery request);
        public PagedResultBase<Reglement_Acompte_BA_Fournisseur> FetchRegelementsOfFournisseurByBA(DbSet<Reglement_Acompte_BA_Fournisseur> reg, GetListOfRegAcompteFournisseurByBaIdQuery request);

        public PagedResultBase<Reglement_Acompte_BA_Fournisseur> FetchAllReglementsFr(DbSet<Reglement_Acompte_BA_Fournisseur> reg, GetListOfRegAcompteFournisseurs request);

    }

}

