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

namespace VantageLibrary {
    public class BaseWebRequests : IDisposable
    {
        private readonly HttpClient _httpClient;
        public BaseWebRequests(Uri baseAddress) {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

        //GET
        public string VantageRestGet(string uriAppend)
        {
            using HttpResponseMessage response = _httpClient.GetAsync(uriAppend).Result;

            return response.Content.ReadAsStringAsync().Result;
        }

        //PUT
        public void VantageRestPut()
        {

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

                string jsonPayload = Serialization.Serialize<T>(data);

                

                HttpContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
                
                using HttpResponseMessage response = _httpClient.PostAsync(uriAppend, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    throw new Exception("Vantage Job Submit Failed");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // DELETE
        public void VantageRestDelete()
        {

        }

        // Clean up
        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
