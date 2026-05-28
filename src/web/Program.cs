using Application.Services;
using Domain.Interfaces;
using Infrastructure;
using Infrastructure.ExternalHandlers;
using Infrastructure.HttpResiliencePolicies;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using static Infrastructure.HttpResiliencePolicies.httpPollyPolices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

#region Dependency Injection
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITheOneAPIHandler, TheOneAPIHandler>();
builder.Services.AddScoped<TheOneAPIService>();
// builder.Services.AddScoped<PopulationCalculation>();
#endregion

builder.Services.AddDbContext<StudentsForumContext>(dbContextOptions => dbContextOptions.UseSqlServer("Server=127.0.0.1;Database=StudentsForum;User Id=sa;Password=LocalPassword1;Encrypt=true;TrustServerCertificate=true;"));


ApiClientConfigurationDTO theOneAPIConfig = new ApiClientConfigurationDTO()
{
    RetryCount = 2,
    RetryAttemptInSeconds = 5,
    HandledEventsAllowedBeforeBreaking = 40,
    DurationOfBreakInSeconds = 300
};

builder.Services.AddHttpClient("theoneapi", client => {
    client.BaseAddress = new Uri("https://the-one-api.dev/v2/");
    client.Timeout = new TimeSpan(0,0,20);
    })
    .AddPolicyHandler(PollyResiliencePolicies.GetRetryPolicy(theOneAPIConfig))
    .AddPolicyHandler(PollyResiliencePolicies.GetCircuitBreakerPolicy(theOneAPIConfig));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers(); 
app.Run();