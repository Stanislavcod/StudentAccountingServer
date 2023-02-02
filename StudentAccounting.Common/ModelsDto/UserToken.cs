using StudentAccounting.Model.DataBaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAccounting.Common.ModelsDto
{
    public class UserToken
    {
        public User User { get; set; }
        public string Token { get; set; }
    }
}
