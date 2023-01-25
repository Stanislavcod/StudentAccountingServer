using AutoMapper;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using StudentAccounting.BusinessLogic.Services.Implementations;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Model;
using System.Text.Json.Serialization;
using System.Text.Json;
using StudentAccounting.Configuration;

//ConfigurationHelper _configurationHelper = new ConfigurationHelper();
//_configurationHelper.ConfigureServices();
//_configurationHelper.Configure();
var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddDbContext<ApplicationDatabaseContext>(options => options.UseSqlServer(connection,
    opt => opt.MigrationsAssembly("StudentAccounting")));

builder.Services.AddControllers(options =>
{
    options.OutputFormatters.RemoveType<SystemTextJsonOutputFormatter>();
    options.OutputFormatters.Add(new SystemTextJsonOutputFormatter(new JsonSerializerOptions(JsonSerializerDefaults.Web)
    {
        ReferenceHandler = ReferenceHandler.Preserve,
    }));
});

builder.Services.AddMvc();


builder.Services.AddTransient<IApplicationInTheProjectService, ApplicationsInTheProjectService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IBonusService, BonusService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IDepartamentService, DepartamentService>();
builder.Services.AddTransient<IEmploymentService, EmploymentService>();
builder.Services.AddTransient<IFinalProjectService, FinalProjectService>();
builder.Services.AddTransient<IIndividualsService, IndividualsService>();
builder.Services.AddTransient<IOrganizationService, OrganizationService>();
builder.Services.AddTransient<IParticipantsService, ParticipantsService>();
builder.Services.AddTransient<IPositionService, PositionService>();
builder.Services.AddTransient<IProjectService, ProjectService>();
builder.Services.AddTransient<IRankService, RankService>();
builder.Services.AddTransient<IRegulationsService, RegulationsService>();
builder.Services.AddTransient<IStagesOfProjectsService, StagesOfProjectsService>();
builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<ITrainingCoursesService, TrainingCoursesService>();
builder.Services.AddTransient<IVacanciesService, VacanciesService>();
builder.Services.AddTransient<IScheduleOf—lassesService, ScheduleOf—lassesService>();
builder.Services.AddTransient<IEducationalPortalsService, EducationalPortalsService>();
builder.Services.AddTransient<IRegistrationForCoursesService, RegistrationForCoursesService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
