using FluentValidation;

namespace SmartRestaurant.Application.Commun.CountryCurrencies.Commands.Update
{
    public class UpdateCountryCurrenciesCommandValidation : AbstractValidator<IUpdateCountryCurrenciesModel>
    {
        public UpdateCountryCurrenciesCommandValidation()
        {
        }
    }
}