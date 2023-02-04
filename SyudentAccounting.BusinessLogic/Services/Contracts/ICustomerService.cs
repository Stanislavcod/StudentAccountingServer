using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface ICustomerService
    {
        void Create(Customer customer);
        IEnumerable<Customer> Get();
        Customer Get(string name);
        Customer Get(int id);
        void Edit(Customer customer);
        void Delete(int id);
    }
}
