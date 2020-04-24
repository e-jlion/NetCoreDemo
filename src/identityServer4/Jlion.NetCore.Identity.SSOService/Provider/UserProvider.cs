using Jlion.NetCore.Identity.SSOService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jlion.NetCore.Identity.SSOService
{
    /// <summary>
    /// 用户处理Provider
    /// </summary>
    public class UserProvider
    {
        public static UserResponse GetByUserNameAndPassoword(string userName, string password)
        {
            var list = GetUserList();
            return list.Where(item => item.UserName.Equals(userName) && item.Password.Equals(password))?.FirstOrDefault();
        }

        public static List<UserResponse> GetUserList()
        {
            return new List<UserResponse>() {
                new UserResponse(){
                    UserId=10001,
                    UserName="admin",
                    Password="123456"
                },
            };
        }
    }
}
