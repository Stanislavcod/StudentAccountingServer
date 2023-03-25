using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.Common.FilterModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IEmploymentService
    {
        void Create(Employment employment);
        IEnumerable<Employment> Get();
        Employment Get(int id);
        List<Employment> GetByParticipants(int participantsId);
        void Edit(Employment employment);
        void Delete(int id);
        IEnumerable<Employment> GetFiltredEmployments(EmploymentFilter filter);
    }
}
