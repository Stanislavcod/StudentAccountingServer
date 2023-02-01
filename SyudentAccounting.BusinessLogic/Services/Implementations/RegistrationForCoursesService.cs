
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
            try
            {
                _context.RegistrationForCourses.Add(registrationForCourses);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<RegistrationForCourses> Get()
        {
            try
            {
                return _context.RegistrationForCourses.Include(x => x.Participants).Include(x => x.TrainingCourses).AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public RegistrationForCourses Get(int id)
        {
            try
            {
                return _context.RegistrationForCourses.Include(x => x.Participants).Include(x => x.TrainingCourses).AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Edit(RegistrationForCourses registrationForCourses)
        {
            try
            {
                _context.RegistrationForCourses.Update(registrationForCourses);
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
                var registration = _context.RegistrationForCourses.FirstOrDefault(x => x.Id == id);
                _context.RegistrationForCourses.Remove(registration);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
