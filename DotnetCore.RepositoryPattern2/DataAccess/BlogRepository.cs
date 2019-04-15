using DotnetCore.RepositoryPattern2.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCore.RepositoryPattern2.DataAccess
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        public BlogRepository(DbContext dbContext) : base(dbContext) { }
        public Blog GetByTitle(string blogTitle)
        {
            return GetAll().FirstOrDefault(x => x.Title == blogTitle);
        }
        /*
        add override methods
         */
        public async Task<Blog> GetSingleAsyn(int blogId)
        {
            return await _context.Set<Blog>().FindAsync(blogId);
        }

        public override Blog Update(Blog t, object key)
        {
            Blog exist = _context.Set<Blog>().Find(key);
            if (exist != null)
            {
                t.CreatedBy = exist.CreatedBy;
                t.CreatedOn = exist.CreatedOn;
            }
            return base.Update(t, key);
        }

        public async override Task<Blog> UpdateAsyn(Blog t, object key)
        {
            Blog exist = await _context.Set<Blog>().FindAsync(key);
            if (exist != null)
            {
                t.CreatedBy = exist.CreatedBy;
                t.CreatedOn = exist.CreatedOn;
            }
            return await base.UpdateAsyn(t, key);
        }
    }
}
