using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Services.UserAccountService.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
        public int LangId { get; set; } = 1;
    }
}