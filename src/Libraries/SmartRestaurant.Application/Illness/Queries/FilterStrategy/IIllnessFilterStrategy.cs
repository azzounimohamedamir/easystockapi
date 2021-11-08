using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Illness.Queries.FilterStrategy
{
    public interface IIllnessFilterStrategy
    {     
        public PagedResultBase<Domain.Entities.Illness> FetchData(DbSet<Domain.Entities.Illness> illnesses, GetIllnessesListQuery request);
    }
}
