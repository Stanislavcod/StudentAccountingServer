
using StudentAccountin.Model.DatabaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IStagesOfProjectsService
    {
        public void Create(StagesOfProject stagesOfProject);
        public IEnumerable<StagesOfProject> Get();
        public StagesOfProject GetName(string name);
        public void Edit(StagesOfProject stages);
        void Delete(StagesOfProject stages);
    }
}
