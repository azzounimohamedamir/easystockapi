namespace SmartRestaurant.Application.FoodBusiness.Commands
{
    public class CreateFoodBusinessImageCommand
    {
        public byte[] ImageBytes { get; set; }
        public string ImageTitle { get; set; }
        public bool IsLogo { get; set; }
    }
}
