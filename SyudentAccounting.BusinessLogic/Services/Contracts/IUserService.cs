using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IUserService
    {
        void Create(User userDto);
        IEnumerable<User> Get();
        User Get(string name);
        User Get(int id);
        User Get(string login, string password);
        void Edit(User userDto);
        void Delete(int id);
    }
}
