using SmartRestaurant.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests
{
	public class FirebaseServiceMocked : IFirebaseRepository
	{
        public Task<T> AddAsync<T>(string path, T data, CancellationToken cancellationToken)
        {
            return Task.FromResult(data);
        }
        public Task<T> AddCollectionAsync<T>(string path, T data, CancellationToken cancellationToken) 
        {
            return Task.FromResult(data);
        } 
        public Task<T> AddUserCollectionAsync<T>(string path, T data, CancellationToken cancellationToken) 
        {
            return Task.FromResult(data);
        }
        public Task<T> UpdateAsync<T>(string path, T data, CancellationToken cancellationToken) 
        {
            return Task.FromResult(data);
        }
        public Task<T> GetAsync<T>(string path, CancellationToken cancellationToken)
        {
            List<int> someValue = new List<int> { 2 };

            T convertedValue = (T)Convert.ChangeType(someValue, typeof(T));

            return Task.FromResult(convertedValue);
        }
        public Task<T> GetByIdAsync<T>(string path, string id, T data, CancellationToken cancellationToken)
        {
            return Task.FromResult(data);
        }
        public Dictionary<string, object> getOrderToDictionary<T>(T orderDto)
        {
            return new Dictionary<string, object>
            {
                { "name", orderDto}
            };
            
        }
    }
}
