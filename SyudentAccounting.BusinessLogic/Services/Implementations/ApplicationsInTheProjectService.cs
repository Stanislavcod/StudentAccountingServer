using StudentAccounting.Model;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class ApplicationsInTheProjectService : IApplicationInTheProjectService
    {
        private readonly ILogger<ApplicationsInTheProjectService> _logger;
        private readonly ApplicationDatabaseContext _context;
        
        public ApplicationsInTheProjectService(ApplicationDatabaseContext context, ILogger<ApplicationsInTheProjectService> logger)
        {
            _logger = logger;
            _context = context;
        }
        
        public void Create(ApplicationsInTheProject applicationsInTheProject)
        {
            try
            {
                if (applicationsInTheProject == null)
                {
                    _logger.LogWarning($"{DateTime.Now}: applicationsInTheProject is null");
                
                    return;
                }
            
                if (_context.ApplicationsInTheProjects.Any(x => x.Id == applicationsInTheProject.Id))
                {
                    _logger.LogWarning($"{DateTime.Now}: applicationsInTheProject haven't any id");
                
                    return;
                }
            
                _context.ApplicationsInTheProjects.Add(applicationsInTheProject);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
            }
        }
        
        public IEnumerable<ApplicationsInTheProject> Get()
        {
            try
            {
                var applicationsInTheProjects = _context.ApplicationsInTheProjects.Include(x => x.Vacancy.StagesOfProject.Project).
                    Include(x => x.Participants).Include(x => x.Participants.Individuals).AsNoTracking().ToList();

                return applicationsInTheProjects;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
                
                return new List<ApplicationsInTheProject>();
            }
        }
        
        public IEnumerable<ApplicationsInTheProject> GetForVacancyId(int vacancyId)
        {
            try
            {
                var applicationsInTheProjects = _context.ApplicationsInTheProjects.Include(x => x.Vacancy.StagesOfProject.Project).Where(x => x.VacancyId == vacancyId).
                    Include(x => x.Participants).Include(x => x.Participants.Individuals).AsNoTracking().ToList();
                
                return applicationsInTheProjects;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
                
                return new List<ApplicationsInTheProject>();
            }
        }
        
        public ApplicationsInTheProject Get(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return new ApplicationsInTheProject();
                }
            
                var application = _context.ApplicationsInTheProjects.Include(x => x.Vacancy.StagesOfProject.Project).
                    Include(x => x.Participants).AsNoTracking().FirstOrDefault(x => x.Id == id);
            
                if (application == null)
                {
                    return new ApplicationsInTheProject();
                }
            
                return application;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");

                return new ApplicationsInTheProject();
            }
        }
        
        public void Edit(ApplicationsInTheProject applicationsInTheProject)
        {
            try
            {
                if (applicationsInTheProject == null)
                {
                    _logger.LogWarning($"{DateTime.Now}: applicationsInTheProject is null");
                
                    return;
                }
            
                if (!_context.ApplicationsInTheProjects.Any(x => x.Id == applicationsInTheProject.Id))
                {
                    _logger.LogWarning($"{DateTime.Now}: applicationsInTheProject haven't any id");
                
                    return;
                }
            
                _context.ApplicationsInTheProjects.Update(applicationsInTheProject);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
            }
        }
        
        public void Delete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return;
                }
            
                var application = _context.ApplicationsInTheProjects.FirstOrDefault(x => x.Id == id);
            
                if (application == null)
                {
                    return;
                }
            
                _context.ApplicationsInTheProjects.Remove(application);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
            }
        }
    }
}

