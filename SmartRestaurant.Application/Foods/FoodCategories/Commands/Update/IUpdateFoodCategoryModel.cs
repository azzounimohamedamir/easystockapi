namespace SmartRestaurant.Application.FoodCategories.Commands.Update
{
    public interface IUpdateFoodCategoryModel : ICreateFoodCategoryModel
    {
        string Id { get; set; }
    }
}