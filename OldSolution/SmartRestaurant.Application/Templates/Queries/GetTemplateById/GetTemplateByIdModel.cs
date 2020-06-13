using SmartRestaurant.Domain.Enumerations;

namespace SmartRestaurant.Application.Templates.Queries.GetTemplateById
{
    public class GetTemplateByIdModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public EnumTemplateType Type { get; set; }
    }
}