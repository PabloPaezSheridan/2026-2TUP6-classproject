using Application.Services;
using Domain.Interfaces;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

#region Dependency Injection

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
// builder.Services.AddScoped<PopulationCalculation>();
#endregion

builder.Services.AddDbContext<StudentsForumContext>(dbContextOptions => dbContextOptions.UseSqlServer("Server=127.0.0.1;Database=StudentsForum;User Id=sa;Password=LocalPassword1;Encrypt=true;TrustServerCertificate=true;"));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers(); 
app.Run();