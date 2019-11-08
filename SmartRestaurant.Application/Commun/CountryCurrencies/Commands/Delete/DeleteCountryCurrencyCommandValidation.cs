using FluentValidation;
using SmartRestaurant.Application.Commun.CountryCurrencies.Queries;

namespace SmartRestaurant.Application.Commun.CountryCurrencies.Commands.Delete
{
    public class DeleteCountryCurrencyCommandValidation : AbstractValidator<CountryCurrencyItem>
    {
        public DeleteCountryCurrencyCommandValidation()
        {
        }
    }
}