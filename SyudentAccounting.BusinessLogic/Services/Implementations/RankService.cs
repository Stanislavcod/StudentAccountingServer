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
            try
            {
                _context.Ranks.Add(Rank);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Rank> Get()
        {
            try
            {
                return _context.Ranks.Include(x => x.Organizations).AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Rank Get(int id)
        {
            try
            {
                return _context.Ranks.Include(x => x.Organizations).AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Rank Get(string name)
        {
            try
            {
                return _context.Ranks.Include(x => x.Organizations).AsNoTracking().FirstOrDefault(x => x.RankName == name);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Edit(Rank Rank)
        {
            try
            {
                _context.Ranks.Update(Rank);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete(int id)
        {
            try
            {
                var Rank = _context.Ranks.FirstOrDefault(x => x.Id == id);
                _context.Ranks.Remove(Rank);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
