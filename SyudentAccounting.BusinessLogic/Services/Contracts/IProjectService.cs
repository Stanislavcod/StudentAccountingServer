using StudentAccounting.Common.FilterModels;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IProjectService
    {
        void Create(Project project);
        IEnumerable<Project> Get();
        Project Get(int id);
        void Edit(Project project);
        void Delete(int id);
        List<Project> GetForParticipantsId(int participantsId);
        IEnumerable<Project> GetFiltredProject(ProjectFilter filter);
    }
}
