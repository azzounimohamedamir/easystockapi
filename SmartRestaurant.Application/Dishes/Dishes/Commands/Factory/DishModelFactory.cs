using SmartRestaurant.Application.Dishes.Dishes.Commands.Models;
using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Dishes;
using SmartRestaurant.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Dishes.Dishes.Commands.Factory
{
    public interface IDishModelFactory
    {
        DishModel Create(Dish dish);
        DishModel Create(string name,
                         string alias,
                         string description,
                         bool isDisabled,
                         string restaurantId,
                         string familyId,
                         string galleryId,
                         EnumDishType type,
                         TimeSpan preparationTime,
                         TimeSpan serviceTime,
                         bool canBeAccompanying);
    }
    public class DishModelFactory : IDishModelFactory
    {
        public DishModel Create(Dish dish)
        {
            return Create
            (
                dish.Name,
                dish.Alias,
                dish.Description,
                dish.IsDisabled,
                dish.RestaurantId.ToString(),
                dish.FamillyId.ToString(),
                dish.GalleryId.ToString(),
                dish.Type, 
                dish.PreparationTime.Value,
                dish.ServiceTime.Value,
                dish.CanBeAccompanying
            );
        }

        public DishModel Create(string name,
                                string alias,
                                string description,
                                bool isDisabled,
                                string restaurantId,
                                string familyId,
                                string galleryId,
                                EnumDishType type,
                                TimeSpan preparationTime,
                                TimeSpan serviceTime,
                                bool canBeAccompanying)
        {
            return new DishModel
            {
                Name = name,
                Alias = alias,
                Description = description,
                IsDisabled = isDisabled,
                RestaurantId = restaurantId,
                Type = type,
                FamillyId = familyId,
                GalleryId = galleryId,
                PreparationTime = preparationTime,
                ServiceTime = serviceTime,
                CanBeAccompanying = canBeAccompanying,
            };
        }

        
    }
}
