using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccounting.BusinessLogic.Services.Contracts;

namespace StudentAccounting.BusinessLogic.Implementations
{
    public class IndividualsService : IIndividualsService
    {
        private readonly ApplicationDatabaseContext _context;
        public IndividualsService(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        public void Create(Individuals individuals)
        {
            _context.Individuals.Add(individuals);
            _context.SaveChanges();
        }
        public IEnumerable<Individuals> Get()
        {
            return _context.Individuals.ToList();
        }
        public Individuals GetName(string name)
        {
            return _context.Individuals.FirstOrDefault(x => x.FIO == name);
        }
        public void Edit(Individuals individuals)
        {
            _context.Individuals.Update(individuals);
            _context.SaveChanges();
        }
        public void Delete(Individuals individuals)
        {
            _context.Individuals.Update(individuals);
            _context.SaveChanges();
        }
    }
}
