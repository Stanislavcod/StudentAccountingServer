using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccounting.BusinessLogic.Services.Contracts;

namespace StudentAccounting.BusinessLogic.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDatabaseContext _context;
        public StudentService(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        public void Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }
        public IEnumerable<Student> Get()
        {
            return _context.Students.ToList();
        }
        public Student GetId(int id)
        {
            return _context.Students.FirstOrDefault(x => x.Id == id);
        }
        public void Edit(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }
        public void Delete(Student student)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
        }
    }
}
