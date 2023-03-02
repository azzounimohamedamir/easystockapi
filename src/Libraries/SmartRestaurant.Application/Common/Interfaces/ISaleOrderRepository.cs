using SmartRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;

namespace SmartRestaurant.Application.Common.Interfaces
{
 public interface ISaleOrderRepository
{
     Task<long> CreateAsync(SaleOrderDto saleOrder);
}

}
