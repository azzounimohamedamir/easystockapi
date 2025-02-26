using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.GestionVentes.VenteParFac.Queries.FilterStrategy
{
    public interface IFacFilterStrategy
    {
        public PagedResultBase<Facture> FetchData(DbSet<Facture> fac, GetFacturesListQuery request);
        public PagedResultBase<Reglement_Acompte_Facture_Client> FetchRegelementsOfClientByFacture(DbSet<Reglement_Acompte_Facture_Client> reg, GetListOfRegAcompteClientByFactureIdQuery request);

        public PagedResultBase<Reglement_Acompte_Facture_Client> FetchAllReglements(DbSet<Reglement_Acompte_Facture_Client> reg, GetListOfRegAcompteClients request);

    }

}

