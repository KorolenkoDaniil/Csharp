using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day19_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employer[] EmpArray = new Employer[0];

            Queue<Employer> EmpQuequ = new Queue<Employer>();

            EmpQuequ.Enqueue(new Employer("A", "a", "Bb", 30, 40));
            EmpQuequ.Enqueue(new Employer("B", "b", "Красная", 30, 40));
            EmpQuequ.Enqueue(new Employer("C", "c", "Bb", 30, 40));
            EmpQuequ.Enqueue(new Employer("D", "d", "Bb", 30, 40));
            EmpQuequ.Enqueue(new Employer("E", "e", "Bb", 30, 40));
            EmpQuequ.Enqueue(new Employer("F", "f", "Красная", 30, 40));
            EmpQuequ.Enqueue(new Employer("G", "g", "Bb", 30, 40));
            EmpQuequ.Enqueue(new Employer("H", "h", "Bb", 30, 40));
            EmpQuequ.Enqueue(new Employer("I", "i", "Красная", 30, 40));
            EmpQuequ.Enqueue(new Employer("J", "j", "Bb", 30, 40));
            EmpQuequ.Enqueue(new Employer("K", "k", "Bb", 30, 40));




            foreach (var person in EmpQuequ)
            {
                Console.WriteLine(person);
                if (person._Adress == "Красная")
                {
                    Array.Resize(ref EmpArray, EmpArray.Length + 1);
                    EmpArray[EmpArray.Length - 1] = person;
                }
            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine("работники с улицы Красная");

            foreach (var person in EmpArray)
            {
                Console.WriteLine(person);
            }




            Console.WriteLine("Рабоитники с Красной улицы 2");
            
            Hashtable RmpHashTable = new Hashtable();
            RmpHashTable.Add(1, new Employer("A", "a", "Bb", 30, 40));
            RmpHashTable.Add(2,new Employer("B", "b", "Красная", 30, 40));
            RmpHashTable.Add(3, new Employer("C", "c", "Bb", 30, 40));
            RmpHashTable.Add(4, new Employer("D", "d", "Bb", 30, 40));
            RmpHashTable.Add(5, new Employer("E", "e", "Bb", 30, 40));
            RmpHashTable.Add(6, new Employer("F", "f", "Красная", 30, 40));
            RmpHashTable.Add(7, new Employer("G", "g", "Bb", 30, 40));
            RmpHashTable.Add(8, new Employer("H", "h", "Bb", 30, 40));
            RmpHashTable.Add(9, new Employer("I", "i", "Красная", 30, 40));
            RmpHashTable.Add(10, new Employer("J", "j", "Bb", 30, 40));
            RmpHashTable.Add(11, new Employer("K", "k", "Bb", 30, 40));


            foreach (var key in RmpHashTable.Keys)
            {
                Employer a = (Employer)RmpHashTable[key];
                if (a._Adress == "Красная")
                {
                    Console.WriteLine(a.ToString());
                }
            }


            Console.ReadKey();
        }
       
    }
}
