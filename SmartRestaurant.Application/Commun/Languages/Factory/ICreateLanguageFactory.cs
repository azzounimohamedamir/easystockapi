using SmartRestaurant.Domain.Commun;

namespace SmartRestaurant.Application.Commun.Languages.Factory
{
    public interface ICreateLanguageFactory
    {
        Language Create(string Name, string IsoCode, bool IsRTL,
            string Alias, bool IsDisabled, string EnglishName);
    }

    public class CreateLanguageFactory : ICreateLanguageFactory
    {
        public Language Create(string Name, string IsoCode, bool IsRTL,
            string Alias, bool IsDisabled, string EnglishName)
        {
            var entity = new Language();
            entity.Alias = Alias;
            entity.Name = Name;
            entity.IsoCode = IsoCode;
            entity.IsRTL = IsRTL;
            entity.IsDisabled = IsDisabled;
            entity.EnglishName = EnglishName;


            return entity;



        }
    }
}
