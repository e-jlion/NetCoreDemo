using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jlion.NetCore.Identity.SSOService.Model
{
    public class UserResponse
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { set; get; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { set; get; }

        /// <summary>
        /// 登陆密码
        /// </summary>
        public string Password { set; get; }
    }
}
