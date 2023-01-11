namespace ECommerceApp.Services.UserAccountService.DTOs
{
    public class UserChangePasswordDTO
    {
        public int UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string RepeatedNewPassword { get; set; }
    }
}