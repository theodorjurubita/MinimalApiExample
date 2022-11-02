global using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.OpenApi.Models;
using MinimalApi.Persistence;
using MinimalApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// ConfigureServices

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Minimal API Example",
        Description = "An ASP.NET Core Minimal API Example"
    });
});

builder.Services.AddSingleton<EndpointsDbContext>();
builder.Services.AddSingleton<ICarsRepository, CarsRepository>();
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();

var app = builder.Build();

// Configure

app.Urls.Add("http://localhost:4000");

app.UseFastEndpoints();
app.UseOpenApi();
app.UseSwaggerUi3(options => options.ConfigureDefaults());

var context = app.Services.GetService<EndpointsDbContext>();
context?.Database.EnsureCreated();
context?.SaveChanges();

app.Run();