using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;

namespace SmartRestaurant.Application.Depenses.Queries.FilterStrategy
{
    public interface IDepenseFilterStrategy
    {
        public PagedResultBase<Domain.Entities.Depense> FetchData(DbSet<Domain.Entities.Depense> stock, GetDepensesListQuery request);
    }
}
