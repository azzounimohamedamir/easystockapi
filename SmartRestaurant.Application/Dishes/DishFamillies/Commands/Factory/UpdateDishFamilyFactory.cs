using Helpers;
using SmartRestaurant.Domain.Dishes;
namespace SmartRestaurant.Application.Dishes.DishFamillies.Commands.Factory
{
    public interface IUpdateDishFamilyFactory
    {
        DishFamily Create(
            DishFamily source,
            string restaurantId,
            string parentId,
            string name,
            string alias,
            string description,
            bool isDesabled);
    }
    public class UpdateDishFamilyFactory : IUpdateDishFamilyFactory
    {
        public DishFamily Create(
            DishFamily source,
            string restaurantId,
            string parentId,
            string name,
            string alias,
            string description,
            bool isDesabled)
        {
            source.RestaurantId = restaurantId.ToGuid();
            source.ParentId = parentId.ToNullableGuid();
            source.Name = name;
            source.Alias = alias;
            source.Description = description;
            source.IsDisabled = isDesabled;
            return source;
        }
    }
}
