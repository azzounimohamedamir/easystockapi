using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net;
using Newtonsoft.Json.Serialization;

namespace SmartRestaurant.Helpers
{
    public class APIHelper
    {
        private string baseUrl;
        public JsonSerializerSettings serializerSettings;
        private APIHelper()
        {

        }
        public APIHelper(string baseUrl)
        {
            this.baseUrl = baseUrl;
            if (serializerSettings == null)
            {
                serializerSettings = new JsonSerializerSettings();
                serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            }
        }

        public async Task<TOut> Post<TOut, TIn>(string url, TIn requestObj)
            where TOut : class
        {

            // Initialization.  
            TOut responseObj = null;
            try
            {
                // Posting.  
                using (var client = new HttpClient())
                {

                    // Initialization.  
                    HttpResponseMessage response = new HttpResponseMessage();

                    // HTTP POST  

                    var json = JsonConvert.SerializeObject(requestObj, serializerSettings);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var uri = new Uri(baseUrl + "/" + url);
                    try
                    {
                        response = await client.PostAsync(uri, content);

                    }
                    catch (Exception ex )
                    {

                        throw ex ;
                    }
                    // Verification  
                    if (response.IsSuccessStatusCode)
                    {
                        // Reading Response.  
                        string result = response.Content.ReadAsStringAsync().Result;
                        responseObj = JsonConvert.DeserializeObject<TOut>(result);

                        // Releasing.  
                        response.Dispose();
                    }
                    else
                    {
                        string result = response.Content.ReadAsStringAsync().Result;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return responseObj;
        }
        public async Task<TOut> Get<TOut>(string url)
         where TOut : class
        {

            // Initialization.  
            TOut responseObj = null;
            try
            {
                // Posting.  
                using (var client = new HttpClient())
                {

                    // Initialization.  
                    HttpResponseMessage response = new HttpResponseMessage();

                    var uri = new Uri(baseUrl + url);

                    // HTTP GET  
                    response = await client.GetAsync(uri);

                    // Verification  
                    if (response.IsSuccessStatusCode)
                    {
                        // Reading Response.  
                        string result = response.Content.ReadAsStringAsync().Result;
                        responseObj = JsonConvert.DeserializeObject<TOut>(result);

                        // Releasing.  
                        response.Dispose();
                    }
                    else
                    {
                        // Reading Response.  
                        string result = response.Content.ReadAsStringAsync().Result;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return responseObj;
        }
        public async Task<TOut> Put<TOut, TIn>(string url, TIn requestObj)
         where TOut : class
        {

            // Initialization.  
            TOut responseObj = null;
            try
            {
                // Posting.  
                using (var client = new HttpClient())
                {

                    // Initialization.  
                    HttpResponseMessage response = new HttpResponseMessage();

                    // HTTP PUT
                    var json = JsonConvert.SerializeObject(requestObj, serializerSettings);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var uri = new Uri(baseUrl + "/" + url);

                    response = await client.PutAsync(uri, content);

                    // Verification  
                    if (response.IsSuccessStatusCode)
                    {
                        // Reading Response.  
                        string result = response.Content.ReadAsStringAsync().Result;
                        responseObj = JsonConvert.DeserializeObject<TOut>(result);

                        // Releasing.  
                        response.Dispose();
                    }
                    else
                    {
                        // Reading Response.  
                        string result = response.Content.ReadAsStringAsync().Result;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return responseObj;
        }
        public async Task<TOut> Delete<TOut>(string url)
        where TOut : class
        {
            // Initialization.  
            TOut responseObj = null;
            try
            {
                // Posting.  
                using (var client = new HttpClient())
                {

                    // Initialization.  
                    HttpResponseMessage response = new HttpResponseMessage();

                    // HTTP DELETE
                    var uri = new Uri(baseUrl + "/" + url);

                    response = await client.DeleteAsync(uri);

                    // Verification  
                    if (response.IsSuccessStatusCode)
                    {
                        // Reading Response.  
                        string result = response.Content.ReadAsStringAsync().Result;
                        responseObj = JsonConvert.DeserializeObject<TOut>(result);

                        // Releasing.  
                        response.Dispose();
                    }
                    else
                    {
                        // Reading Response.  
                        string result = response.Content.ReadAsStringAsync().Result;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return responseObj;
        }

    }
}
