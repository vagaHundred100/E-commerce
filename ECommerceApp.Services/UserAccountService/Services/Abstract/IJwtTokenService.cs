using ECommerceApp.Services.UserAccountService.Identity.Abstract;
using ECommerceApp.Shared.SharedRequestResults.Base;
using System.Collections.Generic;

namespace ECommerceApp.Services.UserAccountService.Services.Abstract
{
    public interface IJwtTokenService
    {
        DataResult<string> GenerateJwt(IUserClaimsOptions userModelForTokenGen, IList<string> roles, IJwtOptions jwtSettings);
    }
}