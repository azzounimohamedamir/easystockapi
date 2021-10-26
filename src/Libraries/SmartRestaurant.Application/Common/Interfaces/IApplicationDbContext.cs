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
        public DbSet<Zone> Zones { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<SectionDish> SectionDishes { get; set; }
        public DbSet<SectionProduct> SectionProducts { get; set; }
        public DbSet<SubSection> SubSections { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Domain.Entities.LinkedDevice> LinkedDevices { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishSpecification> DishSpecifications { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
        public DbSet<DishSupplement> DishSupplements { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDish> OrderDishes { get; set; }
        public DbSet<OrderDishIngredient> OrderDishIngredients { get; set; }
        public DbSet<Domain.Entities.FoodBusinessClient> FoodBusinessClients { get; set; }
        public DbSet<Product> Products { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}