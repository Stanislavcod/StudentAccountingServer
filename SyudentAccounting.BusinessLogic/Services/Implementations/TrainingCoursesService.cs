
using StudentAccounting.Model;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;

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
            _context.TrainingCourses.Add(trainingCourses);
            _context.SaveChanges();
        }
        public IEnumerable<TrainingCourses> Get()
        {
            return _context.TrainingCourses.ToList();
        }
        public TrainingCourses Get(string name)
        {
            return _context.TrainingCourses.FirstOrDefault(x => x.Name == name);
        }
        public TrainingCourses Get(int id)
        {
            return _context.TrainingCourses.FirstOrDefault(x => x.Id == id);
        }
        public void Edit(TrainingCourses trainingCourses)
        {
            _context.TrainingCourses.Update(trainingCourses);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var cours = _context.TrainingCourses.FirstOrDefault(x => x.Id == id);
            _context.TrainingCourses.Remove(cours);
            _context.SaveChanges();
        }
    }
}
