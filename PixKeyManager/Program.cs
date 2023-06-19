using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PixKeyManager.Data.Context;
using PixKeyManager.Data.Repository;
using PixKeyManager.Domain.Builder;
using PixKeyManager.Filters;
using PixKeyManager.UseCase.Auth;
using PixKeyManager.UseCase.Keys;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PixKeyContext>(
    options => options.UseNpgsql(
        builder.Configuration.GetConnectionString("PixKeyDb")));

// DI - Repositories
builder.Services.AddScoped<IKeyRepository, KeyRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// DI - Builders
builder.Services.AddSingleton<IKeyBuilder, KeyBuilder>();

// DI - UseCases
builder.Services.AddScoped<IRegisterKeyUseCase, RegisterKeyUseCase>();
builder.Services.AddScoped<IListKeysByAccountUseCase, ListKeysByAccountUseCase>();
builder.Services.AddScoped<IRemoveKeyUseCase, RemoveKeyUseCase>();

builder.Services.AddScoped<IAuthUseCase, AuthUseCase>();

// Exception Filter
builder.Services.AddMvcCore(
    options => options.Filters.Add<PixExceptionFilter>());

// Logging
builder.Logging
    .ClearProviders()
    .AddConsole();

// Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],

        IssuerSigningKey = new SymmetricSecurityKey (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),

        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,

        ValidateIssuerSigningKey = true
    };
});
builder.Services.AddAuthorization();

var app = builder.Build();

// Database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PixKeyContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.MapControllers();

app.Run();
