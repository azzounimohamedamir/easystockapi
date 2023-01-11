using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Entities.Globalisation;

namespace SmartRestaurant.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<FoodBusiness> FoodBusinesses { get; set; }
        public DbSet<FoodBusinessImage> FoodBusinessImages { get; set; }
        public DbSet<FoodBusinessUser> FoodBusinessUsers { get; set; }
        public DbSet<HotelUser> hotelUsers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<CheckIn> CheckIns { get; set; }

        public DbSet<Zone> Zones { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Listing> Listings { get; set; }

        public DbSet<ListingDetail> ListingDetails { get; set; }
        public DbSet<ServiceParametre> ServiceParametres { get; set; }
        public DbSet<HotelService> HotelServices { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<HotelSection> HotelSections { get; set; }
        public DbSet<SectionDish> SectionDishes { get; set; }
        public DbSet<SectionProduct> SectionProducts { get; set; }
        public DbSet<SubSection> SubSections { get; set; }
        public DbSet<SubSectionDish> SubSectionDishes { get; set; }
        public DbSet<SubSectionProduct> SubSectionProducts { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<LinkedDevice> LinkedDevices { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishSpecification> DishSpecifications { get; set; }
        public DbSet<DishComboBoxItemTranslation> DishComboBoxItemTranslations { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
        public DbSet<DishSupplement> DishSupplements { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderOccupiedTable> OrderOccupiedTables { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<OrderDish> OrderDishes { get; set; }
        public DbSet<OrderDishIngredient> OrderDishIngredients { get; set; }
        public DbSet<OrderDishSpecification> OrderDishSpecifications { get; set; }
        public DbSet<OrderComboBoxItemTranslation> OrderComboBoxItemTranslations { get; set; }
        public DbSet<OrderDishSupplement> OrderDishSupplements { get; set; }
        public DbSet<FoodBusinessClient> FoodBusinessClients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Illness> Illnesses { get; set; }
        public DbSet<IlnessUser> ilnessUsers { get; set; }

        public DbSet<IngredientIllness> IngredientIllnesses { get; set; }
        public DbSet<MonthlyCommission> MonthlyCommission { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodBusinessUser>()
                .HasKey(o => new {o.ApplicationUserId, o.FoodBusinessId});


            modelBuilder.Entity<HotelUser>()
                .HasKey(o => new { o.ApplicationUserId, o.HotelId });
            modelBuilder.Entity<IlnessUser>()
               .HasKey(o => new { o.ApplicationUserId, o.IllnessId });
            modelBuilder.Entity<DishIngredient>()
                .HasKey(o => new { o.DishId, o.IngredientId });

            modelBuilder.Entity<DishSupplement>()
                .HasKey(o => new { o.DishId, o.SupplementId});

            modelBuilder.Entity<DishSupplement>()
                .HasOne(e => e.Dish)
                .WithMany(e => e.Supplements)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DishSupplement>()
                .HasOne(e => e.Supplement)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SectionDish>()
              .HasKey(o => new { o.SectionId, o.DishId });
           

            modelBuilder.Entity<SectionProduct>()
              .HasKey(o => new { o.SectionId, o.ProductId });

            modelBuilder.Entity<SubSectionDish>()
             .HasKey(o => new { o.SubSectionId, o.DishId });

            modelBuilder.Entity<SubSectionProduct>()
              .HasKey(o => new { o.SubSectionId, o.ProductId });

            modelBuilder.Entity<IngredientIllness>()
                .HasKey(i => new { i.IllnessId, i.IngredientId });

            modelBuilder.Entity<OrderComboBoxItemTranslation>()
                .HasKey(o => o.OrderComboBoxItemTranslationId);

            modelBuilder.Entity<DishComboBoxItemTranslation>()
                .HasKey(o => o.DishComboBoxItemTranslationId);

            modelBuilder.Entity<Hotel>()
                .HasKey(o => o.Id);
            modelBuilder.Entity<Room>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<Building>()
                .HasKey(o => o.Id);

            modelBuilder.Seed();
        }
    }
}