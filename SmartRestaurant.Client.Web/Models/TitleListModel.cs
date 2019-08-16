using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
