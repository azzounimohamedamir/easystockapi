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

    public class OdooSaleOrderRepository : ISaleOrderRepository
    {
        private OdooRpcClient _client;




        public OdooSaleOrderRepository()
        {
        }

        public async Task<bool> Authenticate(Odoo info)
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
            if (!_client.SessionInfo.IsLoggedIn)
            {
                throw new Exception("Failed to login with to Odoo");
            }
            return _client.SessionInfo.IsLoggedIn;
        }

        public async Task<long> CreateAsync(string model, Dictionary<string, object> data)
        {
            await _client.Authenticate();

            long dataId = await _client.Create(model, data); // send order to odoo

            if (dataId == 0)
            {
                throw new Exception("Failed to create sales order in Odoo");
            }

            return dataId;
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
                throw ex;
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
                throw ex;
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
                return await _client.Search<T>(searchParams, pagination);
            }
            catch (Exception exe)
            {
                throw exe;
            }


        }


        public async Task<T> Read<T>(string model, long id)
        {
            return await _client.Get<T>(model, id);
        }


    }





}
