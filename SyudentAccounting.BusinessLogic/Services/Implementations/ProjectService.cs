using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccounting.BusinessLogic.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly ApplicationDatabaseContext _context;
        public ProjectService(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        public void Create(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
        }
        public IEnumerable<Project> Get()
        {
            return _context.Projects.Include(x => x.Customer).AsNoTracking().ToList();
        }
        public Project Get(int id)
        {
            return _context.Projects.Include(x => x.Customer).AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
        public void Edit(Project project)
        {
            _context.Projects.Update(project);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var project = _context.Projects.FirstOrDefault(x => x.Id == id);
            _context.Projects.Remove(project);
            _context.SaveChanges();
        }
    }
}
