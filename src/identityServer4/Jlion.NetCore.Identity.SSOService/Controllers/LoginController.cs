using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;


namespace Jlion.NetCore.Identity.SSOService
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        ///// <summary>
        ///// 登陆
        ///// </summary>
        ///// <param name="userName"></param>
        ///// <param name="password"></param>
        //[HttpPost]
        //public async Task<IActionResult> PostLogin(string userName, string password, string returnUrl)
        //{
        //    ViewData["returnUrl"] = returnUrl;
        //    var user = UserProvider.GetByUserNameAndPassoword(userName, password);
        //    if (user != null)
        //    {
        //        AuthenticationProperties props = new AuthenticationProperties
        //        {
        //            IsPersistent = true,
        //            ExpiresUtc = DateTimeOffset.UtcNow.Add(TimeSpan.FromDays(1))
        //        };
        //        await HttpContext.SignInAsync(user.UserId.ToString(),user, props);
        //        if (returnUrl != null)
        //        {
        //            return Redirect(returnUrl);
        //        }

        //        return View();
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
    }
}
