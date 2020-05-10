using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RoomApplication.UI.Common.Client
{
   public interface IRoomApplicationHttpClient
    {
        HttpClient HttpClient { get; }
        Task<T> GetRequest<T>(string actionUrl);
        Task<R> SendRequest<T, R>(string actionUrl, T viewModel);
        Task<R> SendRequest<T, R>(string actionUrl, int viewModel);
    }
}
