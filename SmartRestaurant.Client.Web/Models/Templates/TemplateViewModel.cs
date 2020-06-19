using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Templates.Commands.Create;
using SmartRestaurant.Application.Templates.Commands.Update;
using SmartRestaurant.Domain.Enumerations;

namespace SmartRestaurant.Client.Web.Models.Templates
{
    public class TemplateViewModel
    {
        public CreateTemplateModel CreateModel { get; set; }
        public UpdateTemplateModel UpdateModel { get; set; }

        public SelectList TemplateType { get; set; }
        public EnumTemplateType Type { get; set; }
    }
}
