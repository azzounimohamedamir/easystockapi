namespace SmartRestaurant.Application.FoodBusiness.Queries.FilterStrategy
{
    public static class FoodBusinessStrategies
    {
        public static IFoodBusinessFilterStrategy GetFilterStrategy(string currentFilter)
        {
            if (string.IsNullOrWhiteSpace(currentFilter))
                return new FilterFoodBusinessesByName();

            switch (currentFilter.ToLower())
            {
                case "name":
                    return new FilterFoodBusinessesByName();

                default:
                    return new FilterFoodBusinessesByName();
            }
        }
    }
}
