using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Interfaces
{
    public class IGlobalInjection
    {
        public ISmartRestaurantDatabaseService _databaseService { get; }
        private readonly INotifyService _notify;

        public IGlobalInjection(ISmartRestaurantDatabaseService databaseService, INotifyService notify)
        {
            if (notify == null)
            {
                throw new ArgumentNullException(nameof(notify));
            }

            _databaseService = databaseService ?? throw new ArgumentNullException(nameof(databaseService));
            _notify = notify;
        }
       
        //ILogger Logger;
        //Inotify Notify;
    }
}
