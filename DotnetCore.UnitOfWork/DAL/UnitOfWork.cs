using DotnetCore.UnitOfWork.Entities;
using System;
using System.Threading.Tasks;

namespace DotnetCore.UnitOfWork.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed = false;

        private IRepository<User> _userRepo; 

        private readonly RepositoryContext _repositoryContext;
        public UnitOfWork(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IRepository<User> Users
        {
            get
            {
                if (_userRepo is null)
                {
                    _userRepo = new UserReposiory(_repositoryContext);
                }
                return _userRepo;
            }
        }

        public async Task Commit()
        {
           await _repositoryContext.SaveChangesAsync();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                _repositoryContext.Dispose();
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
