using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_20_theory
{
    public class Person
    {
        public string name { get; set; }
        public int age { get; set; }

        public List<string> languagesList;
       
        public Person(string name, int age) 
        {
            this.name = name;
            this.age = age;
        }
        public Person(string name)
        {
            this.name = name;
        }

        public Person(string name, int age, List<string> languagesList)
        {
            this.name = name;
            this.age = age;
            this.languagesList = languagesList;
        }

        public string PrintLanguage()
        {
            string l = "";
            foreach(string s in languagesList)
            {
                l += $" {s}";
            }
            return l;
        }

        public override bool Equals(object obj)
        {
            if (obj is Person person) return this.name == person.name;
            return false;
        }
        public override int GetHashCode()
        {
            return name.GetHashCode();
        }


    }
}
