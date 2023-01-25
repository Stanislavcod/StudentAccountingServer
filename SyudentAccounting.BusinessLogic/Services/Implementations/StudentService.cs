using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccounting.BusinessLogic.Services.Contracts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDatabaseContext _context;
        private readonly IMapper _mapper;
        public StudentService(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        public void Create(Student newStudent)
        {
            _context.Students.Add(newStudent);
            _context.SaveChanges();
        }
        public IEnumerable<Student> Get()
        {
            return _context.Students.Include(x => x.Individuals).AsNoTracking().ToList();
        }
        public Student Get(int id)
        {
            return _context.Students.Include(x => x.Individuals).AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
        public void Edit(Student newStudent)
        {
            _context.Students.Update(newStudent);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var student = _context.Students.FirstOrDefault(x => x.Id == id);
            _context.Students.Remove(student);
            _context.SaveChanges();
        }
    }
}
