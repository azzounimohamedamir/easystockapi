using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Areas.Admin.Models
{
    public class PictureViewModel
    {
        public string Name { get; set; }
        public Uri PictureUrl { get; set; }

        public IFormFile PictureFile { get; set; }
    }
}
