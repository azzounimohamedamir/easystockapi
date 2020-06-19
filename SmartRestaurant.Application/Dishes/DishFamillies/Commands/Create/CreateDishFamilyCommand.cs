using SmartRestaurant.Application.Dishes.DishFamillies.Commands.Factory;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Resources.Dishes.DishFamily;
using SmartRestaurant.Resources.SharedException;
using System;

namespace SmartRestaurant.Application.Dishes.DishFamillies.Commands.Create
{
    public interface ICreateDishFamilyCommand
    {
        void Execute(CreateDishFamilyModel model);
    }
    public class CreateDishFamilyCommand : ICreateDishFamilyCommand
    {
        private readonly ISmartRestaurantDatabaseService _db;
        private readonly ILoggerService<CreateDishFamilyCommand> _logger;
        private readonly IMailingService _mailingService;
        private readonly INotifyService _notifyService;
        private readonly ICreateDishFamilyFactory _factory;

        public CreateDishFamilyCommand(
            ISmartRestaurantDatabaseService db,
            ILoggerService<CreateDishFamilyCommand> logger,
            IMailingService mailingService,
            INotifyService notifyService,
            ICreateDishFamilyFactory createDishFamilyFactory
            )
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mailingService = mailingService ?? throw new ArgumentNullException(nameof(mailingService));
            _notifyService = notifyService ?? throw new ArgumentNullException(nameof(notifyService));
            _factory = createDishFamilyFactory ?? throw new ArgumentNullException(nameof(createDishFamilyFactory));
        }

        public void Execute(CreateDishFamilyModel model)
        {
            try
            {
                var validator = new CreateDishFamilyModelValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var family = _factory.Create(
                    model.RestaurantId,
                    model.ParentId,
                    model.Name,
                    model.Alias,
                    model.Description,
                    model.IsDisabled);


                var restaurant = _db.Restaurants.Find(family.RestaurantId);
                if (restaurant == null)
                {
                    throw new NotValidOperation(string.Format(SharedExceptionResource.NotValidOperationErrorMessage, DishFamilyResource.RestaurantId));
                }
                if (family.ParentId != null)
                {
                    var parent = _db.DishFamilies.Find(family.ParentId);
                    if (parent == null)
                    {
                        throw new NotValidOperation(string.Format(SharedExceptionResource.NotValidOperationErrorMessage, DishFamilyResource.ParentId));
                    }
                }
                family.PictureId =
                    PictureHelper.AddPictureToEntity(_db, model.PictureUrl);

                _db.DishFamilies.Add(family);
                _db.Save();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
