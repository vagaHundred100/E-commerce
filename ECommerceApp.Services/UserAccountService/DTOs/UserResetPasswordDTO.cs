namespace ECommerceApp.Services.UserAccountService.DTOs
{
    public class UserResetPasswordDTO
    {
        public int UserId { get; set; }
        public string NewPassword { get; set; }
        public string RepeatedNewPassword { get; set; }
    }
}