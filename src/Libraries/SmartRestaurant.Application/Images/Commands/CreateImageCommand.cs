namespace SmartRestaurant.Application.Images.Commands
{
    public class CreateImageCommand
    {
        public byte[] ImageBytes { get; set; }
        public string ImageTitle { get; set; }
        public bool IsLogo { get; set; }
    }
}
