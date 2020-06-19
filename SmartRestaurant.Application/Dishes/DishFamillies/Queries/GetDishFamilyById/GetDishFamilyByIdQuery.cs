using SmartRestaurant.Application.Dishes.DishFamillies.Commands.Update;
using SmartRestaurant.Application.Dishes.DishFamillies.Specifications;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using SmartRestaurant.Application.ApplicationDataBase.Extensions;
using SmartRestaurant.Application.Exceptions;
using System.Linq;
using SmartRestaurant.Application.Dishes.DishFamillies.Commands.Factory;
using SmartRestaurant.Application.Commun.Galleries.Pictures.Models;
using SmartRestaurant.Resources.SharedException;
using SmartRestaurant.Resources.Dishes.DishFamily;

namespace SmartRestaurant.Application.Dishes.DishFamillies.Queries.GetDishFamilyById
{
    public interface IGetDishFamilyByIdQuery
    {
        UpdateDishFamilyModel Execute(string id);
    }
    public class GetDishFamilyByIdQuery : IGetDishFamilyByIdQuery
    {
        private readonly ISmartRestaurantDatabaseService _db;
        private readonly ILoggerService<GetDishFamilyByIdQuery> _logger;
        private readonly INotifyService _notifyService;        
        private readonly IMailingService _mailingService;
        public GetDishFamilyByIdQuery(
            ISmartRestaurantDatabaseService db,
            ILoggerService<GetDishFamilyByIdQuery> logger,
            IMailingService mailingService,
            INotifyService notifyService            

            )
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _notifyService = notifyService ?? throw new ArgumentNullException(nameof(notifyService));            
            _mailingService = mailingService ?? throw new ArgumentNullException(nameof(mailingService));
        }

        public UpdateDishFamilyModel Execute(string id)
        {
            try
            {               

                var specification = new DishFamilySpecification(fc => fc.Id == id.ToGuid())
                    .AddInclude(fc => fc.Parent);

                var _family = _db.DishFamilies
                    .ApplySpecification(specification)
                    .FirstOrDefault();

                if (_family == null)
                    throw new NotFoundException(string.Format(SharedExceptionResource.NotFoundExceptionErrorMessage, DishFamilyUtilsResource.TableName, id));


                return new UpdateDishFamilyModel
                {
                    Id = _family.Id.ToString(),
                    RestaurantId = _family.RestaurantId.ToString(),
                    ParentId = _family.ParentId.ToString(),
                    Name = _family.Name,
                    Alias = _family.Alias,
                    Picture = new PictureModel
                    {
                        Id = _family.Picture?.Id.ToString(),
                        Url = _family.Picture?.ImageUrl,
                    },
                    Description=_family.Description,
                    IsDisabled=_family.IsDisabled,
                };          
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
