using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetCore.RepositoryPattern2.DataAccess;
using DotnetCore.RepositoryPattern2.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotnetCore.RepositoryPattern2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : Controller
    {
        private readonly IBlogRepository _blogRepository;

        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;

        }
        [Route("~/api/GetBlogs")]
        [HttpGet]
        public async Task<IEnumerable<Blog>> Index()
        {
            return await _blogRepository.GetAllAsyn();
        }

        [Route("~/api/AddBlog")]
        [HttpPost]
        public async Task<Blog> AddBlog([FromBody]Blog blog)
        {
            await _blogRepository.AddAsyn(blog);
            await _blogRepository.SaveAsync();
            return blog;
        }

        [Route("~/api/UpdateBlog")]
        [HttpPut]
        //public Blog UpdateBlog([FromBody] Blog blog)  
        //{  
        //  var updated = _blogRepository.Update(blog, blog.BlogId);  
        //  return updated;  
        //}  
        public async Task<Blog> UpdateBlog([FromBody]Blog blog)
        {
            var updated = await _blogRepository.UpdateAsyn(blog, blog.BlogId);
            return updated;
        }

        [Route("~/api/DeleteBlog/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            _blogRepository.Delete(_blogRepository.Get(id));
            return "Employee deleted successfully!";
        }

        protected override void Dispose(bool disposing)
        {
            _blogRepository.Dispose();
            base.Dispose(disposing);
        }

    }
}
