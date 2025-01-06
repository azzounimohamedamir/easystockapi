using Google.Api;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Entities.Globalisation;
using SmartRestaurant.Domain.Enums;
using System.Drawing;
using System;

namespace SmartRestaurant.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Enable sensitive data logging
            optionsBuilder.EnableSensitiveDataLogging();

            // Other configurations...
        }

        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return base.Entry(entity);
        }
        public DbSet<Stock> Stocks { get; set; }
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
        public DbSet<Caisses> Caisses { get; set; }

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

        public DbSet<VenteComptoirProducts> VenteComptoirProducts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryAttribute> CategoryAttribute { get; set; }

        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<AttributeValue> AttributeValues { get; set; }
        public DbSet<ProductAttributeValue> ProductAttributeValues { get; set; }
        public void DetachEntity<T>(T entity) where T : class
        {
            Entry(entity).State = EntityState.Detached;
        }

        public void UpdateEntity<T>(T entity) where T : class
        {
            Entry(entity).State = EntityState.Modified;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Facture>().Property(u => u.Numero).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            modelBuilder.Entity<Bl>().Property(u => u.Numero).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<Bl>()
  .HasKey(vp => vp.Id);

            modelBuilder.Entity<LignesInventaireFinal>()
.HasKey(vp => vp.Id);


            modelBuilder.Entity<LignesInventaireEquipe>()
.HasKey(vp => vp.Id);


           
            
      

            modelBuilder.Entity<Reglement_Acompte_Facture_Client>()
  .HasKey(vp => vp.Id);
            modelBuilder.Entity<BlProducts>()
          .HasKey(vp => vp.Id);


            modelBuilder.Entity<MotifModification>().HasKey(v => v.Id);
            modelBuilder.Entity<Facture>()
.HasKey(vp => vp.Id);
            modelBuilder.Entity<FactureProformat>()
.HasKey(vp => vp.Id);
            modelBuilder.Entity<FacProducts>()
          .HasKey(vp => vp.Id);

            modelBuilder.Entity<MotifModification>()
         .HasKey(vp => vp.Id);

            modelBuilder.Entity<ClientFidelite>()
     .HasKey(vp => vp.Id);
            modelBuilder.Entity<NiveauFidelite>()
     .HasKey(vp => vp.Id);

            modelBuilder.Entity<FactureProformat>()
           .HasKey(f => f.Id);          

            modelBuilder.Entity<VenteComptoirProducts>()
          .HasKey(vp => vp.Id);

            modelBuilder.Entity<Client>()
         .HasKey(cl => cl.Id);
            modelBuilder.Entity<AjoutProductsAvoir>()
    .HasOne(a => a.FactureAvoir)
    .WithMany(f => f.ProduitsAjouterAuStock)
    .HasForeignKey(a => a.FactureAvoirId)
    .OnDelete(DeleteBehavior.Cascade);



            
         

            modelBuilder.Entity<RetourProduitClient>()
         .HasKey(cl => cl.Id);

            modelBuilder.Entity<Caisses>()
        .HasKey(cl => cl.Id);

            modelBuilder.Entity<MouvementStock>()
       .HasKey(cl => cl.Id);

            modelBuilder.Entity<AvanceClients>()
         .HasKey(vp => vp.Id);
            modelBuilder.Entity<CreditClients>()
         .HasKey(vp => vp.Id);
            modelBuilder.Entity<VenteComptoir>()
         .HasKey(vc => vc.Id);
            modelBuilder.Entity<Stock>()
         .HasKey(s => s.Id);
            modelBuilder.Entity<SocieteInfo>()
       .HasKey(s => s.Id);
            modelBuilder.Entity<DefaultConfigLog>()
      .HasKey(s => s.Id);







            modelBuilder.Entity<MotifModification>()
    .HasOne(m => m.FactureAvoir)
    .WithMany(fa => fa.MotifsAvoir)
    .HasForeignKey(m => m.IdAvoir);

            modelBuilder.Entity<Facture>()
    .HasMany(f => f.FactureAvoirs)
    .WithOne(fa => fa.OriginalFacture)
    .HasForeignKey(fa => fa.IdFactureOriginal);

            modelBuilder.Entity<Facture>()
            .HasMany(f => f.FacProducts)
            .WithOne(fp => fp.Facture)
            .HasForeignKey(fp => fp.FactureId);


            modelBuilder.Entity<FacProducts>()
           .HasOne(fp => fp.Facture)
           .WithMany(f => f.FacProducts)
           .HasForeignKey(fp => fp.FactureId);

            modelBuilder.Entity<FacProducts>()
                .HasOne(fp => fp.SelectedStock)
                .WithMany()
                .HasForeignKey(fp => fp.SelectedStockId);


            modelBuilder.Entity<Reglement_Acompte_Facture_Client>()
       .HasOne(r => r.Facture)
       .WithMany(f => f.Reglement_Acompte_Facture_Clients) // One invoice can have many payments
       .HasForeignKey(r => r.FactureId);


            modelBuilder.Entity<Reglement_Acompte_Facture_Client>()
       .HasOne(r => r.Facture)
       .WithMany(f => f.Reglement_Acompte_Facture_Clients)
       .HasForeignKey(r => r.FactureId)
       .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<Reglement_Acompte_Facture_Client>()
                .HasOne(r => r.Client)
                .WithMany() // Assuming one client can have many payments
                .HasForeignKey(r => r.ClientId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete


            modelBuilder.Entity<Reglement_Acompte_BA_Fournisseur>()
    .HasOne(r => r.Ba)
    .WithMany(f => f.Reglement_Acompte_BA_Fournisseurs) // One invoice can have many payments
    .HasForeignKey(r => r.BAId)
     .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete


         

           


            modelBuilder.Entity<ProductAttributeValue>()
           .HasOne(pav => pav.Stock)
           .WithMany(s => s.ProductAttributeValues)
           .HasForeignKey(pav => pav.StockId)
           .OnDelete(DeleteBehavior.Cascade); // Configure cascade delete if needed

            // Optionally, configure the primary key and foreign key constraints if necessary
            modelBuilder.Entity<ProductAttributeValue>()
                .HasKey(pav => pav.Id);

            modelBuilder.Entity<Stock>()
                .HasKey(s => s.Id);


            modelBuilder.Entity<VenteComptoir>().Property(u => u.Numero).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<BonCommandeClient>().Property(u => u.Numero).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            modelBuilder.Entity<FactureProformat>().Property(u => u.Numero).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<BcProducts>()
        .HasOne(bc => bc.BonCommandeClient)
        .WithMany(b => b.BcProducts)
        .HasForeignKey(bc => bc.BcId);


            modelBuilder.Entity<FacProProducts>()
       .HasOne(bc => bc.FactureProformat)
       .WithMany(b => b.FacProProducts)
       .HasForeignKey(bc => bc.FactureProformatId);

            // Category Configuration
            modelBuilder.Entity<Category>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Category>()
                .Property(c => c.Nom)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.CategorieAttributs)
                .WithOne(ca => ca.Category) // Specify the navigation property in CategoryAttribute
                .HasForeignKey(ca => ca.CategoryId) // Use the actual property name
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete if a category is deleted

            // CategoryAttribute Configuration
            modelBuilder.Entity<CategoryAttribute>()
                .HasKey(ca => ca.Id);

            modelBuilder.Entity<CategoryAttribute>()
                .Property(ca => ca.Nom)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<CategoryAttribute>()
                .HasMany(ca => ca.ProductsAttributes)
                .WithOne(pa => pa.CategoryAttribute) // Specify the navigation property in ProductAttribute
                .HasForeignKey(pa => pa.CategoryAttributeId) // Use the actual property name
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete if a category attribute is deleted

            // ProductAttribute Configuration
            modelBuilder.Entity<ProductAttribute>()
                .HasKey(pa => pa.Id);

            modelBuilder.Entity<ProductAttribute>()
                .Property(pa => pa.Nom)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<ProductAttribute>()
                .HasMany(pa => pa.AttributeValues)
                .WithOne(av => av.ProductAttribute) // Specify the navigation property in AttributeValue
                .HasForeignKey(av => av.ProductAttributeId) // Use the actual property name
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete if a product attribute is deleted

            // AttributeValue Configuration
            modelBuilder.Entity<AttributeValue>()
                .HasKey(av => av.Id);

            modelBuilder.Entity<AttributeValue>()
                .Property(av => av.Valeur)
                .IsRequired()
                .HasMaxLength(50);









            modelBuilder.Entity<BonCommandeFournisseur>().Property(u => u.Numero).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<BonAchats>().Property(u => u.Numero).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Seed();

        }
    }
}