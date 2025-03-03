﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.API.Models.MediaModels
{
    public class FIleUploadModel
    {
        public List<IFormFile> Files { get; set; }
        public Guid EntityId { get; set; }
        public bool IsLogo { get; set; }
    }
}