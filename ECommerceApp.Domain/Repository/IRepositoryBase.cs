using ECommerceApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ECommerceApp.Domain.Repository
{
    public interface IRepositoryBase<T> where T : BaseEntity
    {
        #region Synchronous methods
        T FindById(int Id);
        IQueryable<T> FindAllActive();
        IQueryable<T> FindAll();
        IQueryable<T> FindAllActiveAsNoTracking();
        IQueryable<T> FindAllAsNoTracking();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        IQueryable<T> FindByConditionAsNoTracking(Expression<Func<T, bool>> expression);
        T FindByConditionFirstOrDefaultAsNoTracking(Expression<Func<T, bool>> expression);
        void Create(T entity);
        int CreateWithReturnId(T entity);
        void CreateRange(List<T> entites);
        void Update(T entity);
        void UpdateRange(List<T> entity);
        void Deactivate(T entity);
        void Delete(T entity);
        void DeleteRange(IList<T> entity);
        #endregion

        #region Asynchronous methods
        Task<T> FindByIdAsync(int Id);
        Task<List<T>> FindAllActiveAsync();
        Task<List<T>> FindAllAsync();
        Task<List<T>> FindAllActiveAsNoTrackingAsync();
        Task<List<T>> FindAllAsNoTrackingAsync();
        Task<List<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);
        Task<T> FindByConditionFirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        Task CreateAsync(T entity);
        Task CreateRangeAsync(List<T> entites);
        #endregion
    }
}