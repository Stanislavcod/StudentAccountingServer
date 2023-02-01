using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using StudentAccounting.Configuration;


var builder = WebApplication.CreateBuilder(args);
var configure = builder.Configuration;

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
               AddJwtBearer(options => options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
               {
                   ValidateIssuerSigningKey = true,
                   ValidateIssuer = false,
                   IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:TokenKey"])),
                   ValidateAudience = false
               });

ConfigurationHelper.ConfigureServices(builder.Services, configure);

var app = builder.Build();

ConfigurationHelper.Configure(app);

app.Run();
