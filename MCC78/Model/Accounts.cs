﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC78.Model
{
    public class Accounts
    {
        public int EmployeeId { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        public string Otp { get; set; }
        public DateTime ExpiredTime { get; set; }
    }
}
