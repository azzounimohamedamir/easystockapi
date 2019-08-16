using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Commun.Country.Commands.Update
{
    public interface IUpdateCountryCommand
    {

        void Execute(UpdateCountryModel model); 
    }
}
