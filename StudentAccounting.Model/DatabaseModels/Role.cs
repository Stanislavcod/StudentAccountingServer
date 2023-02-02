using StudentAccounting.Model.DataBaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAccounting.Model.DatabaseModels
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NormalName { get; set; }
        public Role()
        {
            Users = new List<User>();
        }
        public List<User> Users { get; set; }

    }
}
