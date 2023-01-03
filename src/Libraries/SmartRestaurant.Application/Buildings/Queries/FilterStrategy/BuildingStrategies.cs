namespace SmartRestaurant.Application.Buildings.Queries.FilterStrategy
{
    public static class BuildingStrategies
    {
        public static IBuildingFilterStrategy GetFilterStrategy(string currentFilter)
        {
            if (string.IsNullOrWhiteSpace(currentFilter))
                return new FilterBuildingByName();

            switch (currentFilter.ToLower())
            {
                case "name":
                    return new FilterBuildingByName();

                default:
                    return new FilterBuildingByName();
            }
        }
    }
}
