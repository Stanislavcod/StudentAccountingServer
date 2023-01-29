
using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
                return _context.Vacancies.Include(x => x.StagesOfProject).AsNoTracking().ToList();
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
                return _context.Vacancies.Include(x => x.StagesOfProject).AsNoTracking().FirstOrDefault(x => x.Name == name);
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
                return _context.Vacancies.Include(x => x.StagesOfProject).AsNoTracking().FirstOrDefault(x => x.Id == id);
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
                var position = _context.Positions.Include(x => _context.Employments.Where(a => a.Status == true && a.ParticipantsId == participantsId)).ToList();
                var vacancy = _context.Vacancies.Where(x => position.Any(a => a.FullName == x.Name));
                return vacancy;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
