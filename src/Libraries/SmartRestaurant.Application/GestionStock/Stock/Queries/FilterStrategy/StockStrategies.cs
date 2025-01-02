using SmartRestaurant.Application.Common.Dtos;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Stock.Queries.FilterStrategy
{
    public static class StockStrategies
    {
        public static IStockFilterStrategy GetFilterStrategy(string currentFilter , List<AttributesWithTheirValuesDto> filterCriteriaData)
        {
            if (string.IsNullOrWhiteSpace(currentFilter))
                return new FilterStockByName();

            switch (currentFilter.ToLower())
            {
                case "name":
                    return new FilterStockByName();

                default:
                    return new FilterStockByName();
            }
        }
    }
}
