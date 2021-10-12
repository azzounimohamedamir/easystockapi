namespace SmartRestaurant.Application.Products.Queries.FilterStrategy
{
    public static class IngredientStrategies
    {
        public static IIngredientFilterStrategy GetFilterStrategy(string currentFilter)
        {
            if (string.IsNullOrWhiteSpace(currentFilter))
                return new FilterIngredientsByName();

            switch (currentFilter.ToLower())
            {
                case "name":
                    return new FilterIngredientsByName();

                default:
                    return new FilterIngredientsByName();
            }
        }
    }
}
