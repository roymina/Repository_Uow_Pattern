using DotnetCore.UnitOfWork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCore.UnitOfWork.DAL
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<User> Users { get; }
        Task Commit();
    }
}
