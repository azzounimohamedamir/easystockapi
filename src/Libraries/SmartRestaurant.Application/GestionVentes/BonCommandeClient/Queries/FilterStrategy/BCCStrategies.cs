using SmartRestaurant.Application.GestionVentes.VenteParBl.Queries.FilterStrategy;

namespace SmartRestaurant.Application.GestionVentes.BonCommandeClient.Queries.FilterStrategy
{
    public static class BCCStrategies
    {
        public static IBCCFilterStrategy GetFilterStrategy()
        {
            
                    return new FilterBCCByName();

        }
    }
}
