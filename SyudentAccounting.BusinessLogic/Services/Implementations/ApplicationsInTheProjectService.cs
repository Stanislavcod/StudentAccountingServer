using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class ApplicationsInTheProjectService : IApplicationInTheProjectService
    {
        private readonly ApplicationDatabaseContext _context;
        public ApplicationsInTheProjectService(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        public void Create(ApplicationsInTheProject applicationsInTheProject)
        {
            _context.ApplicationsInTheProjects.Add(applicationsInTheProject);
            _context.SaveChanges();
        }
        public IEnumerable<ApplicationsInTheProject> Get()
        {
            return _context.ApplicationsInTheProjects.AsNoTracking().ToList();
        }
        public ApplicationsInTheProject Get(int id)
        {
            return _context.ApplicationsInTheProjects.FirstOrDefault(x => x.Id == id);
        }
        public void Edit(ApplicationsInTheProject applicationsInTheProject)
        {
            _context.ApplicationsInTheProjects.Update(applicationsInTheProject);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var application = _context.ApplicationsInTheProjects.FirstOrDefault(x => x.Id == id);
            _context.ApplicationsInTheProjects.Remove(application);
            _context.SaveChanges();
        }
    }
}
