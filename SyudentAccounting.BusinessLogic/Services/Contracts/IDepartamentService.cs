
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IDepartamentService
    {
        void Create(Department department);
        IEnumerable<Department> Get();
        Department GetName(string name);
        void Edit(Department department);
        void Delete(Department department);
    }
}
