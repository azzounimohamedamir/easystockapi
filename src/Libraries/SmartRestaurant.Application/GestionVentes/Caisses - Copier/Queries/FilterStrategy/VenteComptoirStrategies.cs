namespace SmartRestaurant.Application.GestionVentes.VenteComptoir.Queries.FilterStrategy
{
    public static class VenteComptoirStrategies
    {
        public static IVenteComptoirFilterStrategy GetFilterStrategy(string currentFilter)
        {
            if (string.IsNullOrWhiteSpace(currentFilter))
                return new FilterVenteComptoirByName();

            switch (currentFilter.ToLower())
            {
                case "name":
                    return new FilterVenteComptoirByName();

                default:
                    return new FilterVenteComptoirByName();
            }
        }
    }
}
