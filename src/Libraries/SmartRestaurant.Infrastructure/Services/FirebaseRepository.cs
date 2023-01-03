using Microsoft.Extensions.Options;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using System.IO;
using System.Dynamic;
using System.Reflection;
using System.Linq;
using Newtonsoft.Json;
using SmartRestaurant.Application.Common.Dtos.OrdersDtos;
using System.Collections;

namespace SmartRestaurant.Infrastructure.Services
{
    public class FirebaseConfig
    {
        public string BasePath { get; set; }
   
    }

    public class FirebaseRepository : IFirebaseRepository
    {
        readonly string _DataBaseBasepath;
        readonly FirestoreDb _db;
        public FirebaseRepository(IOptions<FirebaseConfig> conf)
        {
            _DataBaseBasepath = conf.Value.BasePath;

            if (string.IsNullOrEmpty(_DataBaseBasepath))
            {
                throw new ArgumentNullException("fireBase Path not found in appsettings");
            }
            var pathConfigFile = Path.Combine(AppContext.BaseDirectory, "firebase.json");
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", pathConfigFile);
            _db = FirestoreDb.Create("g22project-69454");
        }

        public async Task<T> AddAsync<T>(string path, T data, CancellationToken cancellationToken)
        {
            try
            {
                DocumentReference doc = _db.Document(_DataBaseBasepath + "/" + path);
                var objectTosend = getOrderToDictionary(data);
                await doc.SetAsync(objectTosend, null, cancellationToken);
                return data;
            }
            catch (Exception exe)
            {
                throw exe;
            }
             
        }
        public Dictionary<string, object>  getOrderToDictionary<T>(T orderDto)
        {
           var result = orderDto.GetType()
            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .ToDictionary(prop =>
                {
                    return prop.Name.Substring(0,2).ToLower()+ prop.Name.Substring(2);
                }    
                , 
                prop =>
                {
                    var valueToConvert = prop.GetValue(orderDto, null);
                    var type = prop.PropertyType;
                    if (valueToConvert == null)
                        return null;
                    if (type == typeof(string) || type == typeof(String) || type == typeof(int) || type == typeof(Single)
                    || type == typeof(float)|| type == typeof(double))
                    {
                        return valueToConvert;
                    }
                    else if (type == typeof(DateTime) || type == typeof(DateTime?))
                    {
                        DateTime value =Convert.ToDateTime(valueToConvert);
                        return DateTime.SpecifyKind(value, DateTimeKind.Utc);
                    }else if (type.IsEnum)
                    {
                        object underlyingValue = Convert.ChangeType(valueToConvert, Enum.GetUnderlyingType(valueToConvert.GetType()));
                        return underlyingValue;

                    }
                    else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
                    {
                        var Colection = new ArrayList();
                        var elementCollection = (IEnumerable)valueToConvert;
                        foreach (var item in elementCollection)
                        {
                            var elementColl = getOrderToDictionary(item);
                            Colection.Add(elementColl);
                        }
                        return Colection;
                    }
                    else
                    {
                        return getOrderToDictionary(valueToConvert);
                    }
                }
            );
            return result;
        }
   
        public Task<T> GetAsync<T>(string path, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync<T>(string path, string id, T data, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<T> UpdateAsync<T>(string path, T data, CancellationToken cancellationToken)
        {
            try
            {
                DocumentReference doc = _db.Document(_DataBaseBasepath + "/" + path);
                var objectTosend = getOrderToDictionary(data);             
                await doc.UpdateAsync(objectTosend, null, cancellationToken);
                return data;
            }
            catch (Exception exe)
            {
                throw exe;
            }
        }

    }
}
