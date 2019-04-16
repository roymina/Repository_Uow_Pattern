using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using DotnetCore.RepositoryPattern.Entities;
using Microsoft.EntityFrameworkCore;
using DotnetCore.RepositoryPattern.DataAccess;
using RepositoryPattern.Tests.Infrustructure;

namespace RepositoryPattern.Tests.RepositoryPattern2Tests
{
    public class NonQueryTests:TestBase
    { 
        [Fact]
        public void CreateBlog_Save_Blog_Via_Context()
        {
            //var mockset = new Mock<DbSet<Blog>>();
            //var mockContext = new Mock<DataContext>();
            //mockContext.Setup(m => m.Blogs).Returns(mockset.Object);

            //var repository = new BlogRepository(mockContext.Object);
            //repository.Add(new Blog { Title = "test bolg" });

            //mockset.Verify(m => m.Add(It.IsAny<Blog>()), Times.Once);
            //mockContext.Verify(m => m.SaveChanges(), Times.Once);

             

            //var blogRepo = new BlogRepository(Context);

            Seed(); 
            Assert.Equal(6, RepositoryWrapper.Blog.Count());
            
        }

        private void Seed()
        {
            var blogs = new[]
            {
                new Blog{Title = "blog1"},
                 new Blog{Title = "blog2"},
                  new Blog{Title = "blog3"},
                   new Blog{Title = "blog4"},
                    new Blog{Title = "blog5"},
                     new Blog{Title = "blog6"},
            };

            foreach (var item in blogs)
            {
                RepositoryWrapper.Blog.Add(item);
                RepositoryWrapper.Blog.Save();
            }
        }
    }
}
