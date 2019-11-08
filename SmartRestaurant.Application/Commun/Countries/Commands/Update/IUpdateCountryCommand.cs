using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Commun.Countries.Commands.Update
{
    public interface IUpdateCountryCommand
    {

        void Execute(UpdateCountryModel model); 
    }
}
