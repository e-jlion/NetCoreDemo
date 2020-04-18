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

        //[HttpGet("list")]
        //public async Task<string> GetBaiduListAsync(string url)
        //{
        //    for (var i = 1; i < 10; i++)
        //    {
        //        using (var client = new System.Net.Http.HttpClient())
        //        {
        //            var result = await client.GetStringAsync(url);
        //            //return result;
        //        }
        //    }
        //    return "ok";
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<string> GetBaiduAsync(string url)
        {
            var client = _clientFactory.CreateClient();
            var result =await client.GetStringAsync(url);
            return result;
        }
    }
}
