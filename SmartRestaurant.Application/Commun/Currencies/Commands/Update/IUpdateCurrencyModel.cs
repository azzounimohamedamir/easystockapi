using SmartRestaurant.Application.Commun.Currencies.Commands.Create;

namespace SmartRestaurant.Application.Commun.Currencies.Commands.Update
{
    public interface IUpdateCurrencyModel : ICreateCurrencyModel
    {
        string Id { get; set; }
    }
}