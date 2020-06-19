using System.Collections.Generic;

namespace SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Models
{
    public interface IGalleryForDishModel
    {
        string DishId { get; set; }
        GalleryModel Gallery { get; set; }
        List<GalleryPictureForDishModel> Pictures { get; set; }
    }
}