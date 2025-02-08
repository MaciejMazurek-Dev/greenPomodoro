using greenPomodoro.BlazorUI.Models;
using System.Net.Http.Json;

namespace greenPomodoro.BlazorUI.Services.BaseHttpClient
{
    public class BaseHttpService
    {
        private protected IClient _client;
        public BaseHttpService(IClient client)
        {
            _client = client;
        }
    }
}
