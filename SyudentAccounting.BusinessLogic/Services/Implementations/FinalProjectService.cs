using StudentAccounting.Model;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class FinalProjectService : IFinalProjectService
    {
        private readonly ILogger<FinalProjectService> _logger;
        private readonly ApplicationDatabaseContext _context;
        
        public FinalProjectService(ApplicationDatabaseContext context, ILogger<FinalProjectService> logger)
        {
            _logger = logger;
            _context = context;
        }
        
        public void Create(FinalProject finalProject)
        {
            try
            {
                _context.FinalProjects.Add(finalProject);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
            }
        }
        
        public IEnumerable<FinalProject> Get()
        {
            try
            {
                var finalProjects = _context.FinalProjects.Include(x => x.Employment).
                    AsNoTracking().ToList();

                return finalProjects;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");

                return new List<FinalProject>();
            }
        }
        
        public IEnumerable<FinalProject> GetForEmployment(int id)
        {
            try
            {
                var finalProjects = _context.FinalProjects.Include(x => x.Employment).
                    AsNoTracking().Where(x => x.EmploymentId == id);

                return finalProjects;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");

                return new List<FinalProject>();
            }
        }
        
        public FinalProject Get(string name)
        {
            try
            {
                var finalProject = _context.FinalProjects.Include(x => x.Employment).
                    AsNoTracking().FirstOrDefault(x => x.Name == name);

                if (finalProject == null)
                {
                    return new FinalProject();
                }

                return finalProject;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");

                return new FinalProject();
            }
        }
        
        public FinalProject Get(int id)
        {
            try
            {
                var finalProject = _context.FinalProjects.AsNoTracking().FirstOrDefault(x => x.Id == id);

                if (finalProject == null)
                {
                    return new FinalProject();
                }

                return finalProject;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");

                return new FinalProject();
            }
        }
        
        public void Edit(FinalProject finalProject)
        {
            try
            {
                _context.FinalProjects.Update(finalProject);
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
                var finalProject = _context.FinalProjects.FirstOrDefault(x => x.Id == id);

                if (finalProject != null)
                {
                    _context.FinalProjects.Remove(finalProject);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
