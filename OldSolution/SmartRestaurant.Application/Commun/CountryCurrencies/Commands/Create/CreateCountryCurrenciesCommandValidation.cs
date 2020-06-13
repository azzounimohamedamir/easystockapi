using FluentValidation;
using SmartRestaurant.Application.Commun.CountryCurrencies.Queries;

namespace SmartRestaurant.Application.Commun.CountryCurrencies.Commands.Create
{
    public class CreateCountryCurrenciesCommandValidation:AbstractValidator<CountryCurrencyItem> 
    {
        public CreateCountryCurrenciesCommandValidation()
        {
        }
    }
}