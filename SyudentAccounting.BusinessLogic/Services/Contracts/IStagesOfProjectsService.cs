
using StudentAccountin.Model.DatabaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IStagesOfProjectsService
    {
        void Create(StagesOfProject stagesOfProject);
        IEnumerable<StagesOfProject> Get();
        StagesOfProject Get(string name);
        StagesOfProject Get(int id);
        IEnumerable<StagesOfProject> GetForProjectId (int projectId);
        void Edit(StagesOfProject stages);
        void Delete(int id);
    }
}
