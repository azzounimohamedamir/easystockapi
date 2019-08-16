using SmartRestaurant.Domain;
using SmartRestaurant.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Templates.Commands.Factory
{
    public interface ICreateTemplateFactory
    {
        Template Create(string Name, string Description ,
            EnumTemplateType Type , bool isDisabled ,
            string Alias ,string Title, string Subject, string Body);


    }

    public class CreateTemplateFactory : ICreateTemplateFactory
    {
       public  Template Create(string Name, string Description , 
           EnumTemplateType Type, bool isDisabled, string Alias
           , string Title, string Subject, string Body
           )
        {
            var entity = new Template();

            entity.Name = Name;
            entity.Description = Description;
            entity.Type = Type;
            entity.IsDisabled = isDisabled;
            entity.Description = Description;
            entity.Alias= Alias;
            entity.Subject = Subject;
            entity.Title = Title;
            entity.Body = Body;
            return entity;


        }
    }

}
