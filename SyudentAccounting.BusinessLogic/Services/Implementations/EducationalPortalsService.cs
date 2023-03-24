using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Model;
using StudentAccounting.Model.DatabaseModels;
using StudentAccounting.Model.FilterModels;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class EducationalPortalsService : IEducationalPortalsService
    {
        private readonly ApplicationDatabaseContext _context;
        private readonly ILogger<EducationalPortalsService> _logger;

        public EducationalPortalsService(ApplicationDatabaseContext context, ILogger<EducationalPortalsService> logger)
        {
            _logger = logger;
            _context = context;
        }
        
        public void Create(EducationalPortals educationalPortal)
        {
            try
            {
                _context.EducationalPortals.Add(educationalPortal);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
            }
        }
        
        public IEnumerable<EducationalPortals> Get()
        {
            try
            {
                var educationalPortals = _context.EducationalPortals.Include(x => x.Department).AsNoTracking().ToList();
                
                return educationalPortals;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");

                return new List<EducationalPortals>();
            }
        }
        
        public EducationalPortals Get(string name)
        {
            try
            {
                var educationalPortals = _context.EducationalPortals.Include(x => x.Department).AsNoTracking().FirstOrDefault(x => x.Name == name);

                if (educationalPortals == null)
                {
                    return new EducationalPortals();
                }
                
                return educationalPortals;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");

                return new EducationalPortals();
            }
        }
        
        public EducationalPortals Get(int id)
        {
            try
            {
                var educationalPortals = _context.EducationalPortals.Include(x => x.Department).AsNoTracking().FirstOrDefault(x => x.Id == id);
                
                if (educationalPortals == null)
                {
                    return new EducationalPortals();
                }
                
                return educationalPortals;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");

                return new EducationalPortals();
            }
        }
        
        public void Edit(EducationalPortals educationalPortals)
        {
            try
            {
                _context.EducationalPortals.Update(educationalPortals);
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
                var educationPortal = _context.EducationalPortals.FirstOrDefault(x => x.Id == id);

                if (educationPortal != null)
                {
                    _context.EducationalPortals.Remove(educationPortal);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
            }
        }
        public IEnumerable<EducationalPortals> GetFiltredEducationalPortals(EducationalPortalsFilter filter)
        {
            var quary = _context.EducationalPortals.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Name))
            {
                quary = quary.Where(edp => edp.Name.ToLower().Contains(filter.Name));
            }
            if (!string.IsNullOrEmpty(filter.Department))
            {
                quary = quary.Where(edp => edp.Department.FullName.ToLower().Contains(filter.Department));
            }

            var educationalPortals = quary.ToList();

            return educationalPortals;
        }
    }
}
