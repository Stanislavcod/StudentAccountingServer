using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc.Formatters;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.BusinessLogic.Services.Implementations;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using StudentAccounting.Utilities;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace StudentAccounting.Configuration
{
    public static class ConfigurationHelper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services
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
                .AddSwaggerGen()
                .AddControllers(options =>
                {
                    options.OutputFormatters.RemoveType<SystemTextJsonOutputFormatter>();
                    options.OutputFormatters.Add(new SystemTextJsonOutputFormatter(new JsonSerializerOptions(JsonSerializerDefaults.Web)
                    {
                        ReferenceHandler = ReferenceHandler.Preserve,
                    }));
                });
            services.AddAuthorization();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuer = true,
                    ValidIssuer = AuthOptions.ISSUER,
                    ValidateAudience = true,
                    ValidAudience = AuthOptions.AUDIENCE,
                    ValidateLifetime = true,
                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                    ValidateIssuerSigningKey = true,
                };
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
                app.UseHttpsRedirection();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }

}
