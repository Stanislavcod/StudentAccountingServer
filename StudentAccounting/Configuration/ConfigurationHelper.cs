using Microsoft.AspNetCore.HttpOverrides;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.BusinessLogic.Services.Implementations;
using StudentAccounting.Model;

namespace StudentAccounting.Configuration
{
    public static class ConfigurationHelper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services
                .AddTransient<IApplicationInTheProjectService, ApplicationsInTheProjectService>()
                .AddTransient<IUserService, UserService>()
                .AddTransient<IBonusService, BonusService>()
                .AddTransient<ICustomerService, CustomerService>()
                .AddTransient<IDepartamentService, DepartamentService>()
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
                .AddEndpointsApiExplorer()
                .AddSwaggerGen()
                .AddMvc()
                .AddControllersAsServices();
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
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
