using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Enumerations;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Mails.Commands.Create
{
    public class CreateMailingModel : ICreateMailingModel
    {

        public EnumAction Action { get; set; }
        public string TableName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Alias { get; set; }
        public string TemplateId { get; set; }
        public EnumTemplateType TemplateType { get; set; }
        public bool IsDisabled { get; set; }
        public string Id { get; set; }
        public List<string> UsersId { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public EnumNotificationType Type { get; set; }

    }
}