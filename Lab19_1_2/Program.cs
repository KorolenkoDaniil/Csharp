using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab19_1_2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Queue <Employer> MQueaue = new Queue<Employer>();
            Queue <Employer> WQueaue = new Queue<Employer>();
            Employer[] EmpAray = new Employer[10]
            {
                new Employer("A", "a", true, 1), 
                new Employer("B", "b", false, 1),
                new Employer("C", "c", true, 1),
                new Employer("D", "d", false, 1),
                new Employer("E", "E", true, 1),
                new Employer("F", "f", false, 1),
                new Employer("G", "g", true, 1),
                new Employer("H", "h", true, 1),
                new Employer("I", "i", false, 1),
                new Employer("J", "j", false, 1)
            };

            StreamWriter writer = new StreamWriter("Employers.txt");
            for (int i = 0; i < EmpAray.Length; i++)
            {
                writer.WriteLine(EmpAray[i]);
            }
            writer.Close();

            string[] lines = File.ReadAllLines("Employers.txt");
            
            Regex ManPattern = new Regex("Мужской");
            Regex WomamanPattern = new Regex("Женский");
            for (int i = 0; i < lines.Length; i++)
            {
                if (ManPattern.IsMatch(lines[i]))
                {
                    string[] ch = lines[i].Split(' ');
                    Employer man = new Employer(ch[0], ch[1], ch[2], ch[3]);
                    MQueaue.Enqueue(man);
                }
                else if (WomamanPattern.IsMatch(lines[i]))
                {
                    string[] ch = lines[i].Split(' ');
                    Employer woman = new Employer(ch[0], ch[1], ch[2], ch[3]);
                    WQueaue.Enqueue(woman);
                }
                else
                {
                    Console.WriteLine($"ошибка с сотрудником {i}");
                }
            }

            var e = MQueaue.Concat( WQueaue );

            foreach (var a in  e )
            {
                Console.WriteLine(a);
            }

            Console.ReadKey();
 





            

        }
    }
}
