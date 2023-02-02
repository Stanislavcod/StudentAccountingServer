using StudentAccounting.Common.ModelsDto;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IUserService
    {
        void Create(User user);
        IEnumerable<User> Get();
        User Get(string name);
        User Get(int id);
        void EditPassword(EditPasswordUserDto editPasswordUserDto);
        void Edit(User user);
        void Delete(int id);
    }
}
