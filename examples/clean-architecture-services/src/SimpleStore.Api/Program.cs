using SimpleStore.Application.Abstractions;
using SimpleStore.Application.Services;
using SimpleStore.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Service-based application flow (no CQRS handlers).
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddSingleton<IProductRepository, InMemoryProductRepository>();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
