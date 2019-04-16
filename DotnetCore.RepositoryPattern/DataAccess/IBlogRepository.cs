using DotnetCore.RepositoryPattern.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCore.RepositoryPattern.DataAccess
{
    public interface IBlogRepository : IRepository<Blog>
    {     
        Blog GetByTitle(string  blogTitle);
    }
}
