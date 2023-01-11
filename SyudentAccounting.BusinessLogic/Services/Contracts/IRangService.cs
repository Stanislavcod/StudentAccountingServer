
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IRangService
    {
        void Create(Rang rang);
        IEnumerable<Rang> Get();
        Rang Get(string name);
        Rang Get(int id);

        void Edit(Rang rang);
        void Delete(int id);
    }
}
