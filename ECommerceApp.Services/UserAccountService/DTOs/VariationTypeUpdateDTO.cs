using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Services.UserAccountService.DTOs
{
    public class VariationTypeUpdateDTO
    {
        public string Name { get; set; }
        public int Id { get; internal set; }
    }
}
