using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestDIFinOct2019
{
    public class ParserApiClient
    {

        public readonly IHttpClientFactory _httpClientFactory;
        public ParserApiClient(IHttpClientFactory httpClientFactory)
        {

            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));

        }
        public async Task<HttpResponseMessage> PostMessage(HttpContent content)

        {
            var httpClient = _httpClientFactory.CreateClient("PostMessageAPI");
            return await httpClient.PostAsync("", content);

        }
    }
}