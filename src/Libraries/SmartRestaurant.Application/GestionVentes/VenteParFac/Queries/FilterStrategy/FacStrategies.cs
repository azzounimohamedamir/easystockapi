using SmartRestaurant.Application.GestionVentes.VenteParBl.Queries.FilterStrategy;

namespace SmartRestaurant.Application.GestionVentes.VenteParFac.Queries.FilterStrategy
{
    public static class FacStrategies
    {
        public static IFacFilterStrategy GetFilterStrategy()
        {

            return new FilterFacByName();

        }
    }
}
