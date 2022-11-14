using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using ECommerceApp.Services.UserAccountService.Services.Abstract;
using System.Collections.Generic;
using ECommerceApp.Services.UserAccountService.Identity.Abstract;
using ECommerceApp.Shared.SharedRequestResults.Base;
using System;
using ECommerceApp.Services.UserAccountService.Identity.Constants;
using System.Linq;

namespace ECommerceApp.Services.UserAccountService.Services.Concrete
{
    public class JwtTokenService : IJwtTokenService
    {
        public DataResult<string> GenerateJwt(IUserClaimsOptions user, IList<string> roles, IJwtOptions jwtSettings)
        {
            List<Claim> claims = new List<Claim>
                                            {
                                                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                                                new Claim(ClaimTypes.Name, user.UserName),
                                                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                                                new Claim(QmsClaimTypes.UserAppLangId, user.AppLangId.ToString())
                                            };

            IEnumerable<Claim> roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r));
            claims.AddRange(roleClaims);

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            DateTime accessTokenExpiration = DateTime.Now.AddYears(Convert.ToInt32(jwtSettings.ExpirationInYears));

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: jwtSettings.Issuer,
                audience: jwtSettings.Audience,
                claims: claims,
                expires: accessTokenExpiration,
                signingCredentials: creds
            );
            return new DataResult<string>(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}