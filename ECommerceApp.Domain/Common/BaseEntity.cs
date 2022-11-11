using ECommerceApp.Domain.Enums;
using System;

namespace ECommerceApp.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public EntityStatus Status { get; set; } = EntityStatus.Active;
    }
}