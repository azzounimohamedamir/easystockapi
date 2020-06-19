using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Allergies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;
namespace SmartRestaurant.Application.Allergies.Illnesses.Commands.Create
{


    public interface ICreateIllnessCommand
    {
        void Execute(CreateIllnessModel model);
    }

    public class CreateIllnessCommand : ICreateIllnessCommand
    {
        private readonly ILoggerService<CreateIllnessCommand> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public CreateIllnessCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<CreateIllnessCommand> log,
            IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(CreateIllnessModel model)
        {
            try
            {
                var validator = new CreateIllnessCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var named = db.Illnesses.FirstOrDefault(f => f.Name == model.Name);

                if (named != null)
                    throw new AlreadyExistsExeption($"{ nameof(Illness)}:{model.Name} Exists");


                var illnes = model.ToEntity();
                foreach (var food in model.FoodsIds)
                {
                    illnes.FoodIllnesses.Add(new FoodIllness
                    {
                        FoodId = food.ToGuid()
                    });
                }

                db.Illnesses.Add(illnes);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
