using SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Models;
using SmartRestaurant.Domain.Commun;

namespace SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Factory
{
    public interface IGalleryPictureFactory
    {
        Picture Create(GalleryPictureModel model);
    }

    public class GalleryPictureFactory : IGalleryPictureFactory
    {
        public Picture Create(GalleryPictureModel model)
        {
            return new Picture
            {
                IsDisabled = model.IsDisabled,
                Alias = model.Alias,
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl
            };
        }
    }
}
