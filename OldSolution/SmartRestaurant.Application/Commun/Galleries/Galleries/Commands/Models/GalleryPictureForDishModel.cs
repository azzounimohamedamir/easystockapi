namespace SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Models
{
    public class GalleryPictureForDishModel : IGalleryPictureForDishModel
    {
        public string RestaurantId { get; set; }
        public GalleryPictureModel Picture { get; set; }
    }
}