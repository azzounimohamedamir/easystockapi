using SmartRestaurant.Application.ApplicationDataBase.Extensions;
using SmartRestaurant.Application.Dishes.DishFamillies.Queries.Factory;
using SmartRestaurant.Application.Dishes.DishFamillies.Queries.Models;
using SmartRestaurant.Application.Dishes.DishFamillies.Specifications;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Dishes.DishFamillies.Queries.GetDishFamilliesList
{
    public interface IGetDishFamilyListQuery
    {
        IEnumerable<DishFamilyItemModel> Execute(string parentId = null);
    }
    public class GetDishFamilyListQuery : IGetDishFamilyListQuery
    {
        private readonly ISmartRestaurantDatabaseService _db;
        private readonly ILoggerService<GetDishFamilyListQuery> _logger;
        private readonly INotifyService _notifyService;
        private readonly IMailingService _mailingService;

        public GetDishFamilyListQuery(
            ISmartRestaurantDatabaseService db,
            ILoggerService<GetDishFamilyListQuery> logger,
            IMailingService mailingService,
            INotifyService notifyService
            )
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _notifyService = notifyService ?? throw new ArgumentNullException(nameof(notifyService));
            _mailingService = mailingService ?? throw new ArgumentNullException(nameof(mailingService));
        }
        public IEnumerable<DishFamilyItemModel> Execute(string parentId = null)
        {
            try
            {
                var specification = new DishFamilySpecification
                    (
                    fc => fc.ParentId.ToString() == parentId
                    )
                    .AddInclude(fc => fc.Restaurant)
                    .AddInclude(fc => fc.Parent)
                    .ApplyOrderBy(fc => fc.Name);

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
