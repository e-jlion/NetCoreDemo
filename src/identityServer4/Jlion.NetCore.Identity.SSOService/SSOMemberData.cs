using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jlion.NetCore.Identity.SSOService
{
    public class SSOMemberData
    {
        #region 身份资源(用于SSO Demo)
        /// <summary>
        /// 添加身份资源
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }
        #endregion

        #region 定义客户端
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                #region SSO Demo Client
                new Client
                {
                    ClientId = "mvc",
                    ClientName = "MVC Client",
                    AllowedGrantTypes = GrantTypes.Implicit,//隐式方式
                    RequireConsent=false,//如果不需要显示否同意授权 页面 这里就设置为false
                    RedirectUris = { "http://localhost:5002/signin-oidc" },//登录成功后返回的客户端地址（走配置）
                    PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },//注销登录后返回的客户端地址（走配置）

                    //添加身份资源的 Scope
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                }
                #endregion
            };
        }
        #endregion
    }
}
