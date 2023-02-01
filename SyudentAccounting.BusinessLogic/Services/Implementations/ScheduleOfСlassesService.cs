

using Microsoft.EntityFrameworkCore;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Model;
using StudentAccounting.Model.DatabaseModels;
using StudentAccounting.Model.DataBaseModels;

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


    }
}
