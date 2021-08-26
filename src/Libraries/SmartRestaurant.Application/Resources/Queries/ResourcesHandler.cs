using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace SmartRestaurant.Application.Resources.Queries
{
    public class ResourcesHandler : IRequestHandler<GetListOfCountriesQuery, string>
    {
        public async Task<string> Handle(GetListOfCountriesQuery request, CancellationToken cancellationToken)
        {
            var countries = Properties.Resources.countries;
            return await Task.FromResult(Encoding.UTF8.GetString(countries)).ConfigureAwait(false);
        }
    }
}