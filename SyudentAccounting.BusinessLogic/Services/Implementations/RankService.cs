using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccounting.BusinessLogic.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class RankService : IRankService
    {
        private readonly ApplicationDatabaseContext _context;
        public RankService(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        public void Create(Rank Rank)
        {
            _context.Ranks.Add(Rank);
            _context.SaveChanges();
        }
        public IEnumerable<Rank> Get()
        {
            return _context.Ranks.Include(x => x.Organizations).AsNoTracking().ToList();
        }
        public Rank Get(int id)
        {
            return _context.Ranks.Include(x => x.Organizations).AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
        public Rank Get(string name)
        {
            return _context.Ranks.Include(x => x.Organizations).AsNoTracking().FirstOrDefault(x => x.RankName == name);
        }
        public void Edit(Rank Rank)
        {
            _context.Ranks.Update(Rank);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var Rank = _context.Ranks.FirstOrDefault(x => x.Id == id);
            _context.Ranks.Remove(Rank);
            _context.SaveChanges();
        }
    }
}
