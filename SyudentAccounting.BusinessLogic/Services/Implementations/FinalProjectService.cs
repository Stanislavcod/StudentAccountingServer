
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
            try
            {
                _context.FinalProjects.Add(finalProject);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<FinalProject> Get()
        {
            try
            {
                return _context.FinalProjects.Include(x => x.Employment).AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public FinalProject Get(string name)
        {
            try
            {
                return _context.FinalProjects.Include(x => x.Employment).AsNoTracking().FirstOrDefault(x => x.Name == name);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public FinalProject Get(int id)
        {
            try
            {
                return _context.FinalProjects.AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Edit(FinalProject finalProject)
        {
            try
            {
                _context.FinalProjects.Update(finalProject);
                _context.SaveChanges();
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
                var finalProject = _context.FinalProjects.FirstOrDefault(x => x.Id == id);
                _context.FinalProjects.Remove(finalProject);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
