using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Templates.Commands.Create;
using SmartRestaurant.Application.Templates.Commands.Update;
using SmartRestaurant.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
