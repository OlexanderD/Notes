using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NoteApp.BusinessLogic.Inrerfaces;
using NoteApp.BusinessLogic.Services;
using NoteApp.ConsoleUI.Common.Validators;
using NoteApp.Data.Data.Models;
using NoteApp.Data.Interfaces;
using NoteApp.Data.Repositories;
using NoteApp.DataAccess.Data;
using NoteApp.DataAccess.Interfaces;
using NoteApp.DataAccess.Repositories.NoteApp.DataAccess.Repositories;
using WebNote.Common.Mappings;
using WebNote.Common.Validators;
using WebNote.Controllers;
using WebNote.Infrastructure.MiddleWare.ErrorHandling;
using WebNote.ViewModels;

var builder = WebApplication.CreateBuilder();


var con = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TestContext>(options => options.UseSqlite(con));
builder.Services.AddScoped<TestContext>();

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
})
.AddEntityFrameworkStores<TestContext>();


builder.Services.AddTransient<INoteRepository, NoteRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddTransient<INoteService, NoteService>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddMemoryCache();

builder.Services.AddTransient<NoteController>();
builder.Services.AddTransient<UserController>();

builder.Services.AddTransient<IValidator<NoteViewModels>, NoteViewModelValidator>();

builder.Services.AddTransient<IValidator<UserViewModel>, UserViewValidator>();







builder.Services.AddLogging();

builder.Services.AddAutoMapper(typeof(NoteMapProfile));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();   

builder.Services.AddSwaggerGen();




var app = builder.Build();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.MapControllers();
 

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
        c.RoutePrefix = string.Empty; 
    });
}

app.Run();
