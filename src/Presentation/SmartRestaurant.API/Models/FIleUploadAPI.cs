using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace SmartRestaurant.API.Models
{
    public class FIleUploadApi
    {
        public List<IFormFile> Files { get; set; }
        public Guid FoodBusinessId { get; set; }
        public bool IsLogo { get; set; }
    }
}