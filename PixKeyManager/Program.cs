using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PixKeyManager.Data.Context;
using PixKeyManager.Data.Repository;
using PixKeyManager.Domain.Builder;
using PixKeyManager.Domain.Validators;
using PixKeyManager.Filters;
using PixKeyManager.UseCase.Account;
using PixKeyManager.UseCase.Auth;
using PixKeyManager.UseCase.Keys;
using PixKeyManager.Utils.Jwt;

var builder = WebApplication.CreateBuilder(args);

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
        
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),

        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,

        ValidateIssuerSigningKey = true
    };
});
builder.Services.AddAuthorization();

// Controllers
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
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

// DI - Builders
builder.Services.AddSingleton<IKeyBuilder, KeyBuilder>();
builder.Services.AddSingleton<IAccountBuilder, AccountBuilder>();

// DI - UseCases
builder.Services.AddScoped<IRegisterKeyUseCase, RegisterKeyUseCase>();
builder.Services.AddScoped<IListKeysByAccountUseCase, ListKeysByAccountUseCase>();
builder.Services.AddScoped<IRemoveKeyUseCase, RemoveKeyUseCase>();
builder.Services.AddScoped<IMigrateKeyUseCase, MigrateKeyUseCase>();
builder.Services.AddScoped<IAuthUseCase, AuthUseCase>();
builder.Services.AddScoped<IRegisterAccountUseCase, RegisterAccountUseCase>();

// DI - Validators
builder.Services.AddSingleton<IKeyOwnershipValidator, KeyOwnershipValidator>();

// DI - Utils
builder.Services.AddSingleton<IJwtTokenUtils, JwtTokenUtils>();

// Exception Filter
builder.Services.AddMvcCore(
    options => options.Filters.Add<PixExceptionFilter>());

// Logging
builder.Logging
    .ClearProviders()
    .AddConsole();

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
app.UseAuthorization();

app.MapControllers();

app.Run();
