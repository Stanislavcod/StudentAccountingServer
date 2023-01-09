
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IStudentService
    {
        void Create(Student student);
        IEnumerable<Student> Get();
        Student GetId(int id);
        void Edit(Student student);
        void Delete(Student student);
    }
}
