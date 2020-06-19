using SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Models;
using SmartRestaurant.Domain.Commun;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using System.Linq;

namespace SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Factory
{
    public interface IGalleryPictureForDishFactory
    {
        Picture Create(GalleryPictureForDishModel model);
        List<Picture> Create(List<GalleryPictureForDishModel> models);
    }
    public class GalleryPictureForDishFactory : IGalleryPictureForDishFactory
    {
        private readonly IGalleryPictureFactory galleryPictureFactory;

        public GalleryPictureForDishFactory(IGalleryPictureFactory createGalleryPictureFactory)
        {
            //this.galleryPictureFactory = galleryPictureFactory ?? throw new ArgumentNullException(nameof(createGalleryPictureFactory));
        }
        public Picture Create(GalleryPictureForDishModel model)
        {
            var picture = galleryPictureFactory.Create(model.Picture);
            picture.RestaurantId = model.RestaurantId.ToGuid();
            return picture;
        }

        public List<Picture> Create(List<GalleryPictureForDishModel> models)
        {
            var pictures = new List<Picture>();
            foreach (var picture in models)
            {
                pictures.Add(Create(picture));
            }
            return pictures;
        }

    }
}
