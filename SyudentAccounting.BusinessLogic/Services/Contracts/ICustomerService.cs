
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface ICustomerService
    {
        void Create(Customer customer);
        IEnumerable<Customer> Get();
        Customer GetName(string name);
        void Edit(Customer customer);
        void Delete(Customer customer);
    }
}
