using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Models
{
    public class GalleryPictureModel : IGalleryPictureModel
    {
        public string Id { get; set; }
        public bool IsDisabled { get; set; }
        public string Alias { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsTheCover { get; set; }
    }
}
