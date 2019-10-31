using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

[assembly: FunctionsStartup(typeof(TestDIFinOct2019.Startup))]
namespace TestDIFinOct2019
{
    class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {

            var config = new ConfigurationBuilder()
               .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables()
               .Build();
            builder.Services.AddSingleton(config);
            builder.Services.AddHttpClient("PostMessageAPI", x =>
            {
 
                x.BaseAddress = new Uri("https://testpostaccept20191029124137.azurewebsites.net/Weatherforecast");
                x.Timeout = TimeSpan.FromMilliseconds(65536);
            });
            builder.Services.AddSingleton<ParserApiClient>();
            builder.Services.AddLogging();
        }
    }
}
