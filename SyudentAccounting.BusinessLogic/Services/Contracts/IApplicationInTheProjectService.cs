using StudentAccountin.Model.DatabaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IApplicationInTheProjectService
    {
        void Create(ApplicationsInTheProject applicationsInTheProject);
        IEnumerable<ApplicationsInTheProject> Get();
        ApplicationsInTheProject Get(int id);
        IEnumerable<ApplicationsInTheProject> GetForVacancyId(int vacancyId);
        void Edit(ApplicationsInTheProject applicationsInTheProject);
        void Delete(int id);
    }
}
