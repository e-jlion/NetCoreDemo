using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Jlion.NetCore.HttpClient.DemoService.Handler
{
    public class PrimaryHttpMessageHandler: DelegatingHandler
    {
        private IServiceProvider _provider;

        public PrimaryHttpMessageHandler(IServiceProvider provider)
        {
            _provider = provider;
            InnerHandler = new HttpClientHandler();
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            System.Console.WriteLine("PrimaryHttpMessageHandler Start Log");

            var response= await base.SendAsync(request, cancellationToken);
            System.Console.WriteLine("PrimaryHttpMessageHandler End Log");
            return response;
        }
    }
}
