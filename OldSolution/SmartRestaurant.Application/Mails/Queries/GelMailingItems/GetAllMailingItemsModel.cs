using SmartRestaurant.Domain.Enumerations;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Mails.Queries.GelMailingItems
{
    public class GetAllMailingItemsModel
    {
        public string Id { get; set; }
        public EnumAction Action { get; set; }
        public string TableName { get; set; }
       
        public string templateId { get; set; }
    }
}