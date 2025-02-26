using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.GestionAchats.BonsAchat.Queries.FilterStrategy
{
    public interface IBAFilterStrategy
    {
        public PagedResultBase<Domain.Entities.BonAchats> FetchData(DbSet<Domain.Entities.BonAchats> bon, GetBAListQuery request);
        public PagedResultBase<Reglement_Acompte_BA_Fournisseur> FetchRegelementsOfFournisseurByBA(DbSet<Reglement_Acompte_BA_Fournisseur> reg, GetListOfRegAcompteFournisseurByBaIdQuery request);

        public PagedResultBase<Reglement_Acompte_BA_Fournisseur> FetchAllReglementsFr(DbSet<Reglement_Acompte_BA_Fournisseur> reg, GetListOfRegAcompteFournisseurs request);

    }

}

