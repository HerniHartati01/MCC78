﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC78.Model
{
    public class Rooms
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Floor { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }
    }
}
