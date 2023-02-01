using Microsoft.EntityFrameworkCore;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Model;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class OrganizationService : IOrganizationService
    {
        private readonly ApplicationDatabaseContext _context;
        public OrganizationService(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        public void Create(Organization organization)
        {
            try
            {
                _context.Organizations.Add(organization);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Organization> Get()
        {
            try
            {
                return _context.Organizations.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Organization Get(string name)
        {
            try
            {
                return _context.Organizations.AsNoTracking().FirstOrDefault(x => x.Fullname == name);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Organization Get(int id)
        {
            try
            {
                return _context.Organizations.AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Edit(Organization organization)
        {
            try
            {
                _context.Organizations.Update(organization);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
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
                var organization = _context.Organizations.FirstOrDefault(x => x.Id == id);
                _context.Organizations.Remove(organization);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
