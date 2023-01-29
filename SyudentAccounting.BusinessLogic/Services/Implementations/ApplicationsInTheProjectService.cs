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
            if (applicationsInTheProject == null)
            {
                throw new ArgumentNullException(nameof(applicationsInTheProject));
            }
            if (_context.ApplicationsInTheProjects.Any(x => x.Id == applicationsInTheProject.Id))
            {
                throw new Exception();
            }
            _context.ApplicationsInTheProjects.Add(applicationsInTheProject);
            _context.SaveChanges();
        }
        public IEnumerable<ApplicationsInTheProject> Get()
        {
            return _context.ApplicationsInTheProjects.Include(x => x.Vacancy).Include(x => x.Participants).AsNoTracking().ToList();
        }
        public ApplicationsInTheProject Get(int id)
        {
            if (id <= 0)
            {
                throw new Exception();
            }
            var application = _context.ApplicationsInTheProjects.Include(x => x.Vacancy).Include(x => x.Participants).AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (application == null)
            {
                throw new Exception();
            }
            return application;
        }
        public void Edit(ApplicationsInTheProject applicationsInTheProject)
        {
            if (applicationsInTheProject == null)
            {
                throw new ArgumentNullException(nameof(applicationsInTheProject));
            }
            if (!_context.ApplicationsInTheProjects.Any(x => x.Id == applicationsInTheProject.Id))
            {
                throw new Exception();
            }
            _context.ApplicationsInTheProjects.Update(applicationsInTheProject);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }
            var application = _context.ApplicationsInTheProjects.FirstOrDefault(x => x.Id == id);
            if (application == null)
            {
                throw new Exception();
            }
            _context.ApplicationsInTheProjects.Remove(application);
            _context.SaveChanges();
        }
    }
}

