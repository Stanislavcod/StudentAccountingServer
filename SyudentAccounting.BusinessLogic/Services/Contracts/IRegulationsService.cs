
using StudentAccountin.Model.DatabaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IRegulationsService
    {
        void Create(Regulation regulation);
        IEnumerable<Regulation> Get();
        Regulation Get(string name);
        Regulation Get(int id);
        void Edit(Regulation regulation);
        void Delete(int id);
    }
}
