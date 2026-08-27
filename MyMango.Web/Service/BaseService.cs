using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using MyMango.Web.Models;
using MyMango.Web.Service.IService;
using static MyMango.Web.Utility.SD;

namespace MyMango.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _clientFactory;

        public BaseService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<ResponseDto?> SendAsync(RequestDto requestDto)
        {
            var client = _clientFactory.CreateClient("MyMangoAPI");

            // Build request message
            var httpMethod = new HttpMethod(requestDto.ApiType.ToString());
            var message = new HttpRequestMessage(httpMethod, requestDto.Url);

            if (requestDto.Data != null)
            {
                var content = JsonSerializer.Serialize(requestDto.Data);
                message.Content = new StringContent(content, Encoding.UTF8, "application/json");
            }

            if (!string.IsNullOrEmpty(requestDto.AccessToken))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", requestDto.AccessToken);
            }

            var response = await client.SendAsync(message);
            var apiContent = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(apiContent))
                return null;

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var result = JsonSerializer.Deserialize<ResponseDto>(apiContent, options);
            return result;
        }
    }
}
