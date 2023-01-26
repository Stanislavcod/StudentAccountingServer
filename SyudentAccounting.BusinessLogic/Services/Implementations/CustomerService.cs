using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccounting.BusinessLogic.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDatabaseContext _context;

        public CustomerService(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        public void Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
        public IEnumerable<Customer> Get()
        {
            return _context.Customers.AsNoTracking().ToList();
        }
        public Customer Get(string name)
        {
            return _context.Customers.AsNoTracking().FirstOrDefault(x => x.FullName == name);
        }
        public Customer Get(int id)
        {
            return _context.Customers.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
        public void Edit(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}
