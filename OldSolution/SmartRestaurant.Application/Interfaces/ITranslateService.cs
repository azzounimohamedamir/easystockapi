using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Interfaces
{
    public interface ITranslateService
    {
        T Translate<T>(ISmartRestaurantDatabaseService db,T entity, string languageIsoCode);
    }
}
