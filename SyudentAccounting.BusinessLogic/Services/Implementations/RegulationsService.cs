using StudentAccounting.Model;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;

namespace StudentAccounting.BusinessLogic.Implementations
{
    public class RegulationsService : IRegulationsService
    {
        private readonly ApplicationDatabaseContext _context;
        public RegulationsService(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        public void Create(Regulation regulation)
        {
            _context.Regulations.Add(regulation);
            _context.SaveChanges();
        }
        public IEnumerable<Regulation> Get()
        {
            return _context.Regulations.ToList();
        }
        public Regulation Get(string name)
        {
            return _context.Regulations.FirstOrDefault(x => x.Name == name);
        }
        public Regulation Get(int id)
        {
            return _context.Regulations.FirstOrDefault(x => x.Id == id);
        }
        public void Edit(Regulation regulation)
        {
            _context.Regulations.Update(regulation);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var regulation = _context.Regulations.FirstOrDefault(x => x.Id == id);
            _context.Regulations.Remove(regulation);
            _context.SaveChanges();
        }
    }
}
