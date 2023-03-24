

using Microsoft.EntityFrameworkCore;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Common.FilterModels;
using StudentAccounting.Model;
using StudentAccounting.Model.DatabaseModels;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class ScheduleOfСlassesService : IScheduleOfСlassesService
    {
        private readonly ApplicationDatabaseContext _context;
        public ScheduleOfСlassesService(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        public void Create(ScheduleOfСlasses scheduleOfСlasses)
        {
            try
            {
                _context.ScheduleOfСlasses.Add(scheduleOfСlasses);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<ScheduleOfСlasses> Get()
        {
            try
            {
                return _context.ScheduleOfСlasses.Include(x => x.TrainingCourses).AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ScheduleOfСlasses Get(int id)
        {
            try
            {
                return _context.ScheduleOfСlasses.Include(x => x.TrainingCourses).AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<ScheduleOfСlasses> GetForCoursesId(int coursesId)
        {
            try
            {
                return _context.ScheduleOfСlasses.Include(x => x.TrainingCourses).Where(x=> x.TrainingCoursesId == coursesId).AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Edit(ScheduleOfСlasses scheduleOfСlasses)
        {
            try
            {
                _context.ScheduleOfСlasses.Update(scheduleOfСlasses);
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
                var schedule = _context.ScheduleOfСlasses.FirstOrDefault(x => x.Id == id);
                _context.ScheduleOfСlasses.Remove(schedule);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<ScheduleOfСlasses> GetFiltredScheduleOfСlasses(ScheduleOfСlassesFilter filter)
        {
            var quary = _context.ScheduleOfСlasses.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Lector))
            {
                quary = quary.Where(soc => soc.TrainingCourses.LectorFIO.ToLower().Contains(filter.Lector));
            }
            if (filter.DateYear is not 0)
            {
                quary = quary.Where(soc => soc.DateStart.Year == filter.DateYear);
            }
            if (filter.DateFrom != new DateTime() && filter.DateTo != new DateTime())
            {
                quary = quary.Where(soc => soc.TrainingCourses.DateStart == filter.DateFrom && soc.TrainingCourses.DateStart == filter.DateTo);
            }
            if(!string.IsNullOrEmpty(filter.Status))
            {
                quary = quary.Where(soc => soc.TrainingCourses.Status == filter.Status);
            }

            var scheduleOfСlasses = quary.ToList();

            return scheduleOfСlasses;
        }
    }
}
