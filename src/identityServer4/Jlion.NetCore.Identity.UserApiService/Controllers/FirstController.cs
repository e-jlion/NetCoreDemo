using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Jlion.NetCore.Identity.UserApiService.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    [ApiController]
    public class FirstController : ControllerBase
    {

        private readonly ILogger<FirstController> _logger;

        public FirstController(ILogger<FirstController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "test";
        }
    }
}