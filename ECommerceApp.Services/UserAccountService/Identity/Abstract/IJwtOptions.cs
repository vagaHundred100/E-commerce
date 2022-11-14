namespace ECommerceApp.Services.UserAccountService.Identity.Abstract
{
    public interface IJwtOptions
    {
        public string Issuer { get; set; } // издатель токена
        public string Audience { get; set; } // потребитель токена
        public string SecretKey { get; set; }
        public int ExpirationInYears { get; set; }

    }
}