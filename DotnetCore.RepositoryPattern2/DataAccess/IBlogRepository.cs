using DotnetCore.RepositoryPattern2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCore.RepositoryPattern2.DataAccess
{
    public interface IBlogRepository : IRepository<Blog>
    {
        // If you need to customize your entity actions you can put here    
        Blog GetByTitle(string  blogTitle);
    }
}
