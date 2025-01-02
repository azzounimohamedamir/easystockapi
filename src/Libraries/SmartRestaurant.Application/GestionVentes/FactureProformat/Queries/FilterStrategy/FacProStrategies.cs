using SmartRestaurant.Application.GestionVentes.FactureProformat.Queries.FilterStrategy;

namespace SmartRestaurant.Application.GestionVentes.FactureProformat.Queries.FilterStrategy
{
    public static class FacProStrategies
    {
        public static IFacProFilterStrategy GetFilterStrategy()
        {
            
                    return new FilterFacProByName();

        }
    }
}
