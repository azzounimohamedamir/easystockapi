using Helpers;
using SmartRestaurant.Application.ApplicationDataBase.Extensions;
using SmartRestaurant.Application.Commun.Specialites.Commands.Update;
using SmartRestaurant.Application.Dishes.DishFamillies.Specifications;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Resources.Commun.Specialities;
using SmartRestaurant.Resources.SharedException;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Commun.Specialites.Queries.GetSpecialityById
{
    public interface IGetSpecialityByIdQuery
    {
        UpdateSpecialityModel Execute(string id);
    }
    public class GetSpecialityByIdQuery : IGetSpecialityByIdQuery
    {
        private readonly ISmartRestaurantDatabaseService _db;
        private readonly ILoggerService<GetSpecialityByIdQuery> _logger;
        private readonly INotifyService _notifyService;
        private readonly IMailingService _mailingService;
        public GetSpecialityByIdQuery(
            ISmartRestaurantDatabaseService db,
            ILoggerService<GetSpecialityByIdQuery> logger,
            IMailingService mailingService,
            INotifyService notifyService

            )
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _notifyService = notifyService ?? throw new ArgumentNullException(nameof(notifyService));
            _mailingService = mailingService ?? throw new ArgumentNullException(nameof(mailingService));
        }

        public UpdateSpecialityModel Execute(string id)
        {
            try
            {

                var specification = new SpecialitySpecification(fc => fc.Id == id.ToGuid());

                var _speciality = _db.Specialties
                    .ApplySpecification(specification)
                    .FirstOrDefault();

                if (_speciality == null)
                    throw new NotFoundException(string.Format(SharedExceptionResource.NotFoundExceptionErrorMessage, SpecialityUtilsResource.TableName, id));


                return new UpdateSpecialityModel
                {
                    Id = _speciality.Id.ToString(),
                    Name = _speciality.Name,
                    Alias = _speciality.Alias,
                    Description = _speciality.Description,
                    IsDisabled = _speciality.IsDisabled,
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
