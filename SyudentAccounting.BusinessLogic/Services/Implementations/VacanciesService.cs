
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
            return _context.Vacancies.ToList();
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
        public IEnumerable<Vacancy> Get(Participants participants)
        {
            //List<Vacancy> vacancyList = new List<Vacancy>();
            //foreach (Employment employment in participants.Employments.Where(p => p.Status == true).ToList())
            //    vacancyList.Add(_context.Vacancies.FirstOrDefault(p => p.Name == employment.Position.FullName));
            //var partisipantsNew = _context.Participants.FirstOrDefault(x => x.Id == participants.Id);
            //var employments = partisipantsNew.Employments.Where(x => x.Status == true).ToList();
            //var vacancy = _context.Vacancies.Where(x => x.Name.ToList() == employments.Select(x => x.Position.FullName)).ToList();
            //var partisipantsNew = _context.Participants.FirstOrDefault(x => x.Id == participants.Id);
            //var employments = partisipantsNew.Employments.Where(x => x.Status == true).ToList();
            var vacancy = _context.Vacancies.Where(x => _context.Positions.Include(a => a.Employments.Where(x => x.Status == true && x.ParticipantsId == participants.Id)).Any(a=> a.FullName == x.Name));
            //var vacancy = _context.Vacancies.Where(x => x.Name.ToList() == _context.Positions.Include(a => a.Employments.Where(x => x.Status == true && x.ParticipantsId == participants.Id)).Select(a => a.FullName));
            return vacancy;
        }
    }
}
