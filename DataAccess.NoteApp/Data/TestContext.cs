using Microsoft.EntityFrameworkCore;
using NoteApp.DataAccess.Data.Models;
using System.Reflection;
using NoteApp.Data.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace NoteApp.DataAccess.Data
{
    public class TestContext: IdentityDbContext<User>
    { 
        public virtual DbSet<Note> Notes { get; set; }

        public TestContext()
        {

        }

        public TestContext(DbContextOptions<TestContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);

        }

    }
}
