using MediatR;

namespace SmartRestaurant.Application.Resources.Queries
{
    public class GetListOfCountriesQuery : IRequest<string>
    {
    }

    public class Country
    {
        public string Name { get; set; }
        public string DialCode { get; set; }
        public string IsoCode { get; set; }
        public string Flag { get; set; }
    }
}
