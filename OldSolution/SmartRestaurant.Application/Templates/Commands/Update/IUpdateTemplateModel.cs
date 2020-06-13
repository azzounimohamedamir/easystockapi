using SmartRestaurant.Application.Templates.Commands.Create;

namespace SmartRestaurant.Application.Templates.Commands.Update
{
    public interface IUpdateTemplateModel : ICreateTemplateModel
    {
        string Id { get; set; }
    }
}