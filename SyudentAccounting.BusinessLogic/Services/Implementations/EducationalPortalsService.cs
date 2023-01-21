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
            _context.EducationalPortals.Add(educationalPortal);
            _context.SaveChanges();
        }
        public IEnumerable<EducationalPortals> Get()
        {
            return _context.EducationalPortals.AsNoTracking().ToList();
        }
        public EducationalPortals Get(string name)
        {
            return _context.EducationalPortals.AsNoTracking().FirstOrDefault(x => x.Name == name);
        }
        public EducationalPortals Get(int id)
        {
            return _context.EducationalPortals.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
        public void Edit(EducationalPortals educationalPortals)
        {
            _context.EducationalPortals.Update(educationalPortals);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var educationPortal = _context.EducationalPortals.FirstOrDefault(x => x.Id == id);
            _context.EducationalPortals.Remove(educationPortal);
            _context.SaveChanges();
        }
    }
}
