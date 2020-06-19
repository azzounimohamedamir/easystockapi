namespace SmartRestaurant.Application.FoodCategories.Commands.Update
{
    public class UpdateFoodCategoryModel : CreateFoodCategoryModel, IUpdateFoodCategoryModel
    {
        public string Id { get; set; }
        //public string 
    }
}