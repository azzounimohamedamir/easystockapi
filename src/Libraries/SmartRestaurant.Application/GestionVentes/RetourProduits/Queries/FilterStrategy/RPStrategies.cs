using SmartRestaurant.Application.GestionVentes.VenteParBl.Queries.FilterStrategy;

namespace SmartRestaurant.Application.GestionVentes.RetourProduits.Queries.FilterStrategy
{
    public static class RPStrategies
    {
        public static IRPFilterStrategy GetFilterStrategy()
        {
            
                    return new FilterRPbyName();

        }
    }
}
