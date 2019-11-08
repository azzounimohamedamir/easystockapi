using SmartRestaurant.Application.Services.Models;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Forms.Models
{
    public class BaseImageModelDto : BaseModel
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCover { get; set; }

        public static implicit operator BaseImageModelDto(BaseImageModel model)
        {
            if (model == null) return null;
            return new BaseImageModelDto
            {
              Description= model.Description,
              ImageUrl = model.ImageUrl,
              IsCover= model.IsCover,
              Title = model.Title
            };
        }
        public static List<BaseImageModelDto> ToDtoList(List<BaseImageModel> images)
        {
            if (images == null) return null;
            return images.ConvertAll<BaseImageModelDto>((input) => { return input; });         
        }
    }
}