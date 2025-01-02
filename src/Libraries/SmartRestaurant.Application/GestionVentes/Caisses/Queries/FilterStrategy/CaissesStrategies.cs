using SmartRestaurant.Application.GestionVentes.Caisses.Queries.FilterStrategy;

namespace SmartRestaurant.Application.GestionVentes.Caisses.Queries.FilterStrategy
{
    public static class CaisseStrategies
    {
        public static ICaissesFilterStrategy GetFilterStrategy(string currentFilter)
        {
            if (string.IsNullOrWhiteSpace(currentFilter))
                return new FilterCaissesByName();

            switch (currentFilter.ToLower())
            {
                case "name":
                    return new FilterCaissesByName();

                default:
                    return new FilterCaissesByName();
            }
        }
    }
}
