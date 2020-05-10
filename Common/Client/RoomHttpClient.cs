using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Common.Client
{
   public class RoomHttpClient: IRoomHttpClient
    {
        private HttpClient _httpClient;

        public HttpClient HttpClient
        {
            get
            {
                return _httpClient;
            }
        }

        public RoomHttpClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["ServiceURL"].ToString());
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> GetRequest<T>(string actionUrl)
        {
            T result = default(T);
            HttpResponseMessage response = await HttpClient.GetAsync(actionUrl);

            if (response.IsSuccessStatusCode)
                result = response.Content.ReadAsAsync<T>().Result;
            else
                throw new Exception(response.Content.ReadAsStringAsync().Result);

            return result;
        }
        public async Task<R> SendRequest<T, R>(string actionUrl, T viewModel)
        {
            R result = default(R);

            HttpResponseMessage response = await HttpClient.PostAsJsonAsync(actionUrl, viewModel);

            if (response.IsSuccessStatusCode)
                result = response.Content.ReadAsAsync<R>().Result;
            else
                throw new Exception(response.Content.ReadAsStringAsync().Result);

            return result;
        }
        public async Task<R> SendRequest<T, R>(string actionUrl, int viewModel)
        {
            R result = default(R);

            HttpResponseMessage response = await HttpClient.PostAsJsonAsync(actionUrl, viewModel);

            if (response.IsSuccessStatusCode)
                result = response.Content.ReadAsAsync<R>().Result;
            else
                throw new Exception(response.Content.ReadAsStringAsync().Result);

            return result;
        }

    }
}
