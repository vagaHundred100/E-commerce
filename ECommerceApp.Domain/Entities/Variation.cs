using ECommerceApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Domain.Entities
{
    public class Variation : BaseEntity
    {
        public string Name { get; set; }
        public int CategoryTypeId { get; set; }
        public CategoryType CategoryType { get; set; }
        public ICollection<VariationType> VariationTypes { get; set; }
    }
}
