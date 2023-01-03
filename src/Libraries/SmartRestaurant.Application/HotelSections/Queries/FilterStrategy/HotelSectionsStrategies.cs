namespace SmartRestaurant.Application.HotelSections.Queries.FilterStrategy
{
    public static class HotelSectionsStrategies
    {
        public static IHotelSectionsFilterStrategy GetFilterStrategy(string currentFilter)
        {
            if (string.IsNullOrWhiteSpace(currentFilter))
                return new FilterHotelSectionsByName();

            switch (currentFilter.ToLower())
            {
                case "names":
                    return new FilterHotelSectionsByName();

                default:
                    return new FilterHotelSectionsByName();
            }
        }
    }
}
