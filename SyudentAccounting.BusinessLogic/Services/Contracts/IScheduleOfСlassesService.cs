using StudentAccounting.Model.DatabaseModels;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IScheduleOfСlassesService
    {
        void Create(ScheduleOfСlasses scheduleOfСlasses);
        IEnumerable<ScheduleOfСlasses> Get();
        ScheduleOfСlasses Get(int id);
        void Edit(Bonus bonus);
        void Delete(int id);
    }
}
