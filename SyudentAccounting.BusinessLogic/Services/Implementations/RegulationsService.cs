using StudentAccounting.Model;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace StudentAccounting.BusinessLogic.Services.Implementations
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
            try
            {
                _context.Regulations.Add(regulation);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Regulation> Get()
        {
            try
            {
                return _context.Regulations.Include(x => x.Organization).AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Regulation Get(string name)
        {
            try
            {
                return _context.Regulations.Include(x => x.Organization).AsNoTracking().FirstOrDefault(x => x.Name == name);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Regulation Get(int id)
        {
            try
            {
                return _context.Regulations.Include(x => x.Organization).AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Edit(Regulation regulation)
        {
            try
            {
                _context.Regulations.Update(regulation);
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
                var regulation = _context.Regulations.FirstOrDefault(x => x.Id == id);
                _context.Regulations.Remove(regulation);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
