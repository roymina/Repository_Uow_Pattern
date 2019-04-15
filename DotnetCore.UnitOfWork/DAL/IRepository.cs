using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotnetCore.UnitOfWork.DAL
{
    public interface IRepository<TEntity> where TEntity:class
    {
        /*
        * Are there DBSet.UpdateAsync() and RemoveAsync() in .net core?
        * ref:https://stackoverflow.com/questions/42034282/are-there-dbset-updateasync-and-removeasync-in-net-core
        * call SaveChangesAsync() if want a async operation when add|update|remove
        */
        void Add(TEntity entity);
        void Remove(TEntity entity); 
        void Update(TEntity entity);

        Task<TEntity> GetById(string id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity,bool>> condition);


    }
}
