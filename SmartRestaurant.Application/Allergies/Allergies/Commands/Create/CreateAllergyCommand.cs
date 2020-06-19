using Helpers;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Allergies;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Allergies.Allergies.Commands.Create
{

    public interface ICreateAllergyCommand
    {
        void Execute(CreateAllergyModel model);
    }

    public class CreateAllergyCommand : ICreateAllergyCommand
    {
        private readonly ILoggerService<CreateAllergyCommand> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public CreateAllergyCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<CreateAllergyCommand> log,
            IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(CreateAllergyModel model)
        {
            try
            {
                var validator = new CreateAllergyCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }


                var namedAllergy =
                  db.Allergies.FirstOrDefault(f => f.Name == model.Name);

                if (namedAllergy != null)
                    throw new AlreadyExistsExeption($"{ nameof(Allergy)}:{model.Name} Exists");



                var allergy = model.ToEntity();
                foreach (var food in model.FoodsIds)
                {
                    allergy.FoodAllergies.Add(new FoodAllergy
                    {
                        FoodId = food.ToGuid()
                    });
                }

                db.Allergies.Add(allergy);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
