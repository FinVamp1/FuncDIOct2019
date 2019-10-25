using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
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
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req, ILogger log)
        {
            log.LogInformation($"C# HTTP trigger function executed at: {DateTime.Now}");
            var data = "test=something";
            StringContent queryString = new StringContent(data);         
            await _apiClient.PostMessage(queryString);

            return (ActionResult) new OkObjectResult($"Thanks for sending your request");
        }
    }
}
