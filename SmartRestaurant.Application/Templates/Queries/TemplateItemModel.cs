using SmartRestaurant.Domain.Enumerations;

namespace SmartRestaurant.Application.Templates.Queries
{
    public class TemplateItemModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Alias { get; set; }
        public string IsDisabled { get; set; }
        public string Id { get; set; }
        public EnumTemplateType Type { get; set; }

    }
}
