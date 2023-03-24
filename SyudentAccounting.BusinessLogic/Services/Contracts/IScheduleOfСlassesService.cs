using StudentAccounting.Common.FilterModels;
using StudentAccounting.Model.DatabaseModels;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IScheduleOfСlassesService
    {
        void Create(ScheduleOfСlasses scheduleOfСlasses);
        IEnumerable<ScheduleOfСlasses> Get();
        ScheduleOfСlasses Get(int id);
        void Edit(ScheduleOfСlasses scheduleOfСlasses);
        IEnumerable<ScheduleOfСlasses> GetForCoursesId(int coursesId);
        void Delete(int id);
        IEnumerable<ScheduleOfСlasses> GetFiltredScheduleOfСlasses(ScheduleOfСlassesFilter filter);
    }
}
