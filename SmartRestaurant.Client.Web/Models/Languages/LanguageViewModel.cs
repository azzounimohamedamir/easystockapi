using SmartRestaurant.Application.Commun.Languages.Commands.Create;
using SmartRestaurant.Application.Commun.Languages.Commands.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Models.Languages
{
    public class LanguageViewModel
    {
        public CreateLanguageModel CreateModel { get; set; }
        public UpdateLanguageModel UpdateModel { get; set; }

    }
}
