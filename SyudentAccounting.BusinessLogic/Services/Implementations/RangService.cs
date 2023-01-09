using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccounting.BusinessLogic.Services.Contracts;

namespace StudentAccounting.BusinessLogic.Implementations
{
    public class RangService : IRangService
    {
        private readonly ApplicationDatabaseContext _context;
        public RangService(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        public void Create(Rang rang)
        {
            _context.Rangs.Add(rang);
            _context.SaveChanges();
        }
        public IEnumerable<Rang> Get()
        {
            return _context.Rangs.ToList();
        }
        public Rang GetName(string name)
        {
            return _context.Rangs.FirstOrDefault(x => x.RangName == name);
        }
        public void Edit(Rang rang)
        {
            _context.Rangs.Update(rang);
            _context.SaveChanges();
        }
        public void Delete(Rang rang)
        {
            _context.Rangs.Remove(rang);
            _context.SaveChanges();
        }
    }
}
