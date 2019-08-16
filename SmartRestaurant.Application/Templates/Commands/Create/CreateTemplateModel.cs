using SmartRestaurant.Domain.Enumerations;

namespace SmartRestaurant.Application.Templates.Commands.Create
{
    public class CreateTemplateModel : ICreateTemplateModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Alias { get; set; }
        public bool IsDisabled { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
        public EnumTemplateType Type { get; set; }
    }
}