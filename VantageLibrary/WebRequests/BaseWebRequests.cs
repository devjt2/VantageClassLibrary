using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VantageLibrary.Types;
using VantageLibrary.Utilities;

namespace VantageLibrary.WebRequests
{
    public class BaseWebRequests : IDisposable
    {
        private readonly HttpClient _httpClient;
        public BaseWebRequests(Uri baseAddress)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

        //GET
        public string VantageRestGet(string uriAppend)
        {
            using HttpResponseMessage response = _httpClient.GetAsync(uriAppend).Result;

            return response.Content.ReadAsStringAsync().Result;
        }

        // POST

        /// <summary>
        /// Posts some data to Vantage API.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uriAppend"></param>
        /// <param name="data"></param>
        /// <param name="options"></param>
        /// <returns>string</returns>
        /// <exception cref="Exception"></exception>
        public string VantageRestPostAsync<T>(string uriAppend, T data)
        {
            try
            {
                string jsonPayload = Serialization.Serialize(data);

                HttpContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                using HttpResponseMessage response = _httpClient.PostAsync(uriAppend, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    throw new Exception("Vantage Post Request Failed.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// This is used to send a no payload and expects no string response from the server.
        /// </summary>
        /// <param name="uriAppend"></param>
        /// <returns>bool</returns>
        public bool VantageRestPostAsync(string uriAppend)
        {
            HttpContent? content = null;
            using HttpResponseMessage response = _httpClient.PostAsync(uriAppend, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // DELETE
        /// <summary>
        /// A generic method to send a DELETE request to Vantage.
        /// </summary>
        /// <param name="uriAppend"></param>
        /// <returns>bool</returns>
        /// <exception cref="Exception"></exception>
        public bool VantageRestDelete(string uriAppend)
        {
            try
            {
                using HttpResponseMessage response = _httpClient.DeleteAsync(uriAppend).Result;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Vantage Delete Request Failed: " + ex.Message);
            }
        }

        public string VantageRestPut<T>(string uriAppend, T data)
        {
            string jsonPayload;
            if (data == null)
            {
                throw new Exception("Input data cannot be null");
            }
            else
            {
                jsonPayload = Serialization.Serialize(data);

            }

            HttpContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            try
            {
                using HttpResponseMessage response = _httpClient.PutAsync(uriAppend, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    throw new Exception("Put Request to Vantage Failed");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Put Request to Vantage Failed: " + ex.Message);
            }
        }

        /// <summary>
        /// This method receives a request to PUT data of type T. For which the return will be of type T. This only supports 'string' or 'bool' input types.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uriAppend"></param>
        /// <returns>T</returns>
        /// <exception cref="Exception"></exception>
        public T VantageRestPut<T>(string uriAppend) where T : IConvertible
        {
            Type typeName = typeof(T);
            try
            {
                using HttpResponseMessage response = _httpClient.PutAsync(uriAppend, null).Result;
                if (response.IsSuccessStatusCode)
                {
                    if (typeName == typeof(string))
                    {
                        return (T)(object)response.Content.ReadAsStringAsync().Result;
                    }
                    else if (typeName == typeof(bool))
                    {
                        //In the case that vantage is emitting a 'true' or 'false' value it is wrapped in a Json containing one parameter followed by the boolean value.
                        //Converting that one Json Parameter into a generic key value pair for easy boolean value extraction.
                        Dictionary<string, bool> keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, bool>>(response.Content.ReadAsStringAsync().Result);
                        return (T)(object)keyValuePairs.Values;
                    }
                    else
                    {
                        throw new Exception("Input type not supported.");
                    }
                }
                else
                {
                    throw new Exception("Put Request to Vantage Failed");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Put Request to Vantage Failed: " + ex.Message);
            }
        }

        // Clean up
        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}