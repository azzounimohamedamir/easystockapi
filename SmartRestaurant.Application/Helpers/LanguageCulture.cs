
using SmartRestaurant.Application.Commun.Languages.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Helpers
{
    public class LanguageCulture
    {
        public string LanguageName { get; set; }
        public string  SelectLanguage { get; set; }
        public EnumLaguangeIso CultureIso { get; set; }
    }
}
