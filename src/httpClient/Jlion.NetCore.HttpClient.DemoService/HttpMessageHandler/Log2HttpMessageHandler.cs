using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Jlion.NetCore.HttpClient.DemoService
{
    public class Log2HttpMessageHandler : DelegatingHandler
    {
        private IServiceProvider _provider;

        public Log2HttpMessageHandler(IServiceProvider provider)
        {
            _provider = provider;
            //InnerHandler = new HttpClientHandler();
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            System.Console.WriteLine("LogHttpMessageHandler2 Start Log");
            var response=await base.SendAsync(request, cancellationToken);
            System.Console.WriteLine("LogHttpMessageHandler2 End Log");

            return response;
        }
    }
}
