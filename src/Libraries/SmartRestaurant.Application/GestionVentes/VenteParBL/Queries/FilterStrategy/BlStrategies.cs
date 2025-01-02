namespace SmartRestaurant.Application.GestionVentes.VenteParBl.Queries.FilterStrategy
{
    public static class BlStrategies
    {
        public static IBlFilterStrategy GetFilterStrategy(string currentFilter)
        {
            if (string.IsNullOrWhiteSpace(currentFilter))
                return new FilterBlByName();

            switch (currentFilter.ToLower())
            {
                case "name":
                    return new FilterBlByName();

                default:
                    return new FilterBlByName();
            }
        }
    }
}
