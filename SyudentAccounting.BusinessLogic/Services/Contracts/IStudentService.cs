
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IStudentService
    {
        void Create(Student studentDto);
        IEnumerable<Student> Get();
        Student Get(int id);
        void Edit(Student studentDto);
        void Delete(int id);
        Student GetByIndividuals(int individualsId);
    }
}
