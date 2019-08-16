using System;
using System.Collections.Generic;
using System.Linq;

namespace Helpers
{
    public class LanguageWord
    {
        /// <summary>
        ///  word = "Happy",
        ///  Lang="fr"
        /// </summary>

        public string Word { get; set; }

        public string Lang { get; set; }

        public IEnumerable<string> Words { get; set; }
        public List<string> TranslatedWords { get; set; }
        //// substrcat 
        public void ParagraphSubstract()
        {
            string copieWord = Word;
            copieWord = copieWord.Replace(".", string.Empty);
            Words = copieWord.Split(null);
            TranslatedWords = new List<string>();
        }

        /// join Words 
        public string WordsToParagraph()
        {
            return String.Join(" ", TranslatedWords.Where(s => !String.IsNullOrEmpty(s)));

        }


    }
}