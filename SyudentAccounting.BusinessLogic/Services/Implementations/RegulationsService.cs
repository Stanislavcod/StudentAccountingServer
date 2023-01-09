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
        public Regulation GetName(string name)
        {
            return _context.Regulations.FirstOrDefault(x => x.Name == name);
        }
        public void Edit(Regulation regulation)
        {
            _context.Regulations.Update(regulation);
            _context.SaveChanges();
        }
        public void Delete(Regulation regulation)
        {
            _context.Regulations.Remove(regulation);
            _context.SaveChanges();
        }
    }
}
