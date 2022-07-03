using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using EasyIND.API.IoC;
using EasyIND.Application.IoC;
using EasyIND.Domain.IoC;
using EasyIND.Infrastructure.Contexts.EasyIND;
using EasyIND.Infrastructure.IoC;
using EasyIND.Application.Services;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.


builder.Services.AddApiRegistry();
builder.Services.AddAppRegistry(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddModelRegistry();
builder.Services.AddDomainRegistry();


builder.Services.AddDbContext<EasyINDDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
b => b.MigrationsAssembly("EasyIND.Infrastructure")));

builder.Services.AddControllers(options =>
{
    options.EnableEndpointRouting = false;
}).AddFluentValidation();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAnyOrigin");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
