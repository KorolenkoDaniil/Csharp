using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19_1_2
{
    internal class Employer
    {
        public string _name {  get; set; }
        public string _surname { get; set; }
        public string _sex { get; set; }
        public int _salary { get; set; }

        public Employer() { }

        public Employer (string name, string surname, bool sex, int salary)
        {
            _name = name;
            _surname = surname;
            _salary = salary;
            _sex = (sex == true) ? "Мужской" : "Женский";
        }

        public Employer(string name, string surname, string sex, string salary)
        {
            _name = name;
            _surname = surname;
            _salary = int.Parse(salary);
            _sex = sex;
        }

        public override string ToString()
        {
            return $"{_surname} {_name} {_sex} {_salary}";
        }



    }
}
