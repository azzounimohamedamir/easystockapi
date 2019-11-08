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
    public class ParagraphController : Controller
    {
        private ITranslator _translator;

        public ParagraphController(ITranslator translator)
        {
            _translator = translator; 
        }
        
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


            /// the first choice is to send paragraph and translated it one time 
            /// then substracting it to multiple words 
            //for (var i = 0; i < langCulture.Count; i++)
            //{
            //    if (langCulture[i] == langWord.Lang) continue;

            //    string translatedWord = await _translator.Translate(langWord.Word, langCulture[i], langWord.Lang);
            //    targetLanguage = new LanguageWord()
            //    {
            //        Lang = langCulture[i],
            //        Word = translatedWord
            //    };
            //    targetLanguage.ParagraphSubstract(); 
            //    translatedTable.Add(targetLanguage);

            //}
            //translatedWordsList.TranslatedWords = translatedTable;
            //return translatedWordsList;


            /// the second choice is to substract paragraph into Words and translated
            /// it every word   
            langWord.ParagraphSubstract();
            for (var i = 0; i < langCulture.Count; i++)
            {
                if (langCulture[i] == langWord.Lang) continue;

                foreach (var item in langWord.Words)
                {
                    string translatedWord = await _translator.Translate(item, langCulture[i], langWord.Lang);
                    langWord.TranslatedWords.Add(translatedWord); 
                }
                
                targetLanguage = new LanguageWord()
                {
                    Lang = langCulture[i],
                    Word = langWord.WordsToParagraph()
            };
                targetLanguage.ParagraphSubstract();
                translatedTable.Add(targetLanguage);

            }
            translatedWordsList.TranslatedWords = translatedTable;
            return translatedWordsList;








        }


    }

    }

