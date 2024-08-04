using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NM.Studio.Domain.Configs.Mapping;
using NM.Studio.Domain.Contracts.Repositories.Users;
using NM.Studio.Domain.Contracts.Services.Users;
using NM.Studio.Domain.Contracts.UnitOfWorks;
using NM.Studio.Data.Context;
using NM.Studio.Data.Repositories.Users;
using NM.Studio.Data.UnitOfWorks;
using System.Text;
using System.Text.Json.Serialization;
using NM.Studio.Domain.Contracts.Repositories.Photos;
using NM.Studio.Domain.Contracts.Repositories.Services;
using NM.Studio.Domain.Contracts.Services.Services;
using NM.Studio.Domain.Contracts.Services.Photos;
using System.Reflection;
using NM.Studio.Handler;
using NM.Studio.Services;
using NM.Studio.Data.Repositories.Photos;
using NM.Studio.Data.Repositories.Services;
using NM.Studio.Domain.Contracts.Repositories.Outfits;
using NM.Studio.Data.Repositories.Outfits;
using NM.Studio.Domain.Contracts.Services.Outfits;
using NM.Studio.Domain.Middleware;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
#region Add-DbContext
builder.Services.AddDbContext<StudioContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
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
                },
            },
            new string[]{}
        }
    });
});
builder.Services.AddHttpContextAccessor(); 
builder.Services.AddAutoMapper(typeof(MappingProfile));

#region Add-MediaR

//After 12.0.0
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
////Before 12.0.0
var handler = typeof(AppHandler).GetTypeInfo().Assembly;
builder.Services.AddMediatR(Assembly.GetExecutingAssembly(), handler);

#endregion

#region Add-Scoped
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOutfitRepository, OutfitRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IPhotoRepository, PhotoRepository>();

#endregion

#region Add-Transient
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IOutfitService, OutfitService>();

builder.Services.AddTransient<IServiceService, ServiceService>();

builder.Services.AddTransient<IPhotoService, PhotoService>();

#endregion

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
