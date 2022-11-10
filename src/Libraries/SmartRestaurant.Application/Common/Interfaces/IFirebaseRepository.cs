using SmartRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Common.Interfaces
{
    public interface IFirebaseRepository
    {
        Task<T> AddAsync<T>(string path,T data,CancellationToken cancellationToken);
        Task<T> UpdateAsync<T>(string path,T data, CancellationToken cancellationToken);
        Task<T> GetAsync<T>(string path, CancellationToken cancellationToken);
        Task<T> GetByIdAsync<T>(string path, string id, T data, CancellationToken cancellationToken);
        Dictionary<string, object> getOrderToDictionary<T>(T orderDto);
    }
}
