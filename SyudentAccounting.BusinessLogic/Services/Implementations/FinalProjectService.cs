
using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class FinalProjectService : IFinalProjectService
    {
        private readonly ApplicationDatabaseContext _context;
        public FinalProjectService(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        public void Create(FinalProject finalProject)
        {
            _context.FinalProjects.Add(finalProject);
            _context.SaveChanges();
        }
        public IEnumerable<FinalProject> Get()
        {
            return _context.FinalProjects.Include(x => x.Employment).AsNoTracking().ToList();
        }
        public FinalProject Get(string name)
        {
            return _context.FinalProjects.Include(x => x.Employment).AsNoTracking().FirstOrDefault(x => x.Name == name);
        }
        public FinalProject Get(int id)
        {
            return _context.FinalProjects.FirstOrDefault(x => x.Id == id);
        }
        public void Edit(FinalProject finalProject)
        {
            _context.FinalProjects.Update(finalProject);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var finalProject = _context.FinalProjects.FirstOrDefault(x => x.Id == id);
            _context.FinalProjects.Remove(finalProject);
            _context.SaveChanges();
        }
    }
}
