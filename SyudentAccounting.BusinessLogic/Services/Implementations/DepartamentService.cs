using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccounting.BusinessLogic.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDatabaseContext _context;
        public DepartmentService(ApplicationDatabaseContext context)
        {
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
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Department> Get()
        {
            try
            {
                return _context.Departments.Include(x => x.Organizations).AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
              
            }
        }

        public Department Get(string name)
        {
            try
            {
                return _context.Departments.Include(x => x.Organizations).AsNoTracking().FirstOrDefault(x => x.FullName == name);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Department Get(int id)
        {
            try
            {
                return _context.Departments.Include(x => x.Organizations).AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Edit(Department department)
        {
            try
            {
                _context.Departments.Update(department);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var department = _context.Departments.FirstOrDefault(x => x.Id == id);
                _context.Departments.Remove(department);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
