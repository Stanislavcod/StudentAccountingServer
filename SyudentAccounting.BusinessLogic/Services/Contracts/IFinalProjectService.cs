
using StudentAccountin.Model.DatabaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IFinalProjectService
    {
        void Create(FinalProject finalProject);
        IEnumerable<FinalProject> Get();
        FinalProject GetName(string name);
        void Edit(FinalProject finalProject);
        void Delete(FinalProject finalProject);
    }
}
