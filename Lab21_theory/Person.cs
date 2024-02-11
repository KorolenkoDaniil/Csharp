using System.Collections.Generic;

namespace Lab_21_theory
{
    class Person
    {
        public string Name { get; }
        public int Age { get; set; }
        public string Company { get; set; }
        public Person(string name, int age, string company)
        {
            Name = name;
            Age = age;
            Company = company;
        }
    }
}
