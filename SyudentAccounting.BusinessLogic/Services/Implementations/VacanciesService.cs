using StudentAccounting.Model;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using StudentAccounting.Common.FilterModels;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class VacanciesService : IVacanciesService
    {
        private readonly ApplicationDatabaseContext _context;
        public VacanciesService(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        public void Create(Vacancy vacancy)
        {
            try
            {
                _context.Vacancies.Add(vacancy);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Vacancy> Get()
        {
            try
            {
                return _context.Vacancies.Include(x => x.StagesOfProject.Project).AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Vacancy Get(string name)
        {
            try
            {
                return _context.Vacancies.Include(x => x.StagesOfProject.Project).AsNoTracking().FirstOrDefault(x => x.Name == name);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Vacancy Get(int id)
        {
            try
            {
                return _context.Vacancies.Include(x => x.StagesOfProject.Project).AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Vacancy> GetForStagesId(int stagesId)
        {
            try
            {
                return _context.Vacancies.Include(x => x.StagesOfProject.Project).Where(x=> x.StagesOfProjectId == stagesId).AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Edit(Vacancy vacancy)
        {
            try
            {
                _context.Vacancies.Update(vacancy);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete(int id)
        {
            try
            {
                var vacancy = _context.Vacancies.FirstOrDefault(x => x.Id == id);
                _context.Vacancies.Remove(vacancy);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Vacancy> GetVacanciesPos(int participantsId)
        {
            try
            {
                var position = _context.Positions.Include(x => _context.Employments.Where(a => a.Status == "Трудоустроен" && a.ParticipantsId == participantsId)).ToList();
                var vacancy = _context.Vacancies.Where(x => position.Any(a => a.FullName == x.Name));
                return vacancy;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Vacancy> GetFiltredVacancy(VacancyFilter filter)
        {
            var quary = _context.Vacancies.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Vacancy))
            {
                quary = quary.Where(vacancy => vacancy.Name.ToLower().Contains(filter.Vacancy));
            }
            if (!string.IsNullOrEmpty(filter.Project))
            {
                quary = quary.Where(vacancy => vacancy.StagesOfProject.Project.Fullname.ToLower().Contains(filter.Project));
            }
            if (filter.Status != new bool())
            {
                quary = quary.Where(vacancy => vacancy.isOpened == filter.Status);
            }
            if (filter.DateYear is not 0)
            {
                quary = quary.Where(vacancy => vacancy.DateStart.Year == filter.DateYear);
            }
            if (filter.DateFrom != new DateTime() && filter.DateTo != new DateTime())
            {
                quary = quary.Where(vacancy => vacancy.DateStart >= filter.DateFrom && vacancy.DateStart <= filter.DateTo);
            }

            var trainingCourses = quary.ToList();

            return trainingCourses;
        }
    }
}
