using SmartRestaurant.Application.Templates.Commands.Create;
using SmartRestaurant.Application.Templates.Commands.Update;

namespace SmartRestaurant.Client.Web.Models.Templates
{
    public class EmailTemplateViewModel
    {
        public CreateTemplateModel CreateModel { get; set; }
        public UpdateTemplateModel UpdateModel { get; set; }
    }
}
