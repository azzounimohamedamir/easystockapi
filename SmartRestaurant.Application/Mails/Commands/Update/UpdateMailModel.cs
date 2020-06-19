using SmartRestaurant.Application.Mails.Commands.Create;
using SmartRestaurant.Domain.Enumerations;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Mails.Commands.Update
{
    public class UpdateMailingModel : CreateMailingModel,IUpdateMailingModel
    {
        public string Id { get; set; }
        

    }
}