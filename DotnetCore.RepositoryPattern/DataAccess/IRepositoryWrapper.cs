using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCore.RepositoryPattern.DataAccess
{
    public interface IRepositoryWrapper
    {
        IBlogRepository Blog { get; } 
    }
}
