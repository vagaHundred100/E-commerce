namespace ECommerceApp.Services.UserAccountService.Identity.Abstract
{
    public interface IUserClaimsOptions
    {
        public int Id { get; set; }
        public int AppLangId { get; set; }
        public string UserName { get; set; }
    }
}