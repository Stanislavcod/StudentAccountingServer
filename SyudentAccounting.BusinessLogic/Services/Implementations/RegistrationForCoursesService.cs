
using Microsoft.EntityFrameworkCore;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Model;
using StudentAccounting.Model.DatabaseModels;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class RegistrationForCoursesService : IRegistrationForCoursesService
    {
        private readonly ApplicationDatabaseContext _context;
        public RegistrationForCoursesService(ApplicationDatabaseContext applicationDatabaseContext)
        {
            _context = applicationDatabaseContext;
        }
        public void Create(RegistrationForCourses registrationForCourses)
        {
            _context.RegistrationForCourses.Add(registrationForCourses);
            _context.SaveChanges();
        }
        public IEnumerable<RegistrationForCourses> Get()
        {
            return _context.RegistrationForCourses.Include(x=> x.Participants).Include(x=> x.TrainingCourses).AsNoTracking().ToList();
        }
        public RegistrationForCourses Get(int id)
        {
            return _context.RegistrationForCourses.Include(x => x.Participants).Include(x => x.TrainingCourses).AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
        public void Edit(RegistrationForCourses registrationForCourses)
        {
            _context.RegistrationForCourses.Update(registrationForCourses);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var registration = _context.RegistrationForCourses.FirstOrDefault(x => x.Id == id);
            _context.RegistrationForCourses.Remove(registration);
            _context.SaveChanges();
        }
    }
}
