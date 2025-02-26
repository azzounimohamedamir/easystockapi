using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Common.Interfaces
{
    public interface IFirebaseRepository
    {
        Task<T> AddFoodBusinessAsync<T>(string path, T data, CancellationToken cancellationToken);
        Task<T> AddHotelAsync<T>(string path, T data, CancellationToken cancellationToken);
        Task<T> AddFoodBusinessCollectionAsync<T>(string path, T data, CancellationToken cancellationToken);
        Task<T> AddHotelCollectionAsync<T>(string path, T data, CancellationToken cancellationToken);
        Task<T> AddUserCollectionAsync<T>(string path, T data, CancellationToken cancellationToken);
        Task<T> UpdateFoodBusinessAsync<T>(string path, T data, CancellationToken cancellationToken);
        Task<T> UpdateHotelAsync<T>(string path, T data, CancellationToken cancellationToken);
        Task<T> GetAsync<T>(string path, CancellationToken cancellationToken);
        Task<T> GetByIdAsync<T>(string path, string id, T data, CancellationToken cancellationToken);
        Dictionary<string, object> getOrderToDictionary<T>(T orderDto);
    }
}
