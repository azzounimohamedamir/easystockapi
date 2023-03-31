using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests
{
	public class OdooServiceMocked : IOdooRepository
	{
		public  Task<bool> Authenticate(Odoo info)
		{
		  return  Task.FromResult(true);
		}

		public Task<long> CreateAsync(string model, Dictionary<string, object> data)
		{
		   return Task.FromResult((long)1);
		}

		public Task<long> DeleteAsync(string model, long odooId)
		{
			 return Task.FromResult((long)1);
		}

		public Task<T> Read<T>(string model, long id)
		{
			List<int> someValue = new List<int> {2};

    T convertedValue = (T)Convert.ChangeType(someValue, typeof(T));

    return  Task.FromResult(convertedValue);
	 	  
		}

		public Task<T> Search<T>(string model, string attribute, object value, int limit)
		{
			List<int> someValue = new List<int> {2};

    T convertedValue = (T)Convert.ChangeType(someValue, typeof(T));

    return  Task.FromResult(convertedValue);
		}

		public Task<long> UpdateAsync(string model, long odooId, Dictionary<string, object> data)
		{
			 return Task.FromResult((long)1);
		}
	}
}
