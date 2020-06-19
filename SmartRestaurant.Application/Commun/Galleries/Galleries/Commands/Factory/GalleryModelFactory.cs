using SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Models;
using SmartRestaurant.Domain.Commun;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Factory
{
    public interface IGalleryModelFactory
    {
        GalleryModel Create(
                       string id,
                       bool isDisabled,
                       string alias,
                       string name,
                       string description,
                       string coverId,
                       IEnumerable<Picture> pictures);

        GalleryModel Create(Gallery model);
    }

    public class GalleryModelFactory : IGalleryModelFactory
    {
        private readonly IGalleryPictureModelFactory galleryPictureModelFactory;

        public GalleryModelFactory(IGalleryPictureModelFactory galleryPictureModelFactory)
        {
            this.galleryPictureModelFactory = galleryPictureModelFactory ?? throw new ArgumentNullException(nameof(galleryPictureModelFactory));
        }

        public GalleryModel Create(string id,
                              bool isDisabled,
                              string alias,
                              string name,
                              string description,
                              string coverId,
                              IEnumerable<Picture> pictures)
        {
            var gallery = new GalleryModel
            {
                Id = id,
                IsDisabled = isDisabled,
                Alias = alias,
                Name = name,
                Description = description,
                Pictures = (from picture in pictures select galleryPictureModelFactory.Create(picture, coverId)).ToList(),
            };

            return gallery;

        }

        public GalleryModel Create(Gallery model)
        {
            if (model == null) return null;
            return Create(model.Id.ToString(),
                model.IsDisabled,
                          model.Alias,
                          model.Name,
                          model.Description,
                          model.TheCoverPictureId,
                          model.Pictures);
        }
    }
}
