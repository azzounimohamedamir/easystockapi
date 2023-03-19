using SmartRestaurant.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OdooRpc.CoreCLR.Client.Models;
using OdooRpc.CoreCLR.Client;
using SmartRestaurant.Domain.ValueObjects;
using OdooRpc.CoreCLR.Client.Models.Parameters;

namespace SmartRestaurant.Infrastructure.Services
{

	public class OdooRepository : IOdooRepository
	{
		private OdooRpcClient _client;




		public OdooRepository()
		{
		}

		public async Task<bool> Authenticate(Odoo info)
		{
			try
			{
				var odooConnectionInfo = new OdooConnectionInfo
				{
					Host = info.Url,
					Database = info.Db,
					Username = info.Username,
					Password = info.Password
				};
				_client = new OdooRpcClient(odooConnectionInfo);
				await _client.Authenticate();

				return _client.SessionInfo.IsLoggedIn;
			}
			catch (Exception ex)
			{
				// handle the exception
				return false;
			}
		
		}

		public async Task<long> CreateAsync(string model, Dictionary<string, object> data)
		{
						
						try
				{
					// code that may throw an exception
					
					long dataId = await _client.Create(model, data); // send order to odoo

			if (dataId == 0)
			{
				throw new Exception("Failed to create sales order in Odoo");
			}

			return dataId;
				}
				catch (Exception ex)
				{
					// handle the exception
					return 0;
				}

			
		}

		public async Task<long> UpdateAsync(string model, long odooId, Dictionary<string, object> data)
		{
			try
			{
				await _client.Update(model, odooId, data);
				return odooId;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}

		public async Task<long> DeleteAsync(string model, long odooId)
		{
			try
			{
				await _client.Delete(model, odooId);
				return odooId;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}


		public async Task<T> Search<T>(string model, string attribute, object value, int limit)
		{
			try
			{
				var filter = new OdooDomainFilter().Filter(attribute, "=", value);
				var searchParams = new OdooSearchParameters(model, filter);
				var pagination = new OdooPaginationParameters()
				{
					Limit = limit,
				};
                var result = await _client.Search<T>(searchParams, pagination);
                return result;
			}
			catch (Exception exe)
			{
			  return default(T);
			}


		}


		public async Task<T> Read<T>(string model, long id)
		{
			try
			{
			return await _client.Get<T>(model, id);
			}
			catch (Exception exe)
			{
			  return default(T);
			}
		}


	}





}
