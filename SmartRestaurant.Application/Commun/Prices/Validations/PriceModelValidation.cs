using FluentValidation;
using SmartRestaurant.Application.Services.Models;

namespace SmartRestaurant.Application.Commun.Prices.Validations
{
    public class PriceModelValidation : AbstractValidator<PriceModel>
    {
        public PriceModelValidation()
        {

        }
    }
}
