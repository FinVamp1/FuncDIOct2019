using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace TestDIFinOct2019
{

    public class Function1
    {
        private readonly ParserApiClient _apiClient;
        private readonly ILogger log;
        private readonly IConfiguration _configuration;
        public Function1(IConfiguration configuration, ILoggerFactory loggerFactory, ParserApiClient apiClient)
        {
            this._configuration = configuration;
            log = loggerFactory.CreateLogger(LogCategories.CreateFunctionCategory("common"));
            _apiClient = apiClient;
        }

        [FunctionName("Function1")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get","post", Route = null)] HttpRequest req)
        {
            log.LogInformation($"C# HTTP trigger function executed at: {DateTime.Now}");
            var data = "test=something";
            StringContent queryString = new StringContent(data);         
            await _apiClient.PostMessage(queryString);

            return (ActionResult) new OkObjectResult($"Thanks for sending your request");
        }
    }
}
