using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helpers;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Client.API.Translator.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartRestaurant.Client.API.Translator.Controllers
{
    [Route("api/[controller]")]
    public class TranslatorController : Controller
    {
        public ITranslator _translator;

        public TranslatorController(ITranslator translator)
        {
            _translator = translator;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        
        public async Task<TranslatedWordsList> Post([FromBody]LanguageWord langWord)
        {



            TranslatedWordsList translatedWordsList = new TranslatedWordsList(); 
            var langCulture = new List<string>()
            {
                "fr" , "en", "ar" , "es" , "ja" , "ko",
                "du","tr"

            };
            var translatedTable = new List<LanguageWord>();
            LanguageWord targetLanguage;
            for (var i = 0; i < langCulture.Count; i++)
            {
                if (langCulture[i] == langWord.Lang) continue;

                string translatedWord = await _translator.Translate(langWord.Word, langCulture[i], langWord.Lang);
                targetLanguage = new LanguageWord()
                {
                    Lang = langCulture[i],
                    Word = translatedWord
                };

                translatedTable.Add(targetLanguage);
            }
            translatedWordsList.TranslatedWords = translatedTable; 
            return translatedWordsList;
        }

        //// PUT api/<controller>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
