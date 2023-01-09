using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccounting.BusinessLogic.Services.Contracts;

namespace StudentAccounting.BusinessLogic.Implementations
{
    public class DepartamentService : IDepartamentService
    {
        private readonly ApplicationDatabaseContext _context;
        public DepartamentService(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        public void Create(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }
        public IEnumerable<Department> Get()
        {
            return _context.Departments.ToList();
        }
        public Department GetName(string name)
        {
            return _context.Departments.FirstOrDefault(x => x.FullName == name);
        }
        public void Edit(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();
        }
        public void Delete(Department department)
        {
            _context.Departments.Remove(department);
            _context.SaveChanges();
        }
    }
}
