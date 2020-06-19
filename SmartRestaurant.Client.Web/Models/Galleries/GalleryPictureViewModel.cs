using SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Models;
using SmartRestaurant.Client.Web.Models.Utils;

namespace SmartRestaurant.Client.Web.Models.Galleries
{
    public class GalleryPictureViewModel
    {
        public GalleryPictureViewModel()
        {
            Picture = new GalleryPictureModel();
            File = new FileViewModel(FileType.Image);
        }
        public string DeleteControllerName { get; set; }
        public string DeleteActionName { get; set; }

        public GalleryPictureModel Picture { get; set; }
        public FileViewModel File { get; set; }



        public int Index { get; set; }
        public string Text { get; set; }
        public string Title
        {
            get
            {
                var n = Index + 1 < 10 ? $"0{(Index + 1).ToString()}" : $"{(Index + 1).ToString()}";
                return $"{Text} {n}";
            }
        }
        public string HtmlFieldPrefix { get; set; }
    }
}
