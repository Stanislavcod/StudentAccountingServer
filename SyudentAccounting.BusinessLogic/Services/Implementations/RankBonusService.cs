using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccounting.Model.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class RankBonusService : IRankBonusService
    {
        private readonly ApplicationDatabaseContext _context;
        public RankBonusService(ApplicationDatabaseContext context)
        {
            _context = context;
        }

        public void Create(RankBonus rankBonus)
        {
            try
            {
                _context.RankBonus.Add(rankBonus);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<RankBonus> Get()
        {
            try
            {
                return _context.RankBonus.Include(x => x.Rank).Include(x => x.Bonus).AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public RankBonus Get(int id)
        {
            try
            {
                return _context.RankBonus.Include(x => x.Rank).Include(x => x.Bonus).AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Edit(RankBonus rankBonus)
        {
            try
            {
                _context.RankBonus.Update(rankBonus);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete(int rankId, int bonusId)
        {
            try
            {
                var rankBonus = _context.RankBonus.FirstOrDefault(x => x.RankId == rankId && x.BonusId == bonusId);
                _context.RankBonus.Remove(rankBonus);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
