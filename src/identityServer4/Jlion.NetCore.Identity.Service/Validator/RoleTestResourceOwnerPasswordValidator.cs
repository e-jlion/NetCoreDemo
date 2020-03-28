using IdentityModel;
using IdentityServer4.Validation;
using Jlion.NetCore.Identity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Jlion.NetCore.Identity.Service.Validator
{
    /// <summary>
    /// 角色授权用户名密码验证器demo
    /// </summary>
    public class RoleTestResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            try
            {
                var userName = context.UserName;
                var password = context.Password;

                //验证用户,这么可以到数据库里面验证用户名和密码是否正确
                var claimList = await ValidateUserByRoleAsync(userName, password);

                // 验证账号
                context.Result = new GrantValidationResult
                (
                    subject: userName,
                    authenticationMethod: "custom",
                    claims: claimList.ToArray()
                );
            }
            catch (Exception ex)
            {
                //验证异常结果
                context.Result = new GrantValidationResult()
                {
                    IsError = true,
                    Error = ex.Message
                };
            }
        }

        #region Private Method

        /// <summary>
        /// 验证用户(角色Demo 专用方法)
        /// 这里和之前区分，主要是为了保留和博客同步源代码
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private async Task<List<Claim>> ValidateUserByRoleAsync(string loginName, string password)
        {
            //TODO 这里可以通过用户名和密码到数据库中去验证是否存在，
            // 以及角色相关信息，我这里还是使用内存中已经存在的用户和密码
            var user = OAuthMemoryData.GetUserByUserName(loginName);

            if (user == null)
                throw new Exception("登录失败，用户名和密码不正确");

            //下面的Claim 声明我为了演示，硬编码了，
            //实际生产环境需要通过读取数据库的信息并且来声明

            return new List<Claim>()
            {

                new Claim(ClaimTypes.Name, $"{user.UserName}"),
                new Claim(EnumUserClaim.DisplayName.ToString(),user.DisplayName),
                new Claim(EnumUserClaim.UserId.ToString(),user.UserId.ToString()),
                new Claim(EnumUserClaim.MerchantId.ToString(),user.MerchantId.ToString()),
                new Claim(JwtClaimTypes.Role.ToString(),user.Role.ToString())
            };
        }
        #endregion
    }
}
