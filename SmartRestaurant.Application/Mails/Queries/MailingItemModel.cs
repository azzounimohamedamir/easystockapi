using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain;
using SmartRestaurant.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Mails.Queries
{
    public class MailingItemModel
    {


        public string Id { get; set; }
        public EnumAction Action { get; set; }
        public string TableName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Alias { get; set; }
        public string IsDisabled { get; set; }
        public string templateId { get; set; }
        //public string Title { get; set; }
        //public string Subject { get; set; }
        //public string Body { get; set; }
        public EnumNotificationType Type { get; set; }

        public List<SRUser> UserList { get; set; }
        public string UserNames
        {

            get; set;
        }

    }
}
