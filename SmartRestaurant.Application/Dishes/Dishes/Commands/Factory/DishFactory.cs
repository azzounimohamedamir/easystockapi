using Helpers;
using SmartRestaurant.Application.Commun.Quantities;
using SmartRestaurant.Application.Dishes.DishAccompaniments.Models;
using SmartRestaurant.Application.Dishes.Dishes.Commands.Models;
using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Dishes;
using SmartRestaurant.Domain.Enumerations;
using System;

namespace SmartRestaurant.Application.Dishes.Dishes.Commands
{
    public interface IDishAccompanyingFactory
    {
        DishAccompanying Create(string parentId,
                                string accompanyingId,
                                QuantityModel quantity);

        DishAccompanying Create(DishAccompanyingModel model);
    }
    public interface IDishEquivalenceFactory
    {
        DishEquivalence Create(string parentId,
                               string equivalenceId,
                               QuantityModel Quantity);

        DishEquivalence Create(DishEquivalenceModel model);
    }
    
    public interface IDishFactory
    {
        Dish Create(string name,
                    string alias,
                    string description,
                    bool isDisabled,
                    string restaurantId,
                    EnumDishType type,
                    string famillyId,
                    string galleryId,
                    TimeSpan preparationTime,
                    TimeSpan serviceTime,
                    bool canBeAccompanying);

        Dish Create(DishModel model);
        
    }

    public class DishFactory : IDishFactory
    {
        public Dish Create(string name, string alias, string description, bool isDisabled, string restaurantId, EnumDishType type, string famillyId, string galleryId, TimeSpan preparationTime, TimeSpan serviceTime, bool canBeAccompanying)
        {
            return new Dish
            {
                Name = name,
                Alias = alias,
                Description = description,
                IsDisabled = isDisabled,
                RestaurantId = restaurantId.ToGuid(),
                Type = type,
                FamillyId = famillyId.ToGuid(),
                GalleryId = galleryId.ToNullableGuid(),
                PreparationTime = new Time(preparationTime),
                ServiceTime = new Time(serviceTime),
                CanBeAccompanying = canBeAccompanying,
            };
        }

        public Dish Create(DishModel model)
        {
            return Create(model.Name, model.Alias, model.Description, model.IsDisabled, model.RestaurantId, model.Type, model.FamillyId, model.GalleryId, model.PreparationTime, model.ServiceTime, model.CanBeAccompanying);
        }
    }

    public class DishAccompanyingFactory : IDishAccompanyingFactory
    {
        private readonly IQuantityFactory quantityFactory;

        public DishAccompanyingFactory(IQuantityFactory quantityFactory)
        {
            this.quantityFactory = quantityFactory ?? throw new ArgumentNullException(nameof(quantityFactory));
        }
        public DishAccompanying Create(string parentId,
                                       string accompanyingId,
                                       QuantityModel quantity)
        {
            return new DishAccompanying
            {
                ParentId = parentId.ToGuid(),
                AccompanyingId = accompanyingId.ToGuid(),
                Quantity = quantityFactory.Create(quantity.UnitId, quantity.Value),
            };
        }

        public DishAccompanying Create(DishAccompanyingModel model)
        {
            return Create(model.ParentId, model.AccompanyingId, model.Quantity);
        }
    }

    public class DishEquivalenceFactory : IDishEquivalenceFactory
    {
        private readonly IQuantityFactory quantityFactory;

        public DishEquivalenceFactory(IQuantityFactory quantityFactory)
        {
            this.quantityFactory = quantityFactory ?? throw new ArgumentNullException(nameof(quantityFactory));
        }
        public DishEquivalence Create(string parentId,
                                       string equivalenceId,
                                       QuantityModel quantity)
        {
            return new DishEquivalence
            {
                ParentId = parentId.ToGuid(),
                EquivalenceId = equivalenceId.ToGuid(),
                QuantityParent = quantityFactory.Create(quantity.UnitId, quantity.Value),
            };
        }

        public DishEquivalence Create(DishEquivalenceModel model)
        {
            return Create(model.ParentId, model.EquivalenceId, model.Quantity);
        }
    }

    
}