using SmartRestaurant.Application.Commun.Currencies.Commands.Create;
using SmartRestaurant.Application.Commun.Currencies.Commands.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Models.Currencies
{
    public class CurrencyViewModel
    {

        public CreateCurrencyModel CreateModel { get; set; }
        public UpdateCurrencyModel UpdateModel { get; set; }

    }
}
