using System;
using System.Collections.Generic;
using System.Text;

namespace Course.Models
{
    class Student:User
    {
        public List<Trains> trains { get; set; }
    }
}
