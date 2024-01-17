using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteApp.DataAccess.Data.Models;
using NoteApp.DataAccess.Data.Models.Configurations;
using System.Reflection;
using Microsoft.Extensions.Logging;
using NoteApp.Data.Data.Models;

namespace NoteApp.DataAccess.Data
{
    public class TestContext:DbContext
    {
        public DbSet<Note> Notes { get; set; }

        public DbSet<User> Users { get; set; }


        public TestContext() => Database.EnsureCreated();

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
