using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentAccounting.BusinessLogic.Implementations;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Common.Mapper;
using StudentAccounting.Model;

var builder = WebApplication.CreateBuilder(args);
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddDbContext<ApplicationDatabaseContext>(options => options.UseSqlServer(connection,
    opt => opt.MigrationsAssembly("StudentAccounting")));

builder.Services.AddControllers();

builder.Services.AddMvc();

var mappingConfig = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

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
builder.Services.AddTransient<IRangService, RangService>();
builder.Services.AddTransient<IRegulationsService, RegulationsService>();
builder.Services.AddTransient<IStagesOfProjectsService, StagesOfProjectsService>();
builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<ITrainingCoursesService, TrainingCoursesService>();
builder.Services.AddTransient<IVacanciesService, VacanciesService>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
