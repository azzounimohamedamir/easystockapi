using SmartRestaurant.Application.GestionStock.Inventaire.Queries.FilterStrategy;

namespace SmartRestaurant.Application.GestionStock.Inventaire
.Queries.FilterStrategy
{
    public static class InvStrategies
    {
        public static IInvFilterStrategy GetFilterStrategy(string currentFilter)
        {
            if (string.IsNullOrWhiteSpace(currentFilter))
                return new FilterInvByName();

            switch (currentFilter.ToLower())
            {
                case "name":
                    return new FilterInvByName();

                default:
                    return new FilterInvByName();
            }
        }
    }
}
