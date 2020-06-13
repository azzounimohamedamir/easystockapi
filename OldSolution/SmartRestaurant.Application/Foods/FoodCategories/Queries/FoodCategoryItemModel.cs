namespace SmartRestaurant.Application.FoodCategories.Queries
{
    public class FoodCategoryItemModel
    {
        public string Id { get; set; }
        public string ParentName { get; set; }
        public string PictureUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SlugUrl { get; set; }
        public string IsDisabled { get; set; }
    }
}