using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;
using SmartRestaurant.Domain.Allergies;
using SmartRestaurant.Application.Allergies.Illnesses.Commands.Create;

namespace SmartRestaurant.Application.Allergies.Illnesses.Commands.Update
{


    public interface IUpdateIllnessCommand
    {
        void Execute(UpdateIllnessModel model);
    }

    public class UpdateIllnessCommand : IUpdateIllnessCommand
    {
        private readonly ILoggerService<UpdateIllnessCommand> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public UpdateIllnessCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<UpdateIllnessCommand> log,
            IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(UpdateIllnessModel model)
        {
            try
            {
                var validator = new UpdateIllnessCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var id = model.Id.ToGuid();
                var illnes = db.Illnesses.FirstOrDefault(x => x.Id ==id);
                if (illnes == null)
                {
                    throw new NotFoundException(nameof(Illness) + model.Id);
                }

                var named =
              db.Illnesses.FirstOrDefault(f => f.Name == model.Name && f.Id != id);

                if (named != null)
                    throw new AlreadyExistsExeption($"{ nameof(Illness)}:{model.Name} Exists");


                model.ToEntity(ref illnes);

                var dbFoods = db.FoodIllnesses
                  .Where(s => s.IllnessId == model.Id.ToGuid());

                // Exist in Db but not selected in UI
                foreach (var dbFood in dbFoods)
                {
                    if (!model.FoodsIds.Any(x => x.ToLower() ==
                    dbFood.FoodId.ToString().ToLower()))
                    {
                        illnes.FoodIllnesses.Remove(dbFood);
                    }
                }
                // Does not exist in Db but selected in UI
                foreach (var foodId in model.FoodsIds)
                {
                    if (!dbFoods.Any(x => x.FoodId.ToString().ToLower() == foodId.ToLower()))
                    {
                        illnes.FoodIllnesses.Add(new FoodIllness
                        {
                            FoodId = foodId.ToGuid()
                        });
                    }
                }

                db.Illnesses.Update(illnes);
                db.Save();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
