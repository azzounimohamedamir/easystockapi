using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Restaurants.Commands.Create;
using SmartRestaurant.Application.Restaurants.Section.Commands.Models;

namespace SmartRestaurant.Application.Restaurants.Section.Commands.Create
{
    public interface ICreateSectionCommand
    {
        void Execute(SectionModel model);
    }
    public class CreateSectionCommand :ICreateSectionCommand
    {
        private readonly ILoggerService<CreateRestaurantCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public CreateSectionCommand(ILoggerService<CreateRestaurantCommand> logger, IMailingService mailing, INotifyService notify, ISmartRestaurantDatabaseService db)
        {
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
            this.db = db;
        }

        public void Execute(SectionModel model)
        {
            var validator = new CreateSectionValidator();
            var result = validator.Validate(model);
            if (!result.IsValid)
                throw new NotValidException(result.Errors);

            db.Sections.Add(model.ToEntity());
            db.Save();

        }
    }
}
