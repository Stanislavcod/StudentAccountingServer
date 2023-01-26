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
            _context.Organizations.Add(organization);
            _context.SaveChanges();
        }
        public IEnumerable<Organization> Get()
        {
            return _context.Organizations.ToList();
        }
        public Organization Get(string name)
        {
            return _context.Organizations.AsNoTracking().FirstOrDefault(x => x.Fullname == name);
        }
        public Organization Get(int id)
        {
            return _context.Organizations.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
        public void Edit(Organization organization)
        {
            _context.Organizations.Update(organization);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var organization = _context.Organizations.FirstOrDefault(x => x.Id == id);
            _context.Organizations.Remove(organization);
            _context.SaveChanges();
        }
    }
}
