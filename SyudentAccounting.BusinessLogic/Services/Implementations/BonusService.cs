using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccounting.BusinessLogic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class BonusService : IBonusService
    {
        private readonly ILogger<BonusService> _logger;
        private readonly ApplicationDatabaseContext _context;
        
        public BonusService(ApplicationDatabaseContext context, ILogger<BonusService> logger)
        {
            _logger = logger;
            _context = context;
        }
        
        public void Create(Bonus bonus)
        {
            try
            {
                _context.Bonuses.Add(bonus);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
            }
        }

        public IEnumerable<Bonus> Get()
        {
            try
            {
                var bonuses = _context.Bonuses.Include(x => x.RankBonus).
                    ThenInclude(rb => rb.Rank).AsNoTracking().ToList();

                return bonuses;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");

                return new List<Bonus>();
            }
        }

        public Bonus Get(string name)
        {
            try
            {
                var bonus = _context.Bonuses.Include(x => x.RankBonus).
                    ThenInclude(rb => rb.Rank).AsNoTracking().FirstOrDefault(x => x.BonusName == name);

                return bonus;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");

                return null;
            }
        }

        public Bonus Get(int id)
        {
            try
            {
                var bonus = _context.Bonuses.Include(x => x.RankBonus).
                    ThenInclude(rb => rb.Rank).AsNoTracking().FirstOrDefault(x => x.Id == id);

                return bonus;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");

                return null;
            }
        }

        public void Edit(Bonus bonus)
        {
            try
            {
                _context.Bonuses.Update(bonus);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
            }
        }

        public void Delete(int id)
        {
            try
            {
                var bonus = _context.Bonuses.FirstOrDefault(x => x.Id == id);

                if (bonus != null)
                {
                    _context.Bonuses.Remove(bonus);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
            }
        }

        public IEnumerable<Bonus> GetForRank(int rankId)
        {
            try
            {
                var rank = _context.Ranks
                    .Include(r => r.RankBonus)
                    .ThenInclude(rb => rb.Bonus)
                    .SingleOrDefault(r => r.Id == rankId);

                if (rank != null)
                {
                    var bonus = rank.RankBonus.Select(rb => rb.Bonus).ToList();

                    return bonus;
                }

                return  new List<Bonus>();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
                
                return  new List<Bonus>();
            }
        }
    }
}
