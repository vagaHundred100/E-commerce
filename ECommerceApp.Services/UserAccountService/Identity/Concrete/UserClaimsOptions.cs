using ECommerceApp.Services.UserAccountService.Identity.Abstract;

namespace ECommerceApp.Services.UserAccountService.Identity.Concrete
{
    public class UserClaimsOptions : IUserClaimsOptions
    {
        public int Id { get; set; }
        public int AppLangId { get; set; }
        public string UserName { get; set; }
    }
}