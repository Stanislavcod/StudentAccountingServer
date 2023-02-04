using StudentAccounting.Common.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAccounting.BusinessLogic.Services.Contracts
{
    public interface IRoleService
    {
        IEnumerable<RoleDto> Get();
    }
}
