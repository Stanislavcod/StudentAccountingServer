using StudentAccounting.Common.ModelsDto;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IRoleService
    {
        IEnumerable<RoleDto> Get();
    }
}
