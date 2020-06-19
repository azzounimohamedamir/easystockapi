using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Models
{
    public class GalleryForDishModel : IGalleryForDishModel
    {
        public string DishId { get; set; }        
        public GalleryModel Gallery { get; set; }
        public List<GalleryPictureForDishModel> Pictures { get; set; }
    }
}
