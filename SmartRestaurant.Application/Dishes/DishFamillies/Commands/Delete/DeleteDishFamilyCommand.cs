using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;
using SmartRestaurant.Resources.SharedException;
using SmartRestaurant.Resources.Dishes.DishFamily;

namespace SmartRestaurant.Application.Dishes.DishFamillies.Commands.Delete
{
    public interface IDeleteDishFamilyCommand
    {
        void Execute(DeleteDishFamilyModel model);
    }
    public class DeleteDishFamilyCommand : IDeleteDishFamilyCommand
    {
        private readonly ISmartRestaurantDatabaseService _db;
        private readonly ILoggerService<DeleteDishFamilyCommand> _logger;
        private readonly IMailingService _mailingService;
        private readonly INotifyService _notifyService;

        public DeleteDishFamilyCommand(
            ISmartRestaurantDatabaseService db,
            ILoggerService<DeleteDishFamilyCommand> logger,
            IMailingService mailingService,
            INotifyService notifyService
            )
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mailingService = mailingService ?? throw new ArgumentNullException(nameof(mailingService));
            _notifyService = notifyService ?? throw new ArgumentNullException(nameof(notifyService));
        }
        public void Execute(DeleteDishFamilyModel model)
        {
            try
            {
                var validator = new DeleteDishFamilyModelValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }
                
                var _family = _db.DishFamilies
                    .Include(c => c.Childs)
                    .Include(c => c.Dishes)
                    .FirstOrDefault(f => f.Id == model.Id.ToGuid());

                if (_family == null)
                    throw new NotFoundException(string.Format(SharedExceptionResource.NotFoundExceptionErrorMessage, DishFamilyUtilsResource.TableName, model.Id));

                if (_family.Dishes.Any() || _family.Childs.Any())
                    throw new NestedDeleteException(string.Format(
                        SharedExceptionResource.NestedDeleteExceptionErrorMessage,
                        _family.Name));

                _db.DishFamilies.Remove(_family);
                _db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
