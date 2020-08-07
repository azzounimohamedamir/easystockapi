using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.API.Models
{
    public class FIleUploadApi
    {
        public List<IFormFile> Files { get; set; }
        public Guid EntityId { get; set; }
        public bool IsLogo { get; set; }
    }
}