using StudentAccounting.Common.Constants;

namespace StudentAccounting.Common.Seeds
{
    public static class RoleDescription
    {
        public static string Get(RoleType role)
        {
            string description = role switch
            {
                RoleType.User => "Application user",
                RoleType.Admin => "User with additional rights",
                RoleType.GlobalPm => "Pm which has limited access to the table",
                RoleType.LocalPm => "Local Pm has limited access to one table"
            };
            return description;
        }
    }
}
