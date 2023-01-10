using StudentAccounting.Common.ModelsDto;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IStudentService
    {
        void Create(StudentDto studentDto);
        IEnumerable<StudentDto> Get();
        StudentDto Get(int id);
        void Edit(StudentDto studentDto);
        void Delete(int id);
    }
}
