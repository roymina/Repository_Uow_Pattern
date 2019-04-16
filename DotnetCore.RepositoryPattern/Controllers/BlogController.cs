using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetCore.RepositoryPattern.DataAccess;
using DotnetCore.RepositoryPattern.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotnetCore.RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : Controller
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public BlogController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;

        }
        [Route("~/api/GetBlogs")]
        [HttpGet]
        public async Task<IEnumerable<Blog>> Index()
        {
            return await _repositoryWrapper.Blog.GetAllAsyn();
        }

        [Route("~/api/AddBlog")]
        [HttpPost]
        public async Task<Blog> AddBlog([FromBody]Blog blog)
        {
            await _repositoryWrapper.Blog.AddAsyn(blog);
            await _repositoryWrapper.Blog.SaveAsync();
            return blog;
        }

        [Route("~/api/UpdateBlog")]
        [HttpPut]
        //public Blog UpdateBlog([FromBody] Blog blog)  
        //{  
        //  var updated = _repositoryWrapper.Blog.Update(blog, blog.BlogId);  
        //  return updated;  
        //}  
        public async Task<Blog> UpdateBlog([FromBody]Blog blog)
        {
            var updated = await _repositoryWrapper.Blog.UpdateAsyn(blog, blog.BlogId);
            return updated;
        }

        [Route("~/api/DeleteBlog/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            _repositoryWrapper.Blog.Delete(_repositoryWrapper.Blog.Get(id));
            return "Employee deleted successfully!";
        }

        protected override void Dispose(bool disposing)
        {
            _repositoryWrapper.Blog.Dispose();
            base.Dispose(disposing);
        }

    }
}
