using SmartRestaurant.Application.ApplicationDataBase.Extensions;
using SmartRestaurant.Application.Commun.Specialites.Queries.Factory;
using SmartRestaurant.Application.Commun.Specialites.Queries.Models;
using SmartRestaurant.Application.Dishes.DishFamillies.Specifications;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Commun.Specialites.Queries.GetSpecialtiesBySpecifications
{
    public interface IGetSpecialityBySpecificationQuery
    {
        IEnumerable<SpecialityItemModel> Execute(SpecialitySpecification specification);
    }
    public class GetSpecialityBySpecificationQuery : IGetSpecialityBySpecificationQuery
    {
        private readonly ISmartRestaurantDatabaseService _db;
        private readonly ILoggerService<GetSpecialityBySpecificationQuery> _logger;
        private readonly INotifyService _notifyService;
        private readonly IMailingService _mailingService;
        public GetSpecialityBySpecificationQuery(
            ISmartRestaurantDatabaseService db,
            ILoggerService<GetSpecialityBySpecificationQuery> logger,
            IMailingService mailingService,
            INotifyService notifyService
            )
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _notifyService = notifyService ?? throw new ArgumentNullException(nameof(notifyService));
            _mailingService = mailingService ?? throw new ArgumentNullException(nameof(mailingService));
        }

        public IEnumerable<SpecialityItemModel> Execute(SpecialitySpecification specification)
        {
            try
            {  
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
