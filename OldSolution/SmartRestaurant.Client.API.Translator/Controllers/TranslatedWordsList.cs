using Helpers;
using System.Collections.Generic;

namespace SmartRestaurant.Client.API.Translator.Controllers
{
    public class TranslatedWordsList
    {
        public List<LanguageWord> TranslatedWords { get; set; }
        public TranslatedWordsList()
        {
            TranslatedWords = new List<LanguageWord>(); 
        }
    }
}