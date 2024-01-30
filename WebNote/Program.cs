using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NoteApp.BusinessLogic.Inrerfaces;
using NoteApp.BusinessLogic.Services;
using NoteApp.Data.Interfaces;
using NoteApp.Data.Repositories;
using NoteApp.DataAccess.Data;
using NoteApp.DataAccess.Interfaces;
using NoteApp.DataAccess.Repositories.NoteApp.DataAccess.Repositories;
using WebNote.Common.Mappings;
using WebNote.Controllers;
using WebNote.Infrastructure.MiddleWare.ErrorHandling;

var builder = WebApplication.CreateBuilder();


var con = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TestContext>(options => options.UseSqlite(con));
builder.Services.AddScoped<TestContext>();

builder.Services.AddTransient<INoteRepository, NoteRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddTransient<INoteService, NoteService>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddTransient<NoteController>();
builder.Services.AddTransient<UserController>();






builder.Services.AddLogging();

builder.Services.AddAutoMapper(typeof(NoteMapProfile));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();   

builder.Services.AddSwaggerGen();




var app = builder.Build();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.MapControllers();
 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
