using System.Collections.Generic;
using System.Threading.Tasks;
using SmartRestaurant.Domain.ValueObjects;

namespace SmartRestaurant.Application.Common.Interfaces
{
 public interface ISaleOrderRepository
{
        Task<bool> Authenticate(Odoo info);
        Task<long> CreateAsync(string model,Dictionary<string,object> data);
        Task<long> UpdateAsync(string model,long odooId,Dictionary<string,object> data);
        Task<long> DeleteAsync(string model,long odooId);
        Task<T> Search<T>(string model, string attribute, string value, int limit);

}

}
