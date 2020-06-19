using SmartRestaurant.Application.Dishes.DishIngredients.Commands.Factory;
using SmartRestaurant.Application.Dishes.DishIngredients.Commands.Models;
using SmartRestaurant.Application.Interfaces;
using System;

namespace SmartRestaurant.Application.Dishes.DishIngredients.Commands.Create
{
    public interface ICreateDishIngredientCommand
    {
        void Execute(DishIngredientModel model, bool saveChange = true);
    }
    public class CreateDishIngredientCommand : ICreateDishIngredientCommand
    {
        private readonly ISmartRestaurantDatabaseService db;
        private readonly ILoggerService<CreateDishIngredientCommand> logger;
        private readonly IMailingService mailingService;
        private readonly INotifyService notifyService;
        private readonly IDishIngredientFactory createDishFactory;

        public CreateDishIngredientCommand(
            ISmartRestaurantDatabaseService db,
            ILoggerService<CreateDishIngredientCommand> logger,
            IMailingService mailingService,
            INotifyService notifyService,
            IDishIngredientFactory createDishFactory
            )
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.mailingService = mailingService;
            this.notifyService = notifyService ?? throw new ArgumentNullException(nameof(notifyService));
            this.createDishFactory = createDishFactory ?? throw new ArgumentNullException(nameof(createDishFactory));
        }
        public void Execute(DishIngredientModel model, bool saveChange = true)
        {
            throw new NotImplementedException();
        }
    }
}
