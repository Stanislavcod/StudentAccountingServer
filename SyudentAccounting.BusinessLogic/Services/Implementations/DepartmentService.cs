using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccounting.BusinessLogic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ILogger<DepartmentService> _logger;
        private readonly ApplicationDatabaseContext _context;
        
        public DepartmentService(ApplicationDatabaseContext context, ILogger<DepartmentService> logger)
        {
            _logger = logger;
            _context = context;
        }
        
        public void Create(Department department)
        {
            try
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
            }
        }

        public IEnumerable<Department> Get()
        {
            try
            {
                var departments = _context.Departments.Include(x => x.Organizations).AsNoTracking().ToList();

                return departments;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");

                return new List<Department>();
            }
        }

        public Department Get(string name)
        {
            try
            {
                var department = _context.Departments.Include(x => x.Organizations).AsNoTracking().FirstOrDefault(x => x.FullName == name);
                
                if (department == null)
                {
                    return new Department();
                }
                
                return department;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");

                return new Department();
            }
        }

        public Department Get(int id)
        {
            try
            {
                var department = _context.Departments.Include(x => x.Organizations).AsNoTracking().FirstOrDefault(x => x.Id == id);

                if (department == null)
                {
                    return new Department();
                }

                return department;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");

                return new Department();
            }
        }

        public void Edit(Department department)
        {
            try
            {
                _context.Departments.Update(department);
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
                var department = _context.Departments.FirstOrDefault(x => x.Id == id);

                if (department == null)
                {
                    return;
                }
                
                _context.Departments.Remove(department);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
            }
        }
    }
}
