using ECommerceApp.Domain.Entities;
using ECommerceApp.Domain.Repository;
using ECommerceApp.Infrastructure.DataBase.EntityFramework.EFContext;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Infrastructure.DataBase.EntityFramework.EFRepository
{
    public class VariationTypeRepository : RepositoryBase<VariationType>, IVariationTypeRepository
    {
        public VariationTypeRepository(EFIdentityContext applicationIdentityContext) : base(applicationIdentityContext)
        {
        }
    }
}
