using SmartRestaurant.Domain;
using SmartRestaurant.Domain.Enumerations;

namespace SmartRestaurant.Application.Notifications.Commands.Factory
{
    public interface ICreateNotificationFactory
    {
        Notification Create(EnumAction enumAction, string tablename, string templateId
            , string Name, string Alias
            , string Description,
            bool IsDisabled, EnumNotificationType type);


    }
    public class CreateNotificationFactory : ICreateNotificationFactory
    {
        public Notification Create(EnumAction enumAction, string tablename, string templateId, string Name, string Alias
            , string Description, bool IsDisabled, EnumNotificationType type)
        {
            var entity = new Notification();

            entity.Action = enumAction;
            entity.TableName = tablename;
            entity.IsDisabled = IsDisabled;
            entity.Alias = Alias;
            entity.Description = Description;
            entity.TemplateId = templateId;
            //  entity.Template.enumTemplateType = enumTemplateType; 
            entity.Name = Name;

            entity.Type = type;
            return entity;


        }
    }

}
