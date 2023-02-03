using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Common.Constants;
using StudentAccounting.Common.Seeds;

namespace StudentAccounting.Model.DatabaseModels
{
    public class Role 
    {
        public int Id { get; set; }
        public RoleType Name { get; set; }
        public string NormalName { get; set; } 
        public List<User> Users { get; set; }
    }
}
