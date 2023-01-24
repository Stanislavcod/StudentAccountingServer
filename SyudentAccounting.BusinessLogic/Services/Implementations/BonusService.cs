using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccounting.BusinessLogic.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class BonusService : IBonusService
    {
        private readonly ApplicationDatabaseContext _context;
        public BonusService(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        public void Create(Bonus bonus)
        {
            _context.Bonuses.Add(bonus);
            _context.SaveChanges();
        }
        public IEnumerable<Bonus> Get()
        {
            return _context.Bonuses.Include(x => x.Rank).AsNoTracking().ToList();
        }
        public Bonus Get(string name)
        {
            return _context.Bonuses.Include(x => x.Rank).AsNoTracking().FirstOrDefault(x => x.BonusName == name);
        }
        public Bonus Get(int id)
        {
            return _context.Bonuses.FirstOrDefault(x => x.Id == id);
        }
        public void Edit(Bonus bonus)
        {
            _context.Bonuses.Update(bonus);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var bonus = _context.Bonuses.FirstOrDefault(x => x.Id == id);
            _context.Bonuses.Remove(bonus);
            _context.SaveChanges();
        }
    }
}
