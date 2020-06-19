using Helpers;
using SmartRestaurant.Application.ApplicationDataBase.Extensions;
using SmartRestaurant.Application.Dishes.DishFamillies.Queries.Factory;
using SmartRestaurant.Application.Dishes.DishFamillies.Queries.Models;
using SmartRestaurant.Application.Dishes.DishFamillies.Specifications;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Dishes.DishFamillies.Queries.GetDishFamilliesBySpecifications
{
    public interface IGetDishFamilyByRestaurantIdQuery
    {
        IEnumerable<DishFamilyItemModel> Execute(string restaurantId);
    }
    public class GetDishFamilyByRestaurantIdQuery : IGetDishFamilyByRestaurantIdQuery
    {
        private readonly ISmartRestaurantDatabaseService _db;
        private readonly ILoggerService<GetDishFamilyBySpecificationQuery> _logger;
        private readonly INotifyService _notifyService;
        private readonly IMailingService _mailingService;
        public GetDishFamilyByRestaurantIdQuery(
            ISmartRestaurantDatabaseService db,
            ILoggerService<GetDishFamilyBySpecificationQuery> logger,
            IMailingService mailingService,
            INotifyService notifyService
            )
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _notifyService = notifyService ?? throw new ArgumentNullException(nameof(notifyService));
            _mailingService = mailingService ?? throw new ArgumentNullException(nameof(mailingService));
        }

        public IEnumerable<DishFamilyItemModel> Execute(string restaurantId)
        {
            try
            {
                var specification = new DishFamilySpecification(df => df.RestaurantId == restaurantId.ToGuid() && df.ParentId == null).RemoveAllInclude();
                return _db.DishFamilies
                    .ApplySpecification(specification)
                    .ToDishFamilyItemModels();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
