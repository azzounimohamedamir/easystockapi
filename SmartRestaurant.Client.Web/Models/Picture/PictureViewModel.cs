using SmartRestaurant.Application.Commun.Galleries.Pictures.Models;
using SmartRestaurant.Client.Web.Models.Utils;

namespace SmartRestaurant.Client.Web.Models
{
    public class PictureViewModel
    {
        public PictureViewModel()
        {
            File = new FileViewModel(FileType.Image);
        }
        public string HtmlFieldPrefix { get; set; }
        public PictureModel Picture { get; set; }
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
    }
}
