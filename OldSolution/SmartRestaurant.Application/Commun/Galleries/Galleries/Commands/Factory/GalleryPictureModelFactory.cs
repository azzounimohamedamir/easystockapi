using SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Models;
using SmartRestaurant.Domain.Commun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Factory
{
    public interface IGalleryPictureModelFactory
    {
        GalleryPictureModel Create(string id,
                                   bool isDisabled,
                                   string alias,
                                   string name,
                                   string description,
                                   string imageUrl,
                                   bool isTheCover=false);

        GalleryPictureModel Create(Picture entity, string coverId);

        IEnumerable<GalleryPictureModel> Create(IEnumerable<Picture> entities, string coverId);
    }

    public class GalleryPictureModelFactory : IGalleryPictureModelFactory
    {       
        public GalleryPictureModel Create(Picture entity,string coverId)        
            =>Create
            (   
                entity.Id.ToString(),
                entity.IsDisabled,
                entity.Alias,
                entity.Name,
                entity.Description,
                entity.ImageUrl,
                entity.Id.ToString() == coverId?true:false
            );
        

        public GalleryPictureModel Create(string id,
                                          bool isDisabled,
                                          string alias,
                                          string name,
                                          string description,
                                          string imageUrl,
                                          bool isTheCover=false)
        => new GalleryPictureModel
            {
                Id = id,
                IsDisabled = isDisabled,
                Alias = alias,
                Name = name,
                Description = description,
                ImageUrl = imageUrl,
                IsTheCover=isTheCover,                
            };
        

        public IEnumerable<GalleryPictureModel> Create(IEnumerable<Picture> entities, string coverId)
        => (from entity in entities select Create(entity,coverId)).AsEnumerable();
    }
}
