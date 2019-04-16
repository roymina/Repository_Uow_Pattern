using DotnetCore.RepositoryPattern.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace DotnetCore.RepositoryPattern.DataAccess
{
    public class DataContext : DbContext
    { 
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Post>()
            //    .HasOne(b => b.Blog)
            //    .WithMany(p => p.Posts)
            //    .IsRequired();
            base.OnModelCreating(builder);
        }

        public virtual void Save()
        {
            base.SaveChanges();
        }
        /// <summary>
        /// get current windows user
        /// </summary>
        public string UserProvider
        {
            get
            {
                if (!string.IsNullOrEmpty(WindowsIdentity.GetCurrent().Name))
                    return WindowsIdentity.GetCurrent().Name.Split('\\')[1];
                return string.Empty;
            }
        }

        public Func<DateTime> TimestampProvider { get; set; } = ()
            => DateTime.UtcNow;
        public override int SaveChanges()
        {
            TrackChanges();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            TrackChanges();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void TrackChanges()
        {
            foreach (var entry in this.ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                if (entry.Entity is IAuditable)
                {
                    var auditable = entry.Entity as IAuditable;
                    if (entry.State == EntityState.Added)
                    {
                        auditable.CreatedBy = UserProvider;//  
                        auditable.CreatedOn = TimestampProvider();
                        auditable.UpdatedOn = TimestampProvider();
                    }
                    else
                    {
                        auditable.UpdatedBy = UserProvider;
                        auditable.UpdatedOn = TimestampProvider();
                    }
                }
            }
        }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
    }
}
