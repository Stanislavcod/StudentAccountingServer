
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IIndividualsService
    {
        void Create(Individuals individuals);
        IEnumerable<Individuals> Get();
        Individuals GetName(string name);
        void Edit(Individuals individuals);
        void Delete(Individuals individuals);
    }
}
