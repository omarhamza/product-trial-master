using Microsoft.EntityFrameworkCore;
using ProductTrial.Application.Interfaces;
using ProductTrial.Application.Services;
using ProductTrial.Domain.Interfaces;
using ProductTrial.Infrastructure.Data;
using ProductTrial.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// DI
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IJwtService>(provider =>
{
    var secretKey = builder.Configuration["Jwt:SecretKey"];
    var issuer = builder.Configuration["Jwt:Issuer"];
    return new JwtService(secretKey, issuer);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
