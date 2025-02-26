using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SmartRestaurant.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {

        public DbSet<Domain.Entities.Stock> Stocks { get; set; }
        public DbSet<Inventaire> Inventaires { get; set; }
        public DbSet<NiveauFidelite> NiveauFidelites { get; set; }
        public DbSet<ClientFidelite> ClientFidelites { get; set; }
        public DbSet<LignesInventaireEquipe> LignesInventaireEquipes { get; set; }
        public DbSet<InventaireEquipe> InventaireEquipes { get; set; }
        public DbSet<LignesInventaireFinal> LignesInventaireFinals { get; set; }

        public DbSet<MouvementStock> MouvementStocks { get; set; }

        public DbSet<Client> Clients { get; set; }
        public DbSet<CreanceAssainie> CreanceAssainies { get; set; }

        public DbSet<Fournisseur> Fournisseurs { get; set; }

        public DbSet<CreditClients> CreditClients { get; set; }
        public DbSet<AvanceClients> AvanceClients { get; set; }
        public DbSet<DefaultConfigLog> DefaultConfigLogs { get; set; }


        public DbSet<Reglement_Acompte_Facture_Client> Reglement_Acompte_Facture_Clients { get; set; }
        public DbSet<Reglement_Acompte_BA_Fournisseur> Reglement_Acompte_BA_Fournisseurs { get; set; }
        public DbSet<VenteComptoir> VenteComptoirs { get; set; }


        public DbSet<RetourProduitClient> RetourProduitClients { get; set; }
        public DbSet<RetourProducts> RetourProducts { get; set; }

        public DbSet<FactureAvoir> FactureAvoirs { get; set; }
        public DbSet<RetourProductsAvoir> RetourProductsAvoirs { get; set; }
        public DbSet<AjoutProductsAvoir> AjoutProductsAvoirs { get; set; }

        public DbSet<MotifModification> MotifModifications { get; set; }
        public DbSet<Bl> Bls { get; set; }
        public DbSet<BlProducts> BlProducts { get; set; }
        public DbSet<SocieteInfo> SocieteInfos { get; set; }

        public DbSet<FactureProformat> factureProformats { get; set; }

        public DbSet<Facture> Factures { get; set; }
        public DbSet<BonCommandeClient> BonCommandeClients { get; set; }
        public DbSet<BonCommandeFournisseur> BonCommandeFournisseurs { get; set; }
        public DbSet<BonAchats> BonAchats { get; set; }
        public DbSet<BAProducts> BAProducts { get; set; }

        public DbSet<FacProducts> FacProducts { get; set; }
        public DbSet<FacProProducts> FacProProducts { get; set; }
        public DbSet<BcProducts> BcProducts { get; set; }
        public DbSet<AbcProducts> AbcProducts { get; set; }
        public DbSet<Depense> Depenses { get; set; }
        public DbSet<Caisses> Caisses { get; set; }

        public DbSet<VenteComptoirProducts> VenteComptoirProducts { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryAttribute> CategoryAttribute { get; set; }

        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<AttributeValue> AttributeValues { get; set; }
        public DbSet<ProductAttributeValue> ProductAttributeValues { get; set; }
        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return Entry(entity);
        }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}