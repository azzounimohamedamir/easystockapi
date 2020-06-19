namespace SmartRestaurant.Application.Dishes.DishFamillies.Commands.Create
{
    public class CreateDishFamilyModel : ICreateDishFamilyModel
    {
        public string RestaurantId { get; set; }
        public string ParentId { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public bool IsDisabled { get; set; }
    }

}