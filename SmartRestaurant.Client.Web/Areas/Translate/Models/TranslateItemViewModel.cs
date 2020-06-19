using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Commun.Languages.Queries;
using SmartRestaurant.Application.Commun.Translates.Queries.GetByTableName;
using System.Collections.Generic;

namespace SmartRestaurant.Client.Web.Areas.Translate.Models
{
    public class TranslatesViewModel
    {
        public string SelectedTableName { get; set; }
        public SelectList TablesNames { get; set; }
        public List<ItemTranslatesModel> Translates { get; set; }
        public List<LanguageItemModel> Languages { get; set; }
    }
}
