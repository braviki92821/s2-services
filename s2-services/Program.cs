using Amazon.Runtime;
using Amazon.Util.Internal.PlatformServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver.Core.Operations;
using s2_services.Models;
using s2_services.repository;
using s2_services.Services;
using s2_services.Services.conexiones;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
TimeSpan ClockSkew;
// Add services to the container.

builder.Services.AddControllers();
builder.Services.Configure<S2Connection>(builder.Configuration.GetSection("S2Settings"));
builder.Services.Configure<S3SConnection>(builder.Configuration.GetSection("S3SSettings"));
builder.Services.Configure<S3PConnection>(builder.Configuration.GetSection("S3PSettings"));
builder.Services.Configure<AuthConnection>(builder.Configuration.GetSection("Auth20"));
builder.Services.Configure<Jwt>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddSingleton<spicService>();
builder.Services.AddSingleton<ssancionadosService>();
builder.Services.AddSingleton<psancionadosService>();
builder.Services.AddSingleton<userService>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"])),
        ClockSkew=TimeSpan.Zero
    };

    options.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
            {
                context.Response.Headers.Add("IS-TOKEN-EXPIRED", "true");
            }
            return Task.CompletedTask;
        }
    };
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
