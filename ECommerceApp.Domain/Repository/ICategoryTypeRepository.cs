using ECommerceApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Domain.Repository
{
    public interface ICategoryTypeRepository
    {
        void AddRoot(CategoryType category);
        void AddChild(CategoryType category);
        void Remove();
        CategoryType Get(int id);
        IQueryable<CategoryType> GetAllCategories();
        IQueryable<CategoryType> GetAllSubCategories(int parentId);

    }
}
