using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProductTrial.API.Application.Authentication;
using ProductTrial.Application.Interfaces;
using ProductTrial.Application.Services;
using ProductTrial.Application.Services.Authentication;
using ProductTrial.Domain.Interfaces;
using ProductTrial.Infrastructure.Data;
using ProductTrial.Infrastructure.Persistence;
using Scalar.AspNetCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var secretKey = builder.Configuration["Jwt:SecretKey"];
var issuer = builder.Configuration["Jwt:Issuer"];
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = issuer,
            ValidAudience = issuer,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
    {
        policy.Requirements.Add(new EmailRequirement("admin@admin.com"));
    });
});

//builder.Services.AddAuthorization();
builder.Services.AddOpenApi(opts =>
    opts.AddDocumentTransformer<BearerSecuritySchemeTransformer>());

// DI
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<IAuthorizationHandler, EmailRequirementHandler>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IJwtService>(provider =>
{
    return new JwtService(secretKey, issuer);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapScalarApiReference("/docs", options =>
{
    options.WithTheme(ScalarTheme.Mars)
           .WithPreferredScheme("Bearer");
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
