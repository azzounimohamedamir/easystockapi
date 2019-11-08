using SmartRestaurant.Domain.Enumerations;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Mails.Queries.GetMailingById
{
    public class GetMailingByIdModel
    {
        public string Id { get; set; }
        public EnumAction Action { get; set; }
        public string TableName { get; set; }
        
        public string templateId { get; set; }

    }
}