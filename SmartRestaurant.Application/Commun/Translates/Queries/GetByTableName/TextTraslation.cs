using SmartRestaurant.Application.Commun.Languages.Queries;

namespace SmartRestaurant.Application.Commun.Translates.Queries.GetByTableName
{
    public class TextTraslation
    {
        public LanguageItemModel Language { get; set; }
        public string Text { get; set; }
        public int Index { get; set; }
        public int ParentIndex { get; set; }
    }
}