using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccounting.BusinessLogic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudentAccounting.Model.FilterModels;

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
        public IEnumerable<Department> GetFilterDepartment(DepartmentFilter filter)
        {
            var quary = _context.Departments.AsQueryable();

            if (filter.DateYear != new DateTime().Year)
            {
                quary = quary.Where(dep => dep.DateStart.Year == filter.DateYear);
            }
            if (filter.DateFrom != new DateTime() && filter.DateTo != new DateTime())
            {
                quary = quary.Where(dep => dep.DateStart >= filter.DateFrom && dep.DateStart <= filter.DateTo);
            }
            //фильтр на количество человек не готов
            //if(filter.NumberOfPeople is not 0)
            //{
            //    //quary = quary.Include(a=> a.Positions).ThenInclude(b=> b.Employments).ThenInclude(c=> c.Participants).Where(x=>x.Positions);
            //}
            //фильтр по главе отдела не готов 
            //if(!string.IsNullOrEmpty(filter.Individuals))
            //{
            //    var individuals = _context.Departments.Include(pos => pos.Positions).ThenInclude(emp => emp.Employments)
            //        .ThenInclude(par => par.Participants).ThenInclude(ind => ind.Individuals.FIO).ToList();
            //    quary = quary.Where(individuals == filter.Individuals);
            //}
            if (!string.IsNullOrEmpty(filter.Individuals))
            {
                var individuals = _context.Departments
                   .Where(d => d.Positions.Any(p => p.Employments
                   .Any(e => e.Participants.Individuals.FIO == filter.Individuals))).ToList();
            }
            if (!string.IsNullOrEmpty(filter.Status))
            {
                quary = quary.Where(dep => dep.Status.Contains(filter.Status));
            }
            var departmens = quary.ToList();

            return departmens;
        }
    }
}
