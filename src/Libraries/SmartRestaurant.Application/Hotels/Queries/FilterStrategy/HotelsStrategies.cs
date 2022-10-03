namespace SmartRestaurant.Application.Hotels.Queries.FilterStrategy
{
    public static class HotelsStrategies
    {
        public static IHotelsFilterStrategy GetFilterStrategy(string currentFilter)
        {
            if (string.IsNullOrWhiteSpace(currentFilter))
                return new FilterHotelsByName();

            switch (currentFilter.ToLower())
            {
                case "name":
                    return new FilterHotelsByName();

                default:
                    return new FilterHotelsByName();
            }
        }
    }
}
