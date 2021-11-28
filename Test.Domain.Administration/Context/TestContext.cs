using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using Test.Domain.Administration.Entities;

namespace Test.Domain.Administration.Context
{
    public class TestContext : DbContext
    {

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enroll> Enrolls { get; set; }
        public DbSet<Address> Address { get; set; }

        public TestContext(DbContextOptions<TestContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasKey(e => new { e.Id });
        }


        public void RefreshAll()
        {
            foreach (var entity in ChangeTracker.Entries())
            {
                entity.Reload();
            }
        }

        public void DetachedAll()
        {
            foreach (var _entity in ChangeTracker.Entries())
            {
                _entity.State = EntityState.Detached;
            }
        }


    }


    public class ApplicationContextDbFactory : IDesignTimeDbContextFactory<TestContext>
    {
        TestContext IDesignTimeDbContextFactory<TestContext>.CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<TestContext>();
            var connectionString = configuration.GetConnectionString("Database");
            builder.UseSqlServer(connectionString);
            return new TestContext(builder.Options);
        }
    }




}
