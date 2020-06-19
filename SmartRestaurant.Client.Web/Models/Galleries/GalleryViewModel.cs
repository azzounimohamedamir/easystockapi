using SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Models;
using System.Collections.Generic;

namespace SmartRestaurant.Client.Web.Models.Galleries
{
    public class GalleryViewModel
    {
        public GalleryViewModel()
        {
            GalleryModel = new GalleryModel();
            Pictures = new HashSet<GalleryPictureViewModel>();
        }

        public GalleryModel GalleryModel { get; set; }
        public ICollection<GalleryPictureViewModel> Pictures { get; set; }
        public string HtmlFieldPrefix { get; set; }
    }
}
