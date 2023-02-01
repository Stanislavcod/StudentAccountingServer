using Microsoft.EntityFrameworkCore;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Model;
using StudentAccounting.Model.DatabaseModels;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class EducationalPortalsService : IEducationalPortalsService
    {
        private readonly ApplicationDatabaseContext _context;
        public EducationalPortalsService(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        public void Create(EducationalPortals educationalPortal)
        {
            try
            {
                _context.EducationalPortals.Add(educationalPortal);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<EducationalPortals> Get()
        {
            try
            {
                return _context.EducationalPortals.Include(x => x.Department).AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public EducationalPortals Get(string name)
        {
            try
            {
                return _context.EducationalPortals.Include(x => x.Department).AsNoTracking().FirstOrDefault(x => x.Name == name);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public EducationalPortals Get(int id)
        {
            try
            {
                return _context.EducationalPortals.Include(x => x.Department).AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Edit(EducationalPortals educationalPortals)
        {
            try
            {
                _context.EducationalPortals.Update(educationalPortals);
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
                var educationPortal = _context.EducationalPortals.FirstOrDefault(x => x.Id == id);
                _context.EducationalPortals.Remove(educationPortal);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
