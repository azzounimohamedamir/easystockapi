using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Models
{
    public class GalleryModel: IGalleryModel
    {
        public string Id { get; set; }
        public bool IsDisabled { get; set; }
        public string Alias { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public List<GalleryPictureModel> Pictures { get; set; }
    }
}
