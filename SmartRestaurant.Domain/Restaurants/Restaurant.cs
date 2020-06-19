using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Dishes;
using SmartRestaurant.Domain.Pricings;
using SmartRestaurant.Domain.Products;
using SmartRestaurant.Domain.Services;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.Restaurants
{
    public class Restaurant : BaseEntity<Guid>
    {
        public Guid? ChainId { get; set; }
        public Guid OwnerId { get; set; }
        public Guid RestaurantTypeId { get; set; }
        public Chain Chain { get; set; }
        public Gallery Gallery { get; set; }
        public Address Address { get; set; }
        public ICollection<Floor> Floors { get; set; }
        public ICollection<Staff> Staffs { get; set; }
        public ICollection<Dish> Dishes { get; set; }
        public ICollection<DishFamily> DishFamilies { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public ICollection<Menu> Menus { get; set; }
        public ICollection<Service> Services { get; set; }
        public ICollection<Tarification> Tarifications { get; set; }
        public Owner Owner { get; set; }
        public RestaurantType RestaurantType { get; set; }
        public DateTime CreatedDate { get; set; }
        public PriceRange PriceRange { get; set; }
        public ICollection<RestaurantSpecialty> RestaurantSpecialties { get; set; }
        public ICollection<RestaurantKitchen> RestaurantKitchens { get; set; }
        public ICollection<RestaurantFeature> RestaurantFeatures { get; set; }
        public ICollection<RestaurantPriceType> RestaurantPriceTypes { get; set; }
        public ICollection<RestaurantMeal> RestaurantMeals { get; set; }
        public ICollection<RestaurantRecommendation> RestaurantRecommendations { get; set; }
        public ICollection<RestaurantRating> RestaurantRatings { get; set; }
        public ICollection<ProductFamily> ProductFamilies { get; set; }

    }
}
