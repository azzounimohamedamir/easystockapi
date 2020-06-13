namespace SmartRestaurant.Application.Restaurants.Areas.Commands.Create
{

    public class CreateAreaModel : ICreateAreaModel
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public string FloorId { get; set; }
        public bool IsDisabled { get; set; }
    }

}