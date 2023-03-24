
using StudentAccounting.Model;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using StudentAccounting.Common.FilterModels;

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
        public IEnumerable<TrainingCourses> GetFiltredrainingCourses(TrainingCoursesFilter filter)
        {
            var quary = _context.TrainingCourses.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Lector))
            {
                quary = quary.Where(trc => trc.LectorFIO.ToLower().Contains(filter.Lector));
            }
            if (!string.IsNullOrEmpty(filter.Status))
            {
                quary = quary.Where(trc => trc.Status.ToLower().Contains(filter.Status));
            }
            if (filter.DateYear is not 0)
            {
                quary = quary.Where(trc=> trc.DateStart.Value.Year == filter.DateYear);
            }
            if (filter.DateFrom != new DateTime() && filter.DateTo != new DateTime())
            {
                quary = quary.Where(trc => trc.DateStart >= filter.DateFrom && trc.DateStart <= filter.DateTo);
            }

            var trainingCourses = quary.ToList();

            return trainingCourses;
        }
    }
}
