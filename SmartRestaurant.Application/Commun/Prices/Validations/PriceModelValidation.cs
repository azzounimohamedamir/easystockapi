using FluentValidation;
using SmartRestaurant.Application.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Commun.Prices.Validations
{
    public class PriceModelValidation:AbstractValidator<PriceModel>
    {
        public PriceModelValidation()
        {

        }
    }
}
