﻿using ECommerceApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Infrastructure.DataBase.EntityFramework.EFContext
{
    public class EFIdentityContext:IdentityDbContext<AppUser, AppRole, int>
    {
    }
}