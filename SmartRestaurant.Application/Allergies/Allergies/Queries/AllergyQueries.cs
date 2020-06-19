using SmartRestaurant.Application.Allergies.Allergies.Queries.GetAll;
using SmartRestaurant.Application.Allergies.Allergies.Queries.GetById;
using SmartRestaurant.Application.Allergies.Allergies.Queries.GetBySpecification;
using SmartRestaurant.Application.Interfaces;
using System;

namespace SmartRestaurant.Application.Allergies.Allergies.Queries
{
    public interface IAllergyQueries
    {
        IGetAllergyByIdQuery GetById { get; }
        IGetAllAllergiesQuery List { get; }
        IGetAllergiesBySpecificationQuery Filter { get; }
    }

    public class AllergyQueries : IAllergyQueries
    {
        private readonly ILoggerService<AllergyQueries> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public AllergyQueries(
            ISmartRestaurantDatabaseService db,
            ILoggerService<AllergyQueries> logger,
            IMailingService mailing,
            INotifyService notify,
            IGetAllergyByIdQuery id,
            IGetAllAllergiesQuery list,
            IGetAllergiesBySpecificationQuery filter

            )
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.mailing = mailing ?? throw new ArgumentNullException(nameof(mailing));
            this.notify = notify ?? throw new ArgumentNullException(nameof(notify));
            Filter = filter ?? throw new ArgumentNullException(nameof(IGetAllergiesBySpecificationQuery));
            List = list ?? throw new ArgumentNullException(nameof(IGetAllAllergiesQuery));
            GetById = id ?? throw new ArgumentNullException(nameof(IGetAllergyByIdQuery));
        }

        public IGetAllergyByIdQuery GetById { get; private set; }

        public IGetAllAllergiesQuery List { get; private set; }

        public IGetAllergiesBySpecificationQuery Filter { get; private set; }
    }
}
