using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Jlion.NetCore.HttpClient.DemoService.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class FirstController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public FirstController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet("test")]
        public async Task<string> GetBaiduListAsync(string url)
        {
            var html = "";
            for (var i = 0; i < 10; i++)
            {
                using (var client = new System.Net.Http.HttpClient())
                {
                   var result=await client.GetStringAsync(url);
                    html += result;
                }
            }
            return html;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<string> GetBaiduAsync(string url)
        {
            var client = _clientFactory.CreateClient("test");
            var result = await client.GetStringAsync(url);
            return result;
        }
    }
}
