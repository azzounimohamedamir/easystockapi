using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace SmartRestaurant.Client.API.Translator.Services
{
    public interface ITranslator
    {
        Task<string> Translate(string word, string toLanguage, string fromLanguage); 
    }

    public class TranslatorHelper : ITranslator
    {
        public async Task<string> Translate(string word,string toLanguage , string fromLanguage)
        {
        
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={fromLanguage}&tl={toLanguage}&dt=t&q={HttpUtility.UrlEncode(word)}";
            var webClient = new WebClient
            {
                Encoding = System.Text.Encoding.UTF8
            };
            var result =await webClient.DownloadStringTaskAsync(url);
            try
            {
                result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
                return result;
            }
            catch
            {
                return "Error";
            }
        }

    }
}
