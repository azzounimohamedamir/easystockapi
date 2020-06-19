using SmartRestaurant.Domain;
using SmartRestaurant.Domain.Enumerations;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Mails.Commands.Create
{
    public interface ICreateMailingFactory
    {
        Mailing Create(EnumAction enumAction, string tablename, string templateId 
            , string Name, string Alias
            , string Description , bool IsDisabled, EnumNotificationType type);


    }
    public class CreateMailingFactory : ICreateMailingFactory
    {
        public Mailing Create(EnumAction enumAction, string tablename, string templateId , string Name , string Alias
            , string Description, bool IsDisabled , EnumNotificationType type)
        {
            var entity = new Mailing();

            entity.Action = enumAction;
            entity.TableName = tablename;
            entity.IsDisabled = IsDisabled;
            entity.Alias = Alias;
            entity.Description = Description;
            entity.TemplateId = templateId;
           
            entity.Type = type;
           
            entity.Name = Name;
            return entity;


        }
    }

}