
using StudentAccountin.Model.DatabaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IEmploymentService
    {
        void Create(Employment employment);
        IEnumerable<Employment> Get();
        Employment GetId(int id);
        void Edit(Employment employment);
        void Delete(Employment employment);
    }
}
