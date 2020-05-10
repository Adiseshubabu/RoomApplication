using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Common.Client
{
   public interface IRoomHttpClient
    {
        HttpClient HttpClient { get; }
        Task<T> GetRequest<T>(string actionUrl);
        Task<R> SendRequest<T, R>(string actionUrl, T viewModel);
        Task<R> SendRequest<T, R>(string actionUrl, int viewModel);
    }
}
