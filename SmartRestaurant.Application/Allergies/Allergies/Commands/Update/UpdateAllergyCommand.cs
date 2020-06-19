using Helpers;
using SmartRestaurant.Application.Allergies.Allergies.Commands.Create;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Allergies;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Allergies.Allergies.Commands.Update
{


    public interface IUpdateAllergyCommand
    {
        void Execute(UpdateAllergyModel model);
    }

    public class UpdateAllergyCommand : IUpdateAllergyCommand
    {
        private readonly ILoggerService<UpdateAllergyCommand> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public UpdateAllergyCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<UpdateAllergyCommand> log,
            IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(UpdateAllergyModel model)
        {
            try
            {
                var validator = new UpdateAllergyCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }
                var id = model.Id.ToGuid();
                var allergy = db.Allergies.FirstOrDefault(x => x.Id == id);
                if (allergy == null)
                {
                    throw new NotFoundException(nameof(allergy) + model.Id);
                }

                var namedAllergy =
                  db.Allergies.FirstOrDefault(f => f.Name == model.Name && f.Id != id);

                if (namedAllergy != null)
                    throw new AlreadyExistsExeption($"{ nameof(Allergy)}:{model.Name} Exists");


                model.ToEntity(ref allergy);

                var dbFoods = db.FoodAllergies
                  .Where(s => s.AllergyId == model.Id.ToGuid());

                // Exist in Db but not selected in UI
                foreach (var dbFood in dbFoods)
                {
                    if (!model.FoodsIds.Any(x => x.ToLower() ==
                    dbFood.FoodId.ToString().ToLower()))
                    {
                        allergy.FoodAllergies.Remove(dbFood);
                    }
                }
                // Does not exist in Db but selected in UI
                foreach (var foodId in model.FoodsIds)
                {
                    if (!dbFoods.Any(x => x.FoodId.ToString().ToLower() == foodId.ToLower()))
                    {
                        allergy.FoodAllergies.Add(new FoodAllergy
                        {
                            FoodId = foodId.ToGuid()
                        });
                    }
                }

                db.Allergies.Update(allergy);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
