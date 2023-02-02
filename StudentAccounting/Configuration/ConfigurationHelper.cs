using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc.Formatters;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.BusinessLogic.Services.Implementations;
using System.Text.Json.Serialization;
using System.Text.Json;
using AutoMapper;
using StudentAccounting.Common.Helpers.Mapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StudentAccounting.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace StudentAccounting.Configuration
{
    public static class ConfigurationHelper
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDatabaseContext>(options => options.UseSqlServer(connection,
                opt => opt.MigrationsAssembly("StudentAccounting")));
            var mappingConfig = new MapperConfiguration(x => x.AddProfile(new MapperProfile()));
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddMvc();
            services
                .AddTransient<ITokenService, TokenService>()
                .AddTransient<IAuthService, AuthService>()
                .AddTransient<IApplicationInTheProjectService, ApplicationsInTheProjectService>()
                .AddTransient<IUserService, UserService>()
                .AddTransient<IBonusService, BonusService>()
                .AddTransient<ICustomerService, CustomerService>()
                .AddTransient<IDepartmentService, DepartmentService>()
                .AddTransient<IEmploymentService, EmploymentService>()
                .AddTransient<IFinalProjectService, FinalProjectService>()
                .AddTransient<IIndividualsService, IndividualsService>()
                .AddTransient<IOrganizationService, OrganizationService>()
                .AddTransient<IParticipantsService, ParticipantsService>()
                .AddTransient<IPositionService, PositionService>()
                .AddTransient<IProjectService, ProjectService>()
                .AddTransient<IRankService, RankService>()
                .AddTransient<IRegulationsService, RegulationsService>()
                .AddTransient<IStagesOfProjectsService, StagesOfProjectsService>()
                .AddTransient<IStudentService, StudentService>()
                .AddTransient<ITrainingCoursesService, TrainingCoursesService>()
                .AddTransient<IVacanciesService, VacanciesService>()
                .AddTransient<IEducationalPortalsService, EducationalPortalsService>()
                .AddTransient<IRegistrationForCoursesService, RegistrationForCoursesService>()
                .AddTransient<IScheduleOfСlassesService, ScheduleOfСlassesService>()
                .AddEndpointsApiExplorer()
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "My Api",
                        Version = "v1"
                    });
                    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                    {
                        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                        Description = "Please insert JWT with Bearer into field",
                        Name = "Authorization",
                        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
                    });
                    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
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
                            new string[] {}
                        }
                    });
                })
                .AddControllers(options =>
                {
                    options.OutputFormatters.RemoveType<SystemTextJsonOutputFormatter>();
                    options.OutputFormatters.Add(new SystemTextJsonOutputFormatter(new JsonSerializerOptions(JsonSerializerDefaults.Web)
                    {
                        ReferenceHandler = ReferenceHandler.Preserve,
                    }));
                });
    

        }
        public static void Configure(WebApplication app)
        {
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
                //app.UseHttpsRedirection();
            }

            //app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }

}
