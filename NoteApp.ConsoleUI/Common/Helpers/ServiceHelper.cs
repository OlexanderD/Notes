using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NoteApp.BusinessLogic.Inrerfaces;
using NoteApp.BusinessLogic.Services;
using NoteApp.ConsoleUI.Controllers;
using NoteApp.Data.Interfaces;
using NoteApp.Data.Repositories;
using NoteApp.DataAccess.Data;
using NoteApp.DataAccess.Interfaces;
using NoteApp.DataAccess.Repositories.NoteApp.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.ConsoleUI.Common.Helpers
{
    internal class ServiceHelper
    {
        public static IServiceProvider BuildServiceProvider(IConfiguration config)
        {

            IServiceCollection service = new ServiceCollection();

            var connectionString = config.GetConnectionString("DefaultConnection");

            service.AddDbContext<TestContext>(options => options.UseSqlite(connectionString));
            service.AddScoped<TestContext>();

            service.AddTransient<INoteRepository, NoteRepository>();
            service.AddTransient<IUserRepository, UserRepository>();

            service.AddTransient<INoteService, NoteService>();
            service.AddTransient<IUserService, UserService>();

            service.AddTransient<NoteController>();
            service.AddTransient<UserController>();


            
            return service.BuildServiceProvider();
        }
    }
}
