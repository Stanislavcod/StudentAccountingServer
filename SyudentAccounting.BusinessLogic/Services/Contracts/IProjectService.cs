
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IProjectService
    {
        public void Create(Project project);
        IEnumerable<Project> Get();
        public Project GetId(int id);
        public void Edit(Project project);
        public void Delete(Project project);
    }
}
