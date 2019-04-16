using DotnetCore.RepositoryPattern.Controllers;
using DotnetCore.RepositoryPattern.DataAccess;
using DotnetCore.RepositoryPattern.Entities;
using RepositoryPattern.Tests.Infrustructure;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RepositoryPattern.Tests.RepositoryPattern2Tests.ControllerTests
{
    public class BlogControllerTests : TestBase
    { 
        [Fact]
        public async void AddBlogTest()
        {
            var controller = new BlogController(RepositoryWrapper);
            var result = await controller.AddBlog(new Blog { Title = "asdasd" });
            Assert.Equal(1, RepositoryWrapper.Blog.Count());
        }

    }
}
