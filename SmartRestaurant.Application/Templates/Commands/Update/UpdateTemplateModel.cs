using SmartRestaurant.Application.Templates.Commands.Create;
using SmartRestaurant.Domain.Enumerations;

namespace SmartRestaurant.Application.Templates.Commands.Update
{
    public class UpdateTemplateModel : CreateTemplateModel,IUpdateTemplateModel
    {

        public string Id { get; set; }
        
    }
}