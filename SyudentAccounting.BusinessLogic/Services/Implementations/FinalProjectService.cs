
using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;

namespace StudentAccounting.BusinessLogic.Implementations
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
            return _context.FinalProjects.ToList();
        }
        public FinalProject GetName(string name)
        {
            return _context.FinalProjects.FirstOrDefault(x => x.Name == name);
        }
        public void Edit(FinalProject finalProject)
        {
            _context.FinalProjects.Update(finalProject);
            _context.SaveChanges();
        }
        public void Delete(FinalProject finalProject)
        {
            _context.FinalProjects.Remove(finalProject);
            _context.SaveChanges();
        }
    }
}
