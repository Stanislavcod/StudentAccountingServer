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
            try
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Customer> Get()
        {
            try
            {
                return _context.Customers.AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Customer Get(string name)
        {
            try
            {
                return _context.Customers.AsNoTracking().FirstOrDefault(x => x.FullName == name);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Customer Get(int id)
        {
            try
            {
                return _context.Customers.AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {   
                throw new Exception(ex.Message);
            }
        }
        public void Edit(Customer customer)
        {
            try
            {
                _context.Customers.Update(customer);
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
                var customer = _context.Customers.FirstOrDefault(x => x.Id == id);
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
