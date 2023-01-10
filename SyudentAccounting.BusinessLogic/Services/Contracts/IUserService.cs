
using StudentAccounting.Common.ModelsDto;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IUserService
    {
        void Create(UserDto userDto);
        IEnumerable<UserDto> Get();
        UserDto Get(string name);
        UserDto Get(int id);
        void Edit(UserDto userDto);
        void Delete(int id);
    }
}
