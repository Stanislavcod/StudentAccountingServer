
using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace StudentAccounting.BusinessLogic.Implementations
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
            _context.Vacancies.Add(vacancy);
            _context.SaveChanges();
        }
        public IEnumerable<Vacancy> Get()
        {
            return _context.Vacancies.AsNoTracking().ToList();
        }
        public Vacancy Get(string name)
        {
            return _context.Vacancies.FirstOrDefault(x => x.Name == name);
        }
        public Vacancy Get(int id)
        {
            return _context.Vacancies.FirstOrDefault(x => x.Id == id);
        }
        public void Edit(Vacancy vacancy)
        {
            _context.Vacancies.Update(vacancy);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var vacancy = _context.Vacancies.FirstOrDefault(x => x.Id == id);
            _context.Vacancies.Remove(vacancy);
            _context.SaveChanges();
        }
        public IEnumerable<Vacancy> GetVacanciesPos(int participantsId)
        {
            //var position = _context.Positions.Where(a => a.Employments.Where(x => x.Status == true && x.ParticipantsId == participants.Id));
            var position = _context.Positions.Include(x => _context.Employments.Where(a=> a.Status == true && a.ParticipantsId == participantsId)).ToList();
            var vacancy = _context.Vacancies.Where(x=> position.Any(a=> a.FullName == x.Name));
            //var vacancy = _context.Vacancies.Where(x => position.Any(a=> a.FullName == x.Name));
            return vacancy;
        }
    }
}
