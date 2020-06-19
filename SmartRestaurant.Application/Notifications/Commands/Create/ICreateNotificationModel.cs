using SmartRestaurant.Domain.Enumerations;

namespace SmartRestaurant.Application.Notifications.Commands.Create
{
    public interface ICreateNotificationModel
    {
        EnumAction Action { get; set; }
        string Alias { get; set; }
        string Description { get; set; }
         EnumTemplateType TemplateType { get; set; }
        string Name { get; set; }
        string TableName { get; set; }
        string TemplateId { get; set; }
    }
}