using ECommerceApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Domain.Entities
{
    public class VariationType : BaseEntity
    {
        public string Name { get; set; }
        public int VariationId { get; set; }
        public Variation Variation { get; set; }
    }
}
