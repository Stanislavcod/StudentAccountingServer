 using StudentAccounting.Model;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudentAccounting.Common.FilterModels;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class EmploymentService : IEmploymentService
    {
        private readonly ILogger<EmploymentService> _logger;
        private readonly ApplicationDatabaseContext _context;
        public EmploymentService(ApplicationDatabaseContext context, ILogger<EmploymentService> logger)
        {
            _logger = logger;
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
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
            }
        }
        
        public IEnumerable<Employment> Get()
        {
            try
            {
                var employments = _context.Employments.Include(x => x.Position.Department).
                    Include(x => x.Participants).Include(x=> x.Participants.Individuals).Include(x => x.FinalProjects).AsNoTracking().ToList();

                return employments;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");

                return new List<Employment>();
            }
        }
        
        public Employment Get(int id)
        {
            try
            {
                var employment = _context.Employments.Include(x => x.Position.Department).
                    Include(x => x.Participants).Include(x => x.FinalProjects).AsNoTracking().FirstOrDefault(x => x.Id == id);

                if (employment == null)
                {
                    return new Employment();
                }
                
                return employment;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");

                return new Employment();
            }
        }
        
        public Employment GetByParticipants(int participantsId)
        {
            try
            {
                var employment = _context.Employments.AsNoTracking().Include(x=> x.Position).
                    ThenInclude(x=> x.Department).FirstOrDefault(x => x.ParticipantsId == participantsId);

                if (employment == null)
                {
                    return new Employment();
                }
                
                return employment;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");

                return new Employment();
            }
        }
        
        public void Edit(Employment employment)
        {
            try
            {
                _context.Employments.Update(employment);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
            }
        }
        
        public void Delete(int id)
        {
            try
            {
                var employment = _context.Employments.FirstOrDefault(x => x.Id == id);

                if (employment != null)
                {
                    _context.Employments.Remove(employment);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
            }
        }
        public IEnumerable<Employment> GetFiltredEmployments(EmploymentFilter filter)
        {
            var quary = _context.Employments.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Department))
            {
                quary = quary.Where(emp => emp.Position.Department.FullName.Contains(filter.Department));
            }
            if (!string.IsNullOrEmpty(filter.Position))
            {
                quary = quary.Where(emp => emp.Position.FullName.Contains(filter.Position));
            }
            if (filter.DateYear != new DateTime().Year)
            {
                quary = quary.Where(emp => emp.DateStart.Year == filter.DateYear);
            }
            if (filter.DateFrom != new DateTime() && filter.DateTo != new DateTime())
            {
                quary = quary.Where(emp => emp.DateStart >= filter.DateFrom && emp.DateStart <= filter.DateTo);
            }
            if(filter.ExperienceFrom is not 0 && filter.ExperienceTo is not 0) 
            {
                quary = quary.Where(emp => (DateTime.Now - emp.Participants.DateEntry).Days >= filter.ExperienceFrom
                && (DateTime.Now - emp.Participants.DateEntry).Days <= filter.ExperienceTo);
            }
            if(filter.Experience is not 0)
            {
                quary = quary.Where(emp => (DateTime.Now - emp.Participants.DateEntry).Days >= filter.Experience);
            }
            if(!string.IsNullOrEmpty(filter.Status))
            {
                quary = quary.Where(emp => emp.Status.Contains(filter.Status));
            }

            var employments = quary.ToList();

            return employments;
        }
    }
}
