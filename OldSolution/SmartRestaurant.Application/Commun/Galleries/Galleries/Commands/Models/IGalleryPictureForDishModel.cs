namespace SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Models
{
    public interface IGalleryPictureForDishModel
    {
        string RestaurantId { get; set; }
        GalleryPictureModel Picture { get; set; }
    }
}