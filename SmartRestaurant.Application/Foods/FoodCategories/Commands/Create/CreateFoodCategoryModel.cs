namespace SmartRestaurant.Application.FoodCategories.Commands
{
    public class CreateFoodCategoryModel : ICreateFoodCategoryModel
    {
        public string ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Alias { get; set; }
        public string PictureId { get; set; }
        public string PictureUrl { get; set; }
        public bool IsDisabled { get; set; }

    }
}