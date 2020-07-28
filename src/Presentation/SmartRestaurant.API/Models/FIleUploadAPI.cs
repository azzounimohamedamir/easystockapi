using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace SmartRestaurant.API.Models
{
    public class FIleUploadAPI
    {
        public List<IFormFile> Files { get; set; }
        public Guid RestaurantId { get; set; }
        public Boolean Logo { get; set; }
    }
}