using Microsoft.Extensions.Options;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using OdooRpc.CoreCLR.Client.Models;
using OdooRpc.CoreCLR.Client;


using SmartRestaurant.Application.Common.Dtos.ValueObjects;

namespace SmartRestaurant.Infrastructure.Services
{
    public class Odoo
    {
        public string Url { get; set; }
        public string Db { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }

    public class OdooSaleOrderRepository : ISaleOrderRepository
    {
         readonly string _url;
         readonly string _db;
         readonly string _username;
         readonly string _password;
         readonly OdooRpcClient _client;




        public OdooSaleOrderRepository(IOptions<Odoo> conf)
        {
            _url = conf.Value.Url;
            _db = conf.Value.Db;
            _username = conf.Value.Username;
            _password = conf.Value.Password;
            var odooConnectionInfo = new OdooConnectionInfo
            {
                Host = _url,
                Database = _db,
                Username = _username,
                Password = _password
            };
            _client = new OdooRpcClient(odooConnectionInfo);
            


            // if (string.IsNullOrEmpty(_DataBaseBasepath))
            // {
            //     throw new ArgumentNullException("odoo Path not found in appsettings");
            // }

            // client = new HttpClient
            // {
            //     BaseAddress = new Uri(_DataBaseBasepath)
            // };


        }



        public async Task<long> CreateAsync(SaleOrderDto saleOrder)
        {
            await _client.Authenticate();
            var orderLineList = new List<Dictionary<string, object>>();

            foreach (var orderLine in saleOrder.OrderLines)
            {
                var orderLineDict = new Dictionary<string, object>
            {
                { "product_id", orderLine.ProductId },
                { "product_quantity", orderLine.Quantity },
                { "price_unit", orderLine.PriceUnit }
            };

                orderLineList.Add(orderLineDict);
            }

            var saleOrderDict = new Dictionary<string, object>
        {
                {"name", "Order 1"},
                { "date_order", "2023-03-04 13:44:27"},
                {"session_id", 1},
                { "amount_total", 232.0},
                {"amount_tax", 10.0},
                {"amount_paid",12.0},
                {"amount_return",33.0}







    };



            //await _client.Authenticate();
         long saleOrderId = await _client.Create("pos.order", saleOrderDict);

            if (saleOrderId == 0)
            {
                throw new Exception("Failed to create sales order in Odoo");
            }

            return saleOrderId;
        }
    }





}
