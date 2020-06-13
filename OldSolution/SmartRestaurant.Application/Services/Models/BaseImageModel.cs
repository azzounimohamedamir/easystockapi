namespace SmartRestaurant.Application.Services.Models
{
    public class BaseImageModel
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCover { get; set; }
    }
}