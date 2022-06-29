using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class WarningIngredientOfOrder
    {
        public List<WarningIngredientOfOrderWithIllness> SummaryIngredientIllness { get; set; }
    }
}
