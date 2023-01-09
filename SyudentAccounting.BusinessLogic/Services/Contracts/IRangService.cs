
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IRangService
    {
        void Create(Rang rang);
        IEnumerable<Rang> Get();
        Rang GetName(string name);
        void Edit(Rang rang);
        void Delete(Rang rang);
    }
}
