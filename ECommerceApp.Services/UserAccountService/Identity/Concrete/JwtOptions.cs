using ECommerceApp.Services.UserAccountService.Identity.Abstract;

namespace ECommerceApp.Services.UserAccountService.Identity.Concrete
{
    public class JwtOptions : IJwtOptions
    {
        public string Issuer { get; set; } // издатель токена
        public string Audience { get; set; } // потребитель токена
        public string SecretKey { get; set; }
        public int ExpirationInYears { get; set; }
    }
}
