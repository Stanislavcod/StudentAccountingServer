using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccounting.BusinessLogic.Services.Contracts;
using AutoMapper;
using StudentAccounting.Common.ModelsDto;
using Microsoft.EntityFrameworkCore;

namespace StudentAccounting.BusinessLogic.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDatabaseContext _context;
        private readonly IMapper _mapper;   
        public StudentService(ApplicationDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Create(StudentDto newStudent)
        {
            var student = _mapper.Map<Student>(newStudent);
            _context.Students.Add(student);
            _context.SaveChanges();
        }
        public IEnumerable<StudentDto> Get()
        {
            var students = _context.Students.Include(x=>x.Individuals).AsNoTracking().ToList();
            var studentsDto = _mapper.Map<List<StudentDto>>(students);
            return studentsDto;
        }
        public StudentDto Get(int id)
        {
            var student = _context.Students.Include(x=>x.Individuals).FirstOrDefault(x => x.Id == id);
            var studentDto = _mapper.Map<StudentDto>(student);
            return studentDto;
        }
        public void Edit(StudentDto newStudent)
        {
            var student = _mapper.Map<Student>(newStudent);
            _context.Students.Update(student);
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
