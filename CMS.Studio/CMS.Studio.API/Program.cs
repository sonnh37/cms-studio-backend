using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using CMS.Studio.API.Registrations;
using CMS.Studio.Data.Context;
using CMS.Studio.Domain.Configs.Mapping;
using CMS.Studio.Domain.Middleware;
using CMS.Studio.Handler;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MediatR;
using Microsoft.Extensions.Logging;
var builder = WebApplication.CreateBuilder(args);

#region Add-DbContext

builder.Services.AddDbContext<StudioContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

#endregion

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(typeof(MappingProfile));

#region Add-MediaR

//After 12.0.0
//builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(typeof(AppHandler).GetTypeInfo().Assembly));

builder.Services.AddApplication();
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


// var handler = typeof(AppHandler).GetTypeInfo().Assembly;
// builder.Services.AddMediatR(Assembly.GetExecutingAssembly(), handler);

#endregion

builder.Services.AddCustomRepositories();
builder.Services.AddCustomServices();

#region Config-Authentication_Authorization

builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = true;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration.GetValue<string>("Appsettings:Token"))),
            ClockSkew = TimeSpan.Zero
        };
        options.Configuration = new OpenIdConnectConfiguration();
    });

builder.Services.AddAuthorization();

#endregion

#region Add-Cors

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

#endregion

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// -----------------app-------------------------

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<TokenUserMiddleware>();
app.UseRouting();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();