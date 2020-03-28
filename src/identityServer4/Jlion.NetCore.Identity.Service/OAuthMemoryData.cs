using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Jlion.NetCore.Identity.Constants;
using Jlion.NetCore.Identity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace Jlion.NetCore.Identity.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class OAuthMemoryData
    {
        /// <summary>
        /// 资源
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource(
                    OAuthConfig.UserApi.ApiName,
                    OAuthConfig.UserApi.ApiName,
                    new List<string>(){JwtClaimTypes.Role }
                    ),
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client()
                {
                    ClientId =OAuthConfig.UserApi.ClientId,
                    AllowedGrantTypes = new List<string>()
                    {
                        GrantTypes.ResourceOwnerPassword.FirstOrDefault(),//Resource Owner Password模式
                        GrantTypeConstants.ResourceWeixinOpen,
                    },
                    ClientSecrets = {new Secret(OAuthConfig.UserApi.Secret.Sha256()) },
                    AllowOfflineAccess = true,//如果要获取refresh_tokens ,必须把AllowOfflineAccess设置为true
                    AllowedScopes= {
                        OAuthConfig.UserApi.ApiName,
                        StandardScopes.OfflineAccess,
                    },
                    AccessTokenLifetime = OAuthConfig.ExpireIn,
                },

            };
        }

        /// <summary>
        /// 测试的账号和密码
        /// </summary>
        /// <returns></returns>
        public static List<TestUser> GetTestUsers()
        {
            return new List<TestUser>
            {
                new TestUser()
                {
                     SubjectId = "1",
                     Username = "test",
                     Password = "123456"
                },
            };
        }

        /// <summary>
        /// 为了演示，硬编码了，
        /// 这个方法可以通过DDD设计到底层数据库去查询数据库
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static UserModel GetUserByUserName(string userName)
        {
            var normalUser = new UserModel()
            {
                DisplayName = "张三",
                MerchantId = 10001,
                Password = "123456",
                Role = Enums.EnumUserRole.Normal,
                SubjectId = "1",
                UserId = 20001,
                UserName = "testNormal"
            };
            var manageUser = new UserModel()
            {
                DisplayName = "李四",
                MerchantId = 10001,
                Password = "123456",
                Role = Enums.EnumUserRole.Manage,
                SubjectId = "1",
                UserId = 20001,
                UserName = "testManage"
            };
            var supperManageUser = new UserModel()
            {
                DisplayName = "dotNET博士",
                MerchantId = 10001,
                Password = "123456",
                Role = Enums.EnumUserRole.SupperManage,
                SubjectId = "1",
                UserId = 20001,
                UserName = "testSupperManage"
            };
            var list = new List<UserModel>() {
                normalUser,
                manageUser,
                supperManageUser
            };
            return list?.Where(item => item.UserName.Equals(userName))?.FirstOrDefault();
        }

        /// <summary>
        /// 微信openId 的测试用户
        /// </summary>
        /// <returns></returns>
        public static List<TestUser> GetWeiXinOpenIdTestUsers()
        {
            return new List<TestUser>
            {
                new TestUser(){
                  SubjectId="owerhwroogs3902openId",
                }
            };
        }
    }
}
