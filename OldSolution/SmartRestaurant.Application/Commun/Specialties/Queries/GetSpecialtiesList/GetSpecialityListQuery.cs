using SmartRestaurant.Application.ApplicationDataBase.Extensions;
using SmartRestaurant.Application.Commun.Specialites.Queries.Factory;
using SmartRestaurant.Application.Commun.Specialites.Queries.Models;
using SmartRestaurant.Application.Dishes.DishFamillies.Specifications;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Commun.Specialites.Queries.GetSpecialtiesList
{
    public interface IGetSpecialityListQuery
    {
        IEnumerable<SpecialityItemModel> Execute();
    }
    public class GetSpecialityListQuery : IGetSpecialityListQuery
    {
        private readonly ISmartRestaurantDatabaseService _db;
        private readonly ILoggerService<GetSpecialityListQuery> _logger;
        private readonly INotifyService _notifyService;
        private readonly IMailingService _mailingService;

        public GetSpecialityListQuery(
            ISmartRestaurantDatabaseService db,
            ILoggerService<GetSpecialityListQuery> logger,
            IMailingService mailingService,
            INotifyService notifyService
            )
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _notifyService = notifyService ?? throw new ArgumentNullException(nameof(notifyService));
            _mailingService = mailingService ?? throw new ArgumentNullException(nameof(mailingService));
        }
        public IEnumerable<SpecialityItemModel> Execute()
        {
            try
            {
                var specification = new SpecialitySpecification()                                     
                    .ApplyOrderBy(fc => fc.Name);

                return _db.Specialties
                    .ApplySpecification(specification)
                    .ToSpecialityItemModels();
                    
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
