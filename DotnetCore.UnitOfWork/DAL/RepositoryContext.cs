using DotnetCore.UnitOfWork.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotnetCore.UnitOfWork.DAL
{
    public class RepositoryContext:DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=UOW.Test;Integrated Security=True");
        }
    }
}
