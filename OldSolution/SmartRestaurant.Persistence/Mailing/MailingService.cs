using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartRestaurant.Persistence.Mailing
{
    public class MailingService : IMailingService
    {
        

        public Task SendAsync(params string[] args)
        {
            //Template
            //Users
            //Binding
            //Send
            //Compose Mail to send
            throw new NotImplementedException();
        }

        public Task SendAsync(EnumAction action, string tableName)
        {
            //mail select where
            //template
            //Users
            //Binding composition du mail
            //Send
             throw new NotImplementedException();
            
        }
    }
}
