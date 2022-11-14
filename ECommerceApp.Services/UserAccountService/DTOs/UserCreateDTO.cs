using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Services.UserAccountService.DTOs
{
    public class UserCreateDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Email { get; set; }
        [Required]
        public List<int> RoleIds { get; set; }
    }
}