using ECommerceApp.Domain.Entities;
using ECommerceApp.Domain.Repository;
using ECommerceApp.Infrastructure.DataBase.EntityFramework.EFContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Infrastructure.DataBase.EntityFramework.EFRepository
{
    public class VariationRepository : RepositoryBase<Variation>, IVariationRepository
    {
        public VariationRepository(EFIdentityContext applicationIdentityContext) : base(applicationIdentityContext)
        {
        }
    }
}
