using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.Logging;

[assembly: FunctionsStartup(typeof(TestDIFinOct2019.Startup))]
namespace TestDIFinOct2019
{
    class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddHttpClient("PostMessageAPI", x =>
            {
 
                x.BaseAddress = new Uri("http://requestbin.net/r/1lowbys1");
                x.Timeout = TimeSpan.FromMilliseconds(65536);
            });
            builder.Services.AddSingleton<ParserApiClient>();
            builder.Services.AddLogging();
        }
    }
}
