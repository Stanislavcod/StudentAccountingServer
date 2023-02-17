using StudentAccounting.Model;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class EmploymentService : IEmploymentService
    {
        private readonly ApplicationDatabaseContext _context;
        public EmploymentService(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        public void Create(Employment employment)
        {
            try
            {
                _context.Employments.Add(employment);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Employment> Get()
        {
            try
            {
                return _context.Employments.Include(x => x.Position).Include(x => x.Participants).Include(x=> x.Participants.Individuals).Include(x => x.FinalProjects).AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Employment Get(int id)
        {
            try
            {
                return _context.Employments.Include(x => x.Position).Include(x => x.Participants).Include(x => x.FinalProjects).AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Employment GetByParticipants(int participantsId)
        {
            try
            {
                return _context.Employments.AsNoTracking().Include(x=> x.Position).ThenInclude(x=> x.Department).FirstOrDefault(x => x.ParticipantsId == participantsId);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Edit(Employment employment)
        {
            try
            {
                _context.Employments.Update(employment);
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
                var employment = _context.Employments.FirstOrDefault(x => x.Id == id);
                _context.Employments.Remove(employment);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
