

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
            _context.ScheduleOfСlasses.Add(scheduleOfСlasses);
            _context.SaveChanges();
        }
        public IEnumerable<ScheduleOfСlasses> Get()
        {
            return _context.ScheduleOfСlasses.AsNoTracking().ToList();
        }
        public ScheduleOfСlasses Get(int id)
        {
            return _context.ScheduleOfСlasses.FirstOrDefault(x => x.Id == id);
        }
        public void Edit(ScheduleOfСlasses scheduleOfСlasses)
        {
            _context.ScheduleOfСlasses.Update(scheduleOfСlasses);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var schedule = _context.ScheduleOfСlasses.FirstOrDefault(x => x.Id == id);
            _context.ScheduleOfСlasses.Remove(schedule);
            _context.SaveChanges();
        }
    }
}
