namespace SmartRestaurant.Application.Services.Commnads.Create
{
    public class CreateServiceModel : ICreateServiceModel
    {
        public string RestaurantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Alias { get; set; }
        public bool IsDisabled { get; set; }


    }
}
