using SmartRestaurant.Application.FoodCategories.Commands;
using SmartRestaurant.Application.FoodCategories.Commands.Delete;
using SmartRestaurant.Application.FoodCategories.Commands.Update;
using SmartRestaurant.Application.Foods.FoodCategories.Queries;

namespace SmartRestaurant.Application.FoodCategories.Services
{
    public interface IFoodCategoryService
    {
        ICreateFoodCategoryCommand Create { get; }
        IUpdateFoodCategoryCommand Update { get; }
        IDeleteFoodCatergoryCommand Delete { get; }
        IFoodCategoryQueries Queries { get; }
    }
}
