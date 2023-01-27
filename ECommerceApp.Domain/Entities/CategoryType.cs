using ECommerceApp.Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECommerceApp.Domain.Entities
{
    public class CategoryType : BaseEntity
    {
        public CategoryType()
        {
            Children = new HashSet<CategoryType>();
        }
        public string Name { get; set; }
        [ForeignKey("ParentId")]
        [JsonIgnore]
        public int? ParentId { get; set; }
        [JsonIgnore] 
        public virtual CategoryType Parent { get; set; }
        public virtual ICollection<CategoryType> Children { get; set; }
        public  ICollection<Variation> Variations { get; set; }
        public  ICollection<Product> Products { get; set; }
    }
}
