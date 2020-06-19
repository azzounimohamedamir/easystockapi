using Microsoft.AspNetCore.Mvc.Rendering;

namespace SmartRestaurant.Client.Web.Models
{
    public class TitleListModel
    {
        public TitleListModel(SelectList list, string title)
        {
            List = list;
            Title = title;
        }
        public string Title { get; set; }
        public SelectList List { get; set; }
    }
}
