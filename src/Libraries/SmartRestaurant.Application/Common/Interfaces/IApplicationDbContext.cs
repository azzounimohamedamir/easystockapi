using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Entities.Globalisation;

namespace SmartRestaurant.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Domain.Entities.FoodBusiness> FoodBusinesses { get; set; }
        public DbSet<FoodBusinessImage> FoodBusinessImages { get; set; }
        public DbSet<FoodBusinessUser> FoodBusinessUsers { get; set; }
        public DbSet<HotelUser> hotelUsers { get; set; }
         public DbSet<CheckIn> CheckIns { get; set; }

        public DbSet<Zone> Zones { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<HotelSection> HotelSections { get; set; }
        public DbSet<SectionDish> SectionDishes { get; set; }
        public DbSet<SectionProduct> SectionProducts { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<IlnessUser> ilnessUsers { get; set; }
        public DbSet<Listing> Listings { get; set; }

        public DbSet<ListingDetail> ListingDetails { get; set; }
        public DbSet<ServiceParametre> ServiceParametres { get; set; }
        public DbSet<HotelService> HotelServices { get; set; }
        public DbSet<Building> Buildings { get; set; }

        public DbSet<SubSection> SubSections { get; set; }
        public DbSet<SubSectionDish> SubSectionDishes { get; set; }
        public DbSet<SubSectionProduct> SubSectionProducts { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Domain.Entities.LinkedDevice> LinkedDevices { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishSpecification> DishSpecifications { get; set; }
        public DbSet<DishComboBoxItemTranslation> DishComboBoxItemTranslations { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
        public DbSet<FoodBusinessUserRating> FoodBusinessUserRatings { get; set; }
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
        public DbSet<Domain.Entities.FoodBusinessClient> FoodBusinessClients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Domain.Entities.Illness> Illnesses { get; set; }
        public DbSet<IngredientIllness> IngredientIllnesses { get; set; }
        public DbSet<MonthlyCommission> MonthlyCommission { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}