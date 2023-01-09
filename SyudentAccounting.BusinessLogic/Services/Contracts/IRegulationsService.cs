
using StudentAccountin.Model.DatabaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IRegulationsService
    {
        void Create(Regulation regulation);
        IEnumerable<Regulation> Get();
        Regulation GetName(string name);
        void Edit(Regulation regulation);
        void Delete(Regulation regulation);
    }
}
