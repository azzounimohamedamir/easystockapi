using SmartRestaurant.Domain.Enumerations;

namespace SmartRestaurant.Application.Templates.Queries.GetTemplateItems
{
    public class GetAllTemplateModel
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }
        public EnumTemplateType Type { get; set; }
    }
}