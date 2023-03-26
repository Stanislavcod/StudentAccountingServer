using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model.FilterModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IDepartmentService
    {
        void Create(Department department);
        IEnumerable<Department> Get();
        Department Get(string name);
        Department Get(int id);
        void Edit(Department department);
        void Delete(int id);
        IEnumerable<Department> GetFiltredDepartment(DepartmentFilter filter);
        int GetDepartmentByParticipantsCount(int departmentId);
    }
}
