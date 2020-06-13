namespace SmartRestaurant.Application.Services.Models
{
    public class ServiceDishModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DishNutrritionModel NutrritionModel { get; set; }
    }
}