using SmartRestaurant.Application.Templates.Commands.Create;
using SmartRestaurant.Application.Templates.Commands.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Models.Templates
{
    public class EmailTemplateViewModel
    {
        public CreateTemplateModel CreateModel { get; set; }
        public UpdateTemplateModel UpdateModel { get; set; }
    }
}
