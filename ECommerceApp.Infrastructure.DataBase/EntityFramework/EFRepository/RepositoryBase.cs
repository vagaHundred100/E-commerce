using ECommerceApp.Domain.Common;
using ECommerceApp.Domain.Enums;
using ECommerceApp.Domain.Repository;
using ECommerceApp.Infrastructure.DataBase.EntityFramework.EFContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ECommerceApp.Infrastructure.DataBase.EntityFramework.EFRepository
{
    //https://www.learnentityframeworkcore5.com/relationship-in-ef-core
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        protected readonly EFIdentityContext repositoryContextBase;
        public RepositoryBase(EFIdentityContext applicationIdentityContext)
        {
            repositoryContextBase = applicationIdentityContext;
        }

       

        #region Synchronous methods
        public TEntity FindById(int Id)
        {
            TEntity entity;
            entity = repositoryContextBase.Set<TEntity>().SingleOrDefault(x => x.Id == Id);
            return entity;
        }
        public IQueryable<TEntity> FindAllActive()
        {
            IQueryable<TEntity> entities;
            entities = repositoryContextBase.Set<TEntity>().Where(x => x.Status == EntityStatus.Active);
            return entities;
        }
        public IQueryable<TEntity> FindAll()
        {
            IQueryable<TEntity> entities;
            entities = repositoryContextBase.Set<TEntity>();
            return entities;
        }
        public IQueryable<TEntity> FindAllActiveAsNoTracking()
        {
            IQueryable<TEntity> entities;
            entities = repositoryContextBase.Set<TEntity>().Where(x => x.Status == EntityStatus.Active).AsNoTracking();
            return entities;
        }
        public IQueryable<TEntity> FindAllAsNoTracking()
        {
            IQueryable<TEntity> entities;
            entities = repositoryContextBase.Set<TEntity>().AsNoTracking();
            return entities;
        }
        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression)
        {
            IQueryable<TEntity> entities;
            entities = repositoryContextBase.Set<TEntity>().Where(expression);
            return entities;
        }
        public IQueryable<TEntity> FindByConditionAsNoTracking(Expression<Func<TEntity, bool>> expression)
        {
            IQueryable<TEntity> entities;
            entities = repositoryContextBase.Set<TEntity>().Where(expression).AsNoTracking();
            return entities;
        }
        public TEntity FindByConditionFirstOrDefaultAsNoTracking(Expression<Func<TEntity, bool>> expression)
        {
            TEntity entity;
            entity = repositoryContextBase.Set<TEntity>().Where(expression).AsNoTracking().FirstOrDefault();
            return entity;
        }
        public void Create(TEntity entity)
        {
            repositoryContextBase.Set<TEntity>().Add(entity);
            repositoryContextBase.SaveChanges();
        }
        public int CreateWithReturnId(TEntity entity)
        {
            repositoryContextBase.Set<TEntity>().Add(entity);
            repositoryContextBase.SaveChanges();
            return entity.Id;
        }
        public void CreateRange(List<TEntity> entites)
        {
            repositoryContextBase.Set<TEntity>().AddRange(entites);
            repositoryContextBase.SaveChanges();
        }
        public void Update(TEntity entity)
        {
            repositoryContextBase.Set<TEntity>().Update(entity);
            repositoryContextBase.SaveChanges();
        }
        public void UpdateRange(List<TEntity> entity)
        {
            repositoryContextBase.Set<TEntity>().UpdateRange(entity);
            repositoryContextBase.SaveChanges();
        }
        public void Deactivate(TEntity entity)
        {
            entity.Status = EntityStatus.Inactive;
            repositoryContextBase.Set<TEntity>().Update(entity);
            repositoryContextBase.SaveChanges();
        }
        public void Delete(TEntity entity)
        {
            if (entity != null)
            {
                repositoryContextBase.Remove(entity);
                repositoryContextBase.SaveChanges();
            }
        }
        public void DeleteRange(IList<TEntity> entity)
        {
            if (entity.Count > 0)
            {
                repositoryContextBase.RemoveRange(entity);
                repositoryContextBase.SaveChanges();
            }
        }
        #endregion

        #region Asynchronous methods
        public async Task<TEntity> FindByIdAsync(int Id)
        {
            TEntity entity;
            entity = await repositoryContextBase.Set<TEntity>().SingleOrDefaultAsync(x => x.Id == Id);
            return entity;
        }
        public async Task<List<TEntity>> FindAllActiveAsync()
        {
            List<TEntity> entities;
            entities = await repositoryContextBase.Set<TEntity>().Where(x => x.Status == EntityStatus.Active).ToListAsync();
            return entities;
        }
        public async Task<List<TEntity>> FindAllAsync()
        {
            List<TEntity> entities;
            entities = await repositoryContextBase.Set<TEntity>().ToListAsync();
            return entities;
        }
        public async Task<List<TEntity>> FindAllActiveAsNoTrackingAsync()
        {
            IQueryable<TEntity> entities;
            entities = repositoryContextBase.Set<TEntity>().Where(x => x.Status == EntityStatus.Active).AsNoTracking();
            return await entities.ToListAsync();
        }
        public async Task<List<TEntity>> FindAllAsNoTrackingAsync()
        {
            IQueryable<TEntity> entities;
            entities = repositoryContextBase.Set<TEntity>().AsNoTracking();
            return await entities.ToListAsync();
        }
        public async Task<List<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> expression)
        {
            List<TEntity> entities;
            entities = await repositoryContextBase.Set<TEntity>().Where(expression).ToListAsync();
            return entities;
        }
        public async Task<TEntity> FindByConditionFirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
        {
            TEntity entitiy;
            entitiy = await repositoryContextBase.Set<TEntity>().Where(expression).FirstOrDefaultAsync();
            return entitiy;
        }
        public async Task CreateAsync(TEntity entity)
        {
            await repositoryContextBase.Set<TEntity>().AddAsync(entity);
            await repositoryContextBase.SaveChangesAsync();
        }
        public async Task CreateRangeAsync(List<TEntity> entites)
        {
            await repositoryContextBase.Set<TEntity>().AddRangeAsync(entites);
            await repositoryContextBase.SaveChangesAsync();
        }
        #endregion
    }
}