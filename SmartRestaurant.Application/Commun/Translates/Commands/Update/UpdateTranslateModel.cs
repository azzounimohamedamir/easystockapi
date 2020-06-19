using SmartRestaurant.Application.Commun.Translates.Commands.Create;
using SmartRestaurant.Application.Translates.Translates.Commands.Update;

namespace SmartRestaurant.Application.Commun.Translates.Commands.Update
{
    public class UpdateTranslateModel : CreateTranslateModel, IUpdateTranslateModel
    {
        public string Id { get; set; }

    }
}