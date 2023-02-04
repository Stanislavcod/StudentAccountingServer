using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccounting.BusinessLogic.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDatabaseContext _context;
        public StudentService(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        public void Create(Student newStudent)
        {
            try
            {
                _context.Students.Add(newStudent);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Student> Get()
        {
            try
            {
                return _context.Students.Include(x => x.Individuals).AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Student Get(int id)
        {
            try
            {
                return _context.Students.Include(x => x.Individuals).AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Edit(Student newStudent)
        {
            try
            {
                _context.Students.Update(newStudent);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete(int id)
        {
            try
            {
                var student = _context.Students.FirstOrDefault(x => x.Id == id);
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Student GetByIndividuals(int individualsId)
        {
            try
            {
                return _context.Students.Include(x=>x.Individuals).AsNoTracking().FirstOrDefault(x => x.IndividualsId == individualsId);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
