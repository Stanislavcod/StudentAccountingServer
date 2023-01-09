using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Model;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.BusinessLogic.Implementations
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
        public Organization GetName(string name)
        {
            return _context.Organizations.FirstOrDefault(x => x.Fullname == name);
        }
        public void Edit(Organization organization)
        {
            _context.Organizations.Update(organization);
            _context.SaveChanges();
        }
        public void Delete(Organization organization)
        {
            _context.Organizations.Remove(organization);
            _context.SaveChanges();
        }
    }
}
