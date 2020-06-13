using SmartRestaurant.Domain.Enumerations;

namespace SmartRestaurant.Application.Templates.Commands.Create
{
    public interface ICreateTemplateModel
    {
        string Alias { get; set; }
        string Description { get; set; }
        string Name { get; set; }
        EnumTemplateType Type { get; set; }
    }
}