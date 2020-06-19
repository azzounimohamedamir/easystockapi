using Helpers;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Factory;
using SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Models;
using SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Validation;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Commun;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Update
{
    public interface IUpdateGalleryForDishCommand
    {
        void Execute(Guid restaurantId, GalleryModel model, bool saveChange = true);
    }
    public class UpdateGalleryForDishCommand : IUpdateGalleryForDishCommand
    {
        private readonly ISmartRestaurantDatabaseService db;
        private readonly INotifyService notify;
        private readonly IMailingService mailing;
        private readonly ILoggerService<UpdateGalleryForDishCommand> logger;
        private readonly IGalleryFactory factory;

        public UpdateGalleryForDishCommand(
            ISmartRestaurantDatabaseService db,
            INotifyService notify,
            IMailingService mailing,
            ILoggerService<UpdateGalleryForDishCommand> logger,
            IGalleryFactory factory)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
            this.notify = notify ?? throw new ArgumentNullException(nameof(notify));
            this.mailing = mailing ?? throw new ArgumentNullException(nameof(mailing));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }
        public void Execute(Guid restaurantId, GalleryModel model, bool saveChange = true)
        {
            try
            {
                var validator = new GalleryModelValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }
                string CoverId = null;
                var guid = model.Id.ToGuid();

                Gallery gallery = db.Galleries
                    .Include(g => g.Pictures)
                    .FirstOrDefault(g => g.Id == guid);

                if (gallery == null) throw new NotFoundException();

                gallery.IsDisabled = model.IsDisabled;
                gallery.RestaurantId = restaurantId;
                gallery.Alias = model.Alias;
                gallery.Description = model.Description;
                gallery.Name = model.Name;

                HashSet<string> picInDBIds = new HashSet<string>(gallery.Pictures.Select(p => p.Id.ToString()));
                HashSet<string> picInModelIds = new HashSet<string>(model.Pictures.Where(p => !string.IsNullOrEmpty(p.Id)).Select(p => p.Id));


                //ToDelete
                foreach (string idDb in picInDBIds)
                {
                    if (!picInModelIds.Contains(idDb))
                    {
                        db.Pictures.Remove(gallery.Pictures.FirstOrDefault(p => p.Id == idDb.ToGuid()));
                    }
                }
                //ToUpdate
                foreach (var picModel in model.Pictures.Where(p => !string.IsNullOrEmpty(p.Id)))
                {
                    Picture pic = gallery.Pictures.FirstOrDefault(p => p.Id == picModel.Id.ToGuid());
                    pic.IsDisabled = picModel.IsDisabled;
                    pic.Alias = picModel.Alias;
                    pic.Description = picModel.Description;
                    pic.Name = picModel.Name;
                    pic.ImageUrl = picModel.ImageUrl;
                    db.Pictures.Update(pic);
                    if (picModel.IsTheCover) CoverId = picModel.Id;
                }
                //ToAdd               
                if (gallery.Pictures == null) gallery.Pictures = new List<Picture>();
                foreach (var picModel in model.Pictures.Where(p => string.IsNullOrEmpty(p.Id)))
                {
                    Guid newId = Guid.NewGuid();
                    Picture pic = new Picture
                    {
                        Id = newId,
                        IsDisabled = picModel.IsDisabled,
                        Alias = picModel.Alias,
                        Description = picModel.Description,
                        Name = picModel.Name,
                        ImageUrl = picModel.ImageUrl,
                        RestaurantId = restaurantId,
                    };
                    gallery.Pictures.Add(pic);

                    if (picModel.IsTheCover) CoverId = newId.ToString();
                }
                gallery.TheCoverPictureId = CoverId;
                db.Galleries.Update(gallery);

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
