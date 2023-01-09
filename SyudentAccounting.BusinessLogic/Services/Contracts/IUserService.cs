
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IUserService
    {
        void Create(User user);
        IEnumerable<User> Get();
        User GetName(string name);
        void Edit(User user);
        void Delete(User user);
    }
}
