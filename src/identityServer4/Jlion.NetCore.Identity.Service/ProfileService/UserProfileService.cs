using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jlion.NetCore.Identity.UserApiService
{
    public class UserProfileService : IProfileService
    {
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            try
            {
                //depending on the scope accessing the user data.
                var claims = context.Subject.Claims.ToList();

                //set issued claims to return
                context.IssuedClaims = claims.ToList();
            }
            catch { }
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
        }
    }
}
