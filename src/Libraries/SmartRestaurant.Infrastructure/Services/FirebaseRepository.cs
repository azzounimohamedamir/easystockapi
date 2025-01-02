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
using System.Collections;

namespace SmartRestaurant.Infrastructure.Services
{
    //public class FirebaseConfig
    //{
    //    public string FoodBusinessBasePath { get; set; }
    //    public string HotelBasePath { get; set; }
    //    public string UserBasePath { get; set; }

    //}

    public static class FirebaseConfig
    {
        public static string FoodBusinessBasePath = "FoodBusinessTest";
        public static string HotelBasePath = "HotelTest";
        public static string UserBasePath = "UserTest";

    }

    public class FirebaseRepository : IFirebaseRepository
    {
        readonly string _DataBaseFoodBusinessBasepath;
        readonly string _DataBaseHotelBasepath;
        readonly string _DataBaseUserBasepath;
        readonly FirestoreDb _db;
        public FirebaseRepository()
        //public FirebaseRepository(FirebaseConfig conf)
        {
            //_DataBaseFoodBusinessBasepath = conf.Value.FoodBusinessBasePath;
            _DataBaseFoodBusinessBasepath = FirebaseConfig.FoodBusinessBasePath;

            if (string.IsNullOrEmpty(_DataBaseFoodBusinessBasepath))
            {
                throw new ArgumentNullException("fireBase FoodBusiness Path not found in appsettings");
            }

            //_DataBaseHotelBasepath = conf.Value.HotelBasePath;
            _DataBaseHotelBasepath = FirebaseConfig.HotelBasePath;

            if (string.IsNullOrEmpty(_DataBaseHotelBasepath))
            {
                throw new ArgumentNullException("fireBase Hotel Path not found in appsettings");
            }

            //_DataBaseUserBasepath = conf.Value.UserBasePath;
            _DataBaseUserBasepath = FirebaseConfig.UserBasePath;
            if (string.IsNullOrEmpty(_DataBaseUserBasepath))
            {
                throw new ArgumentNullException("fireBase Client Path not found in appsettings");
            }
            var pathConfigFile = Path.Combine(AppContext.BaseDirectory, "firebase.json");
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", pathConfigFile);
            _db = FirestoreDb.Create("g22project-69454");
        }

        public async Task<T> AddFoodBusinessAsync<T>(string path, T data, CancellationToken cancellationToken)
        {
            try
            {
                DocumentReference doc = _db.Document(_DataBaseFoodBusinessBasepath + "/" + path);
                var objectTosend = getOrderToDictionary(data);
                await doc.SetAsync(objectTosend, null, cancellationToken);
                return data;
            }
            catch (Exception exe)
            {
                throw exe;
            }
             
        }
        
        public async Task<T> AddHotelAsync<T>(string path, T data, CancellationToken cancellationToken)
        {
            try
            {
                DocumentReference doc = _db.Document(_DataBaseHotelBasepath + "/" + path);
                var objectTosend = getOrderToDictionary(data);
                await doc.SetAsync(objectTosend, null, cancellationToken);
                return data;
            }
            catch (Exception exe)
            {
                throw exe;
            }
             
        }

        public async Task<T> AddFoodBusinessCollectionAsync<T>(string path, T data, CancellationToken cancellationToken)
        {
            try
            {
                CollectionReference doc = _db.Collection(_DataBaseFoodBusinessBasepath + "/" + path);
                var objectTosend = getOrderToDictionary(data);
                await doc.AddAsync(objectTosend, cancellationToken);
                return data;
            }
            catch (Exception exe)
            {
                throw exe;
            }

        }

        public async Task<T> AddHotelCollectionAsync<T>(string path, T data, CancellationToken cancellationToken)
        {
            try
            {
                CollectionReference doc = _db.Collection(_DataBaseHotelBasepath + "/" + path);
                var objectTosend = getOrderToDictionary(data);
                await doc.AddAsync(objectTosend, cancellationToken);
                return data;
            }
            catch (Exception exe)
            {
                throw exe;
            }

        }
        public async Task<T> AddUserCollectionAsync<T>(string path, T data, CancellationToken cancellationToken)
        {
            try
            {
                CollectionReference doc = _db.Collection(_DataBaseUserBasepath + "/" + path);
                var objectTosend = getOrderToDictionary(data);
                await doc.AddAsync(objectTosend, cancellationToken);
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
                    if (type == typeof(bool))
                    {
                        return Convert.ToBoolean(valueToConvert) == true ? 1 : 0;
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

        public async Task<T> UpdateFoodBusinessAsync<T>(string path, T data, CancellationToken cancellationToken)
        {
            try
            {
                DocumentReference doc = _db.Document(_DataBaseFoodBusinessBasepath + "/" + path);
                var objectTosend = getOrderToDictionary(data);             
                await doc.UpdateAsync(objectTosend, null, cancellationToken);
                return data;
            }
            catch (Exception exe)
            {
                throw exe;
            }
        }
        public async Task<T> UpdateHotelAsync<T>(string path, T data, CancellationToken cancellationToken)
        {
            try
            {
                DocumentReference doc = _db.Document(_DataBaseHotelBasepath + "/" + path);
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
