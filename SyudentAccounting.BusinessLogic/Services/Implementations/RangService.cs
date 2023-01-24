using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccounting.BusinessLogic.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace StudentAccounting.BusinessLogic.Services.Implementations
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
            return _context.Rangs.Include(x => x.Organizations).AsNoTracking().ToList();
        }
        public Rang Get(int id)
        {
            return _context.Rangs.Include(x => x.Organizations).AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
        public Rang Get(string name)
        {
            return _context.Rangs.Include(x => x.Organizations).AsNoTracking().FirstOrDefault(x => x.RangName == name);
        }
        public void Edit(Rang rang)
        {
            _context.Rangs.Update(rang);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var rang = _context.Rangs.FirstOrDefault(x => x.Id == id);
            _context.Rangs.Remove(rang);
            _context.SaveChanges();
        }
    }
}
