
using StudentAccounting.Model;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class TrainingCoursesService : ITrainingCoursesService
    {
        private readonly ApplicationDatabaseContext _context;
        public TrainingCoursesService(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        public void Create(TrainingCourses trainingCourses)
        {
            try
            {
                _context.TrainingCourses.Add(trainingCourses);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<TrainingCourses> Get()
        {
            try
            {
                return _context.TrainingCourses.AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public TrainingCourses Get(string name)
        {
            try
            {
                return _context.TrainingCourses.AsNoTracking().FirstOrDefault(x => x.Name == name);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public TrainingCourses Get(int id)
        {
            try
            {
                return _context.TrainingCourses.AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Edit(TrainingCourses trainingCourses)
        {
            try
            {
                _context.TrainingCourses.Update(trainingCourses);
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
                var cours = _context.TrainingCourses.FirstOrDefault(x => x.Id == id);
                _context.TrainingCourses.Remove(cours);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
