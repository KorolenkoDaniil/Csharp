using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day19_1
{
    internal class Employer
    {
        public string _name {  get; set; }
        public string _surname { get; set; }
        public string _Adress { get; set; }
        public int _house { get; set; }
        public int _apartment { get; set; }

        public Employer() { }

        public Employer (string name, string surname, string adress, int house, int apatrment )
        {
            _name = name;
            _surname = surname;
            _Adress = adress;
            _house = house;
            _apartment = apatrment;

        }

        //public Employer(string name, string surname, string sex, string salary)
        //{
        //    _name = name;
        //    _surname = surname;
        //    _salary = int.Parse(salary);
        //    _sex = sex;
        //}

        public override string ToString()
        {
            return $"{_surname} {_name} {_Adress} {_house} {_apartment}";
        }



    }
}
