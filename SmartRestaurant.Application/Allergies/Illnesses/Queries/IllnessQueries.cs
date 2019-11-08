using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Allergies.Illnesses.Queries.GetAll;
using SmartRestaurant.Application.Allergies.Illnesses.Queries.GetById;
using SmartRestaurant.Application.Allergies.Illnesses.Queries.GetBySpesification;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Allergies.Illnesses.Queries
{
    public interface IIllnessQueries
    {
        IGetIllnessByIdQuery GetById { get; }
        IGetAllIllnessesQuery List { get; }
        IGetIllnessesBySpecificationQuery Filter { get; }
    }

    public class IllnessQueries : IIllnessQueries
    {
        private readonly ILoggerService<IllnessQueries> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public IllnessQueries(
            ISmartRestaurantDatabaseService db,
            ILoggerService<IllnessQueries> logger,
            IMailingService mailing,
            INotifyService notify,
            IGetIllnessByIdQuery id,
            IGetAllIllnessesQuery list,
            IGetIllnessesBySpecificationQuery filter

            )
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.mailing = mailing ?? throw new ArgumentNullException(nameof(mailing));
            this.notify = notify ?? throw new ArgumentNullException(nameof(notify));
            Filter = filter ?? throw new ArgumentNullException(nameof(IGetIllnessesBySpecificationQuery));
            List = list ?? throw new ArgumentNullException(nameof(IGetAllIllnessesQuery));
            GetById = id ?? throw new ArgumentNullException(nameof(IGetIllnessByIdQuery));
        }

        public IGetIllnessByIdQuery GetById { get; private set; }

        public IGetAllIllnessesQuery List { get; private set; }

        public IGetIllnessesBySpecificationQuery Filter { get; private set; }
    }
}
