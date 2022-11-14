using SmartRestaurant.Application.Illness.Queries.FilterStrategy;

namespace SmartRestaurant.Application.il.Queries.FilterStrategy
{
    public static class IllnessUserStrategies
    {
        public static IIllnessUserFilterStrategy GetFilterStrategy(string currentFilter)
        {
            if (string.IsNullOrWhiteSpace(currentFilter))
                return new FilterIllnessesByIdinless();

            switch (currentFilter.ToLower())
            {
                case "name":
                    return new FilterIllnessesByIdinless();

                default:
                    return new FilterIllnessesByIdinless();
            }
        }
    }
}