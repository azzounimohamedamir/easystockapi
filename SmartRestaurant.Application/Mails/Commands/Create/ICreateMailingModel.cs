using SmartRestaurant.Domain.Enumerations;

namespace SmartRestaurant.Application.Mails.Commands.Create
{
    public interface ICreateMailingModel
    {
        string Alias { get; set; }
        string Description { get; set; }
        EnumAction Action { get; set; }
        EnumTemplateType TemplateType { get; set; }
        string Name { get; set; }
        string TableName { get; set; }
        string TemplateId { get; set; }
    }
}