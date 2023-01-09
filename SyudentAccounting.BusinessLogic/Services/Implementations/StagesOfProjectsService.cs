
using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;

namespace StudentAccounting.BusinessLogic.Implementations
{
    public class StagesOfProjectsService : IStagesOfProjectsService
    {
        private readonly ApplicationDatabaseContext _context;
        public StagesOfProjectsService(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        public void Create(StagesOfProject stagesOfProject)
        {
            _context.StagesOfProjects.Add(stagesOfProject);
            _context.SaveChanges();
        }
        public IEnumerable<StagesOfProject> Get()
        {
            return _context.StagesOfProjects.ToList();
        }
        public StagesOfProject GetName(string name)
        {
            return _context.StagesOfProjects.FirstOrDefault(x => x.Name == name);
        }
        public void Edit(StagesOfProject stages)
        {
            _context.StagesOfProjects.Update(stages);
            _context.SaveChanges();
        }
        public void Delete(StagesOfProject stages)
        {
            _context.StagesOfProjects.Remove(stages);
            _context.SaveChanges();
        }
    }
}
