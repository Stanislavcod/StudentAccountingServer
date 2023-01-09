
using StudentAccountin.Model.DatabaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IApplicationInTheProjectService
    {
        void Create(ApplicationsInTheProject applicationsInTheProject);
        IEnumerable<ApplicationsInTheProject> Get();
        ApplicationsInTheProject GetId(int id);
        void Edit(ApplicationsInTheProject applicationsInTheProject);
        void Delete(ApplicationsInTheProject applicationsInTheProject);
    }
}
