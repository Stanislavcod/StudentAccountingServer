
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Implementations;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IBonusService
    {
        void Create(Bonus bonus);
        IEnumerable<Bonus> Get();
        Bonus Get(string name);
        Bonus Get(int id);
        void Edit(Bonus bonus);
        void Delete(int id);
    }
}
