using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Dishes.DishFamillies.Commands.Factory;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;
using SmartRestaurant.Resources.Dishes.DishFamily;
using SmartRestaurant.Resources.SharedException;
using SmartRestaurant.Application.Helpers;

namespace SmartRestaurant.Application.Dishes.DishFamillies.Commands.Update
{
    public interface IUpdateDishFamilyCommand
    {
        void Execute(UpdateDishFamilyModel model);
    }
    public class UpdateDishFamilyCommand : IUpdateDishFamilyCommand
    {
        private readonly ISmartRestaurantDatabaseService _db;
        private readonly ILoggerService<UpdateDishFamilyCommand> _logger;
        private readonly IMailingService _mailingService;
        private readonly INotifyService _notifyService;
        private readonly IUpdateDishFamilyFactory _factory;

        public UpdateDishFamilyCommand(
            ISmartRestaurantDatabaseService db,
            ILoggerService<UpdateDishFamilyCommand> logger,
            IMailingService mailingService,
            INotifyService notifyService,
            IUpdateDishFamilyFactory factory
            )
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mailingService = mailingService ?? throw new ArgumentNullException(nameof(mailingService));
            _notifyService = notifyService ?? throw new ArgumentNullException(nameof(notifyService));
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }
        public void Execute(UpdateDishFamilyModel model)
        {
            try
            {
                var validator = new UpdateDishFamilyModelValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var _family = _db.DishFamilies
                    .Include(f => f.Picture)
                    .FirstOrDefault(f=>f.Id==model.Id.ToGuid());

                if(_family==null)
                    throw new NotFoundException(string.Format(SharedExceptionResource.NotFoundExceptionErrorMessage, DishFamilyUtilsResource.TableName , model.Id));

                _family = _factory.Create(_family, 
                    model.RestaurantId, 
                    model.ParentId, 
                    model.Name, 
                    model.Alias, 
                    model.Description,
                    model.IsDisabled);

                var restaurant = _db.Restaurants.Find(_family.RestaurantId);
                if (restaurant == null)
                {
                    throw new NotValidOperation(string.Format(SharedExceptionResource.NotValidOperationErrorMessage,DishFamilyResource.RestaurantId));
                }

                if (_family.ParentId != null)
                {
                    var parent = _db.DishFamilies.Find(_family.ParentId);
                    if (parent == null)
                    {
                        throw new NotValidOperation(SharedExceptionResource.NotValidOperationErrorMessage);
                    }
                }

                _family.PictureId =
                    PictureHelper.AddPictureToEntity(_db, model.Picture.Url);

                _db.DishFamilies.Update(_family);
                _db.Save();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
