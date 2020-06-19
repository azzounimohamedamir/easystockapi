using SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Models;
using SmartRestaurant.Domain.Commun;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Factory
{
    public interface IGalleryFactory
    {
        Gallery Create(bool isDisabled,
                       string alias,
                       string name,
                       string description,
                       List<GalleryPictureModel> pictures);

        Gallery Create(GalleryModel model);
    }
    public class GalleryFactory : IGalleryFactory
    {
        private readonly IGalleryPictureFactory galleryPictureFactory;

        public GalleryFactory(IGalleryPictureFactory galleryPictureFactory)
        {
            this.galleryPictureFactory = galleryPictureFactory ?? throw new ArgumentNullException(nameof(galleryPictureFactory));
        }
        public Gallery Create(bool isDisabled,
                              string alias,
                              string name,
                              string description,
                              List<GalleryPictureModel> pictures)
        {
            return new Gallery
            {
                IsDisabled = isDisabled,
                Alias = alias,
                Name = name,
                Description = description,
                Pictures = (from picture in pictures select galleryPictureFactory.Create(picture)).ToList(),
            };

        }

        public Gallery Create(GalleryModel model)
        {
            return Create(model.IsDisabled,
                          model.Alias,
                          model.Name,
                          model.Description,
                          model.Pictures);
        }
    }
}
