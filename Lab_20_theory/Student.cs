using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_20_theory
{
    public class Student : Person 
    {
        public string name { get; set; }
        public Student(string name) : base(name) 
        {
            this.name = name;
        }
    }
}
