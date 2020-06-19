using SmartRestaurant.Application.Allergies.Illnesses.Commands.Create;
using SmartRestaurant.Application.Allergies.Illnesses.Commands.Delete;
using SmartRestaurant.Application.Allergies.Illnesses.Commands.Update;
using SmartRestaurant.Application.Allergies.Illnesses.Queries;
using SmartRestaurant.Application.Interfaces;
using System;

namespace SmartRestaurant.Application.Allergies.Illnesses.Services
{

    public interface IIllnessService
    {
        ICreateIllnessCommand Create { get; }
        IUpdateIllnessCommand Update { get; }
        IDeleteIllnessCommand Delete { get; }
        IIllnessQueries Queries { get; }
    }

    public class IllnessService : IIllnessService
    {
        private readonly ILoggerService<IllnessService> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public IllnessService(
            ISmartRestaurantDatabaseService db,
            ILoggerService<IllnessService> logger,
            IMailingService mailing,
            INotifyService notify,
            ICreateIllnessCommand create,
            IUpdateIllnessCommand update,
            IDeleteIllnessCommand delete,
            IIllnessQueries queries
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

        public ICreateIllnessCommand Create { get; private set; }

        public IUpdateIllnessCommand Update { get; private set; }

        public IDeleteIllnessCommand Delete { get; private set; }

        public IIllnessQueries Queries { get; private set; }
    }
}
