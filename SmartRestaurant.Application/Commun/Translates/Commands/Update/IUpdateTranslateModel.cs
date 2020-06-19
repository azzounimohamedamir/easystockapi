using SmartRestaurant.Application.Commun.Translates.Commands.Create;

namespace SmartRestaurant.Application.Translates.Translates.Commands.Update
{
    public interface IUpdateTranslateModel : ICreateTranslateModel
    {
        string Id { get; set; }
    }
}