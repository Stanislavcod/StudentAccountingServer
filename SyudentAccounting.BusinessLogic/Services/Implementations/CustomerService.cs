using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Model;
using StudentAccounting.BusinessLogic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace StudentAccounting.BusinessLogic.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ILogger<CustomerService> _logger;
        private readonly ApplicationDatabaseContext _context;

        public CustomerService(ApplicationDatabaseContext context, ILogger<CustomerService> logger)
        {
            _logger = logger;
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
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
            }
        }
        
        public IEnumerable<Customer> Get()
        {
            try
            {
                var customers = _context.Customers.AsNoTracking().ToList();

                return customers;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");

                return new List<Customer>();
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
                var customer = _context.Customers.AsNoTracking().FirstOrDefault(x => x.Id == id);

                if (customer == null)
                {
                    return new Customer();
                }

                return customer;
            }
            catch (Exception ex)
            {   
                _logger.LogError($"{DateTime.Now}: {ex.Message}");

                return new Customer();
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
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
            }
        }
        
        public void Delete(int id)
        {
            try
            {
                var customer = _context.Customers.FirstOrDefault(x => x.Id == id);

                if (customer == null)
                {
                    return;
                }
                
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
            }
        }
    }
}
