﻿using StudentAccounting.Model.DataBaseModels;
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
        public RoleType Name { get; set; } = RoleType.User;
        public string NormalName { get; set; } = RoleDescription.Get(RoleType.User);

        public List<User> Users { get; set; }
    }
}
