
using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

namespace StudentAccounting.BusinessLogic.Services.Implementations
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
            try
            {
                _context.StagesOfProjects.Add(stagesOfProject);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<StagesOfProject> Get()
        {
            try
            {
                return _context.StagesOfProjects.Include(x => x.Project).AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public StagesOfProject Get(int id)
        {
            try
            {
                return _context.StagesOfProjects.Include(x => x.Project).AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public StagesOfProject Get(string name)
        {
            try
            {
                return _context.StagesOfProjects.Include(x => x.Project).AsNoTracking().FirstOrDefault(x => x.Name == name);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Edit(StagesOfProject stages)
        {
            try
            {
                _context.StagesOfProjects.Update(stages);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete(int id)
        {
            try
            {
                var stage = _context.StagesOfProjects.FirstOrDefault(x => x.Id == id);
                _context.StagesOfProjects.Remove(stage);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
