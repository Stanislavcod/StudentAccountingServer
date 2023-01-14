
using StudentAccountin.Model.DatabaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IStagesOfProjectsService
    {
        public void Create(StagesOfProject stagesOfProject);
        public IEnumerable<StagesOfProject> Get();
        public StagesOfProject Get(string name);
        public StagesOfProject Get(int id);
        public void Edit(StagesOfProject stages);
        void Delete(int id);
    }
}
