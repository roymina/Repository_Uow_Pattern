using DotnetCore.RepositoryPattern.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryPattern.Tests.Infrustructure
{
    public  class TestBase  : IDisposable   
    {
        protected readonly DataContext Context;
        protected IRepositoryWrapper RepositoryWrapper;
        public TestBase()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            Context = new DataContext(options);
            RepositoryWrapper = new RepositoryWrapper(Context);
            Context.Database.EnsureCreated();
           
        }


        public void Dispose()
        {
            Context.Database.EnsureDeleted();
            Context.Dispose();

        }
    }
}
