using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.Commun.Languages.Factory;
using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Interfaces;

namespace SmartRestaurant.Client.API.Controllers
{

    [Route("api/Languages")]
    [Route("api/{culture}/Languages")]
    public class LanguagesController : Controller
    {
        private readonly ISmartRestaurantDatabaseService db;

        public LanguagesController(ISmartRestaurantDatabaseService db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<List<LanguageCulture>> Get()
        {
            var languages = db.Languages.ToList();

            var list = await Task.Run(() =>
            {
                var result = new List<LanguageCulture>();
                foreach (var item in languages)
                {
                    var lang = new LanguageCulture() { LanguageName = item.EnglishName };
                    switch (item.IsoCode)
                    {

                        case "Ar":
                            lang.CultureIso = EnumLaguangeIso.Ar;
                            lang.SelectLanguage = "اختر لغتك";
                            break;

                        case "Fr":
                            lang.CultureIso = EnumLaguangeIso.Fr;
                            lang.SelectLanguage = "Choisir voter language";
                            break;

                        case "En":
                            lang.CultureIso = EnumLaguangeIso.En;
                            lang.SelectLanguage =  "Choose your Language " ;
                            break;
                        default:
                            break;
                    }
                    result.Add(lang);

                }

                return result;
            });
        
            return list;
                               
        }



}
}