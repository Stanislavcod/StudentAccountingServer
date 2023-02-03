
using StudentAccountin.Model.DatabaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IFinalProjectService
    {
        void Create(FinalProject finalProject);
        IEnumerable<FinalProject> Get();
        FinalProject Get(string name);
        FinalProject Get(int id);
        void Edit(FinalProject finalProject);
        void Delete(int id);
        IEnumerable<FinalProject> GetForEmployment(int id);
    }
}
