using SmartRestaurant.Application.Templates.Commands.Create;

namespace SmartRestaurant.Application.Templates.Commands.Update
{
    public class UpdateTemplateModel : CreateTemplateModel, IUpdateTemplateModel
    {

        public string Id { get; set; }

    }
}