using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccounting.BusinessLogic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class IndividualsService : IIndividualsService
    {
        private readonly ILogger<IndividualsService> _logger;
        private readonly ApplicationDatabaseContext _context;
        
        public IndividualsService(ApplicationDatabaseContext context, ILogger<IndividualsService> logger)
        {
            _logger = logger;
            _context = context;
        }
        
        public void Create(Individuals newIndividuals)
        {
            try
            {
                _context.Individuals.Add(newIndividuals);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
            }
        }
        
        public IEnumerable<Individuals> Get()
        {
            try
            {
                var individuals = _context.Individuals.AsNoTracking().ToList();

                return individuals;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");

                return new List<Individuals>();
            }
        }
        
        public Individuals Get(string name)
        {
            try
            {
                var individuals = _context.Individuals.AsNoTracking().FirstOrDefault(x => x.FIO == name);

                if (individuals == null)
                {
                    return new Individuals();
                }
                
                return individuals;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");

                return new Individuals();
            }
        }
        
        public Individuals Get(int id)
        {
            try
            {
                var individuals = _context.Individuals.AsNoTracking().FirstOrDefault(x => x.Id == id);
                
                if (individuals == null)
                {
                    return new Individuals();
                }
                
                return individuals;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");

                return new Individuals();
            }
        }
        
        public void Edit(Individuals newIndividuals)
        {
            try
            {
                _context.Individuals.Update(newIndividuals);
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
                var individual = _context.Individuals.FirstOrDefault(x => x.Id == id);

                if (individual != null)
                {
                    _context.Individuals.Remove(individual);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
            }
        }
    }
}
