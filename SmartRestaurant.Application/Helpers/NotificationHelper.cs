using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Mails.Commands.Create;
using SmartRestaurant.Domain;
using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Helpers
{
    public static class NotificationHelper
    {
        public static void CreationNotification<T>(IMailingService mailing,
            ILoggerService<T> log, INotifyService notify, bool Error = false) where T : SmartRestaurantEntity
        {
          //  mailing.Send();
            
            //notify.Notify( );

            var logMessage = $"Create:{typeof(T).Name}";
            if (Error) log.LogError(logMessage);
            else log.LogInformation(logMessage);
        }
        public static void UpdatingNotification<T>()
        {

        }
        public static void DeletingNotification<T>()
        {

        }
    }
}
