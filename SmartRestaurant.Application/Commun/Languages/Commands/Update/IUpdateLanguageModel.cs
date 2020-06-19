using SmartRestaurant.Application.Commun.Languages.Commands.Create;

namespace SmartRestaurant.Application.Commun.Languages.Commands.Update
{
    public interface IUpdateLanguageModel:ICreateLanguageModel
    {
        string Id { get; set; }
    }
}