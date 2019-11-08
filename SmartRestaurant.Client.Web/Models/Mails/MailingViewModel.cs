using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Mails.Commands.Create;
using SmartRestaurant.Application.Mails.Commands.Update;
using SmartRestaurant.Application.Users.Queries;
using SmartRestaurant.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Models.Mails
{
    public class MailingViewModel
    {
        public CreateMailingModel CreateModel { get; set; }
        public UpdateMailingModel UpdateModel { get; set; }
        public SelectList Templates { get; set;  }
        public SelectList ActionTypes { get; set;  }
        public SelectList NotificationTypes { get; set; }
        public EnumAction Action { get; set; }
       public List<UserItemModel> UsersItemModel { get; set; }

    }
}
