using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotnetCore.UnitOfWork.DAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext RepositoryContext;

        public Repository(DbContext dbContext)
        {
            RepositoryContext = dbContext;
        }

        public void Add(TEntity entity)
        {
            RepositoryContext.Set<TEntity>().Add(entity);
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity,bool>> condition)
        {
            return await RepositoryContext.Set<TEntity>().Where(condition).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await RepositoryContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(string id)
        {
            return await RepositoryContext.Set<TEntity>().FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            RepositoryContext.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity)
        {
            RepositoryContext.Set<TEntity>().Update(entity);
        }
    }
}
