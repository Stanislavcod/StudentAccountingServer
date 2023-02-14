using StudentAccounting.Model.DataBaseModels;
using StudentAccounting.Common.Constants;

namespace StudentAccounting.Model.DatabaseModels
{
    public class Role 
    {
        public int Id { get; set; }
        public RoleType Name { get; set; }
        public string NormalName { get; set; } = string.Empty;
        public List<User>? Users { get; set; }
    }
}
