
using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

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
            return _context.StagesOfProjects.Include(x => x.Project).AsNoTracking().ToList();
        }
        public StagesOfProject Get(int id) => _context.StagesOfProjects.Include(x=>x.Project).AsNoTracking().FirstOrDefault(x => x.Id == id);
        public StagesOfProject Get(string name)
        {
            return _context.StagesOfProjects.Include(x => x.Project).AsNoTracking().FirstOrDefault(x => x.Name == name);
        }
        public void Edit(StagesOfProject stages)
        {
            _context.StagesOfProjects.Update(stages);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var stage = _context.StagesOfProjects.FirstOrDefault(x => x.Id == id);
            _context.StagesOfProjects.Remove(stage);
            _context.SaveChanges();
        }
    }
}
