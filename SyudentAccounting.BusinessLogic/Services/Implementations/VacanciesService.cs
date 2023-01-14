
using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;

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
    }
}
