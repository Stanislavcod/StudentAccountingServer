using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccounting.BusinessLogic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudentAccounting.Model.FilterModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        public int GetDepartmentByParticipantsCount(int departmentId)
        {
            try
            {
                var department = _context.Departments
                    .Include(d => d.Positions)
                    .ThenInclude(p => p.Employments)
                    .FirstOrDefault(d => d.Id == departmentId);

                if (department == null)
                {
                    throw new Exception("Отдела не найден");  
                }

                var participantCount = department.Positions
                    .SelectMany(p => p.Employments)
                    .Select(e => e.ParticipantsId)
                    .Distinct()
                    .Count();

                return participantCount;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
                return -1;
            }
        }
        public IEnumerable<Department> GetFiltredDepartment(DepartmentFilter filter)
        {
            var query = _context.Departments.AsQueryable();

            if (filter.DateYear is not 0)
            {
                query = query.Where(dep => dep.DateStart.Year == filter.DateYear);
            }
            if (filter.DateFrom != new DateTime() && filter.DateTo != new DateTime())
            {
                query = query.Where(dep => dep.DateStart >= filter.DateFrom && dep.DateStart <= filter.DateTo);
            }
            if (filter.NumberOfPeople is not 0)
            {
                query = query.Where(dep => dep.Positions
                        .Join(_context.Employments, p => p.Id, e => e.PositionId, (p, e) => e.ParticipantsId)
                        .Distinct()
                        .Count() == filter.NumberOfPeople);
            }
            if(filter.NumberOfPeopleFrom != 0 && filter.NumberOfPeopleTo != 0) 
            {
                query = query.Where(dep => dep.Positions
                       .SelectMany(p => p.Employments)
                       .Select(e => e.ParticipantsId)
                       .Distinct()
                       .Count(id => id != null)
                       >= filter.NumberOfPeopleFrom
                       && dep.Positions
                       .SelectMany(p => p.Employments)
                       .Select(e => e.ParticipantsId)
                       .Distinct()
                       .Count(id => id != null)
                       <= filter.NumberOfPeopleTo);
            }
            if (filter.ParticipantsId is not 0)
            {
                query = query.Where(d=> d.DirectorId == filter.ParticipantsId);
            }
            if (!string.IsNullOrEmpty(filter.Status))
            {
                query = query.Where(dep => dep.Status.Contains(filter.Status));
            }
            var departmens = query.ToList();

            return departmens;
        }
    }
}
