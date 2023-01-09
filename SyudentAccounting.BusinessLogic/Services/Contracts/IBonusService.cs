
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Implementations;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IBonusService
    {
        void Create(Bonus bonus);
        IEnumerable<Bonus> Get();
        Bonus GetName(string name);
        void Edit(Bonus bonus);
        void Delete(Bonus bonus);
    }
}
