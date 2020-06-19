using SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Factory;
using SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Models;
using SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Validation;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Create
{
    public interface ICreateGalleryForMenuItemCommand
    {
        void Execute(Guid restaurantId, Guid MenuItemId, GalleryModel model, bool saveChange = true);
    }
    public class CreateGalleryForMenuItemCommand : ICreateGalleryForMenuItemCommand
    {
        private readonly ISmartRestaurantDatabaseService db;
        private readonly INotifyService notify;
        private readonly IMailingService mailing;
        private readonly ILoggerService<CreateGalleryForMenuItemCommand> logger;
        private readonly IGalleryFactory factory;

        public CreateGalleryForMenuItemCommand(
            ISmartRestaurantDatabaseService db,
            INotifyService notify,
            IMailingService mailing,
            ILoggerService<CreateGalleryForMenuItemCommand> logger,
            IGalleryFactory factory)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
            this.notify = notify ?? throw new ArgumentNullException(nameof(notify));
            this.mailing = mailing ?? throw new ArgumentNullException(nameof(mailing));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }
        public void Execute(Guid restaurantId, Guid MenuItemId, GalleryModel model, bool saveChange = true)
        {
            try
            {
                var validator = new GalleryModelValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }
                var gallery = factory.Create(model);
                gallery.Id = Guid.NewGuid();
                gallery.MenuItemId = MenuItemId;
                foreach (var picture in gallery.Pictures)
                {
                    picture.Id = Guid.NewGuid();
                    picture.RestaurantId = restaurantId;
                }
                var cover = model.Pictures.Where(p => p.IsTheCover).FirstOrDefault();
                var pictureGalleryCover = cover != null ? gallery.Pictures.FirstOrDefault(p => p.ImageUrl.Equals(cover.ImageUrl)) : null;
                gallery.TheCoverPictureId = pictureGalleryCover != null ? pictureGalleryCover.Id.ToString() : null;
                db.Galleries.Add(gallery);
                if (saveChange)
                {
                    db.Save();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
