using SmartRestaurant.Domain.Entities;
using System.Threading.Tasks;


namespace SmartRestaurant.Application.Common.Interfaces
{
 public interface ISaleOrderRepository
{
     Task<long> CreateAsync(Order saleOrder);
}

}
