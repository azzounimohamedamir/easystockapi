using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Illness.Queries.FilterStrategy
{
    public interface IIllnessUserFilterStrategy
    {     
        public PagedResultBase<Domain.Entities.IlnessUser> FetchData(DbSet<Domain.Entities.IlnessUser> illnesses, GetIlnessessbyUserQuery request);
    }
}
