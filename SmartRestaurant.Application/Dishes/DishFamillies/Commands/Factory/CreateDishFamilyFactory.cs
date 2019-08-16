using SmartRestaurant.Domain.Dishes;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using SmartRestaurant.Application.Helpers;

namespace SmartRestaurant.Application.Dishes.DishFamillies.Commands.Factory
{
    public interface ICreateDishFamilyFactory
    {
        DishFamily Create(
            string RestaurantId, 
            string parentId, 
            string name, 
            string alias,
            string description,
            bool isDisabled);
    }
    public class CreateDishFamilyFactory : ICreateDishFamilyFactory
    {
        public DishFamily Create(
            string restaurantId, 
            string parentId, 
            string name, 
            string alias, 
            string description,
            bool isDisabled)
        {
            return new DishFamily
            {
                Id= Guid.NewGuid(),
                RestaurantId = restaurantId.ToGuid(),
                ParentId=parentId.ToNullableGuid(),
                Name=name,
                Alias=alias,
                Description=description,
                IsDisabled=isDisabled,
                
            };
        }
    }
}
