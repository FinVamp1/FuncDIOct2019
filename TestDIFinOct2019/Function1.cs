using System;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace TestDIFinOct2019
{

    public class Function1
    {
        private readonly ParserApiClient _apiClient;
        public Function1(ParserApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [FunctionName("Function1")]
        public async void Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            var data = "test=something";
            StringContent queryString = new StringContent(data);
            await _apiClient.PostMessage(queryString);
        }
    }
}
