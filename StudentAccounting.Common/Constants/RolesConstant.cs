using StudentAccounting.Common.Enums;
using StudentAccounting.Model.DatabaseModels;

namespace StudentAccounting.Common.Constants
{
    public static class RolesConstant
    {
        public static List<Role> Roles = new List<Role>
        {
            new Role{ Name = nameof(RoleEnum.User), NormalName = "User"},
        };
    }
}
