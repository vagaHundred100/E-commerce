using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECommerceApp.Services.UserAccountService.DTOs
{
    public class CategoryPostDTO
    {
        public CategoryPostDTO()
        {
            ParentId = -1;

        }

        [Required(ErrorMessage = "Name is requared")]
        public string Name { get; set; }
        public int ParentId { get; set; }
    }
}
