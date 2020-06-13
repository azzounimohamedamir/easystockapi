using SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Models;
using SmartRestaurant.Domain.Commun;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;

namespace SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Factory
{
    public interface IGalleryForDishFactory
    {        
        Gallery Create(Guid dishId,GalleryModel model);
        Gallery Create(GalleryForDishModel model );
    }
    public class GalleryForDishFactory: IGalleryForDishFactory
    {
        private readonly IGalleryFactory galleryFactory;
        private readonly IGalleryPictureForDishFactory galleryPictureForDishFactory;

        public GalleryForDishFactory(IGalleryFactory galleryFactory,
            IGalleryPictureForDishFactory galleryPictureForDishFactory)
        {
            this.galleryFactory = galleryFactory ?? throw new ArgumentNullException(nameof(galleryFactory));
            this.galleryPictureForDishFactory = galleryPictureForDishFactory ?? throw new ArgumentNullException(nameof(galleryPictureForDishFactory));
            
        }

        

        public Gallery Create(GalleryForDishModel model)
        {
            var gallery = galleryFactory.Create(model.Gallery);
            gallery.DishId = model.DishId.ToGuid();
            if (model.Pictures != null) gallery.Pictures = galleryPictureForDishFactory.Create(model.Pictures);
            return gallery;
        }

        public Gallery Create(Guid dishId, GalleryModel model)
        {
            var gallery = galleryFactory.Create(model);
            gallery.DishId = dishId;
            return gallery;
        }
    }
}
