using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jlion.NetCore.Identity.UserApiService.Extension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Jlion.NetCore.Identity.UserApiService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        [HttpGet]
        public async Task<object> Get()
        {
            var userId = User.UserId();
            return new
            {
                name = User.Name(),
                userId = userId,
                displayName = User.DisplayName(),
                merchantId = User.MerchantId(),
            };
        }
    }
}
