using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Allergies.Allergies.Commands.Create;
using SmartRestaurant.Application.Allergies.Allergies.Commands.Delete;
using SmartRestaurant.Application.Allergies.Allergies.Commands.Update;
using SmartRestaurant.Application.Allergies.Allergies.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Allergies.Allergies.Services
{
       
      public interface IAllergyService
    {
        ICreateAllergyCommand Create { get; }
        IUpdateAllergyCommand Update { get; }
        IDeleteAllergyCommand Delete { get; }
        IAllergyQueries Queries { get; }
    }

    public class AllergyService : IAllergyService
    {
        private readonly ILoggerService<AllergyService> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public AllergyService(
            ISmartRestaurantDatabaseService db,
            ILoggerService<AllergyService> logger,
            IMailingService mailing,
            INotifyService notify,
            ICreateAllergyCommand create,
            IUpdateAllergyCommand update,
            IDeleteAllergyCommand delete,
            IAllergyQueries queries
            )
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.mailing = mailing ?? throw new ArgumentNullException(nameof(mailing));
            this.notify = notify ?? throw new ArgumentNullException(nameof(notify));
            Create = create ?? throw new ArgumentNullException(nameof(create));
            Update = update ?? throw new ArgumentNullException(nameof(update));
            Delete = delete ?? throw new ArgumentNullException(nameof(delete));
            Queries = queries ?? throw new ArgumentNullException(nameof(queries));
        }

        public ICreateAllergyCommand Create { get; private set; }

        public IUpdateAllergyCommand Update { get; private set; }

        public IDeleteAllergyCommand Delete { get; private set; }

        public IAllergyQueries Queries { get; private set; }
    }
}
