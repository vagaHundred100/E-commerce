using ECommerceApp.Domain.Entities;
using ECommerceApp.Domain.Repository;
using ECommerceApp.Infrastructure.DataBase.EntityFramework.EFContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Infrastructure.DataBase.EntityFramework.EFRepository
{
    public class EFCategoryTypeRepository : ICategoryTypeRepository
    {
        protected readonly EFIdentityContext _contex;

        public EFCategoryTypeRepository(EFIdentityContext context)
        {
            _contex = context;
        }

        public IQueryable<CategoryType> GetAllCategories()
        {
            return _contex.CategoryTypes
                .Where(c => c.ParentId == null)
                .Include(c => c.Children);
        }

        public IQueryable<CategoryType> GetAllSubCategories(int parentId)
        {
            throw new NotImplementedException();
        }

        public CategoryType Get(int id)
        {
            return _contex.CategoryTypes
               .Include(c => c.Children)
               .Where(c => c.Id == id)
               .Single();
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }

        public void AddRoot(CategoryType category)
        {
            _contex.CategoryTypes.Add(category);
            _contex.SaveChanges();
        }

        public void AddChild(CategoryType category)
        {
            var parent = Get((int)category.ParentId );

            parent.Children.Add(category);
            _contex.SaveChanges();
        }

    }
}
