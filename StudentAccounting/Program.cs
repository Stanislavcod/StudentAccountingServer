using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using StudentAccounting.Model;
using System.Text.Json.Serialization;
using System.Text.Json;
using StudentAccounting.Configuration;


var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSystemd();

ConfigurationHelper.ConfigureServices(builder.Services);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDatabaseContext>(options => options.UseSqlServer(connection,
    opt => opt.MigrationsAssembly("StudentAccounting")));

var app = builder.Build();

ConfigurationHelper.Configure(app);

app.Run();
