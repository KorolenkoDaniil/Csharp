using System;
using System.Collections.Generic;
using System.Linq;
using static System.Math;


namespace Lab20_1_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Random rand = new Random();
            int n = rand.Next(20);
            double[] RandomArray = new double[n];

            for (int i = 0; i < n; i++)
            {
                RandomArray[i] = rand.Next(-10, 10);
                Console.Write($"{RandomArray[i]} ");
            }

            Console.WriteLine();
            Console.WriteLine("отрицательных элементов " + (from a in RandomArray where a < 0 select a).Count());

            int indexOfMin = Array.IndexOf(RandomArray, RandomArray.Min());
            Console.WriteLine("сумма после минимального " + RandomArray.Skip(indexOfMin + 1).Sum());



            var v = RandomArray.Select(g => g < 0 ? Pow(g, 2) : g).OrderBy(g => g).ToArray();

            Console.WriteLine($"упорядоченный массив с квадратами отрицательных чисел ");
            Print(v);





            //------------------------------------
            int count = (from p in RandomArray where p < 0 select p).Count();
            double sum = (from p in RandomArray where p < 0 select p).Sum();

            Console.WriteLine($"сумм отрицательных {sum}");


            //------------------------------------
            int[] aa = new int[5]
            {
                2, 1, 3, 4, 5,
            };

            int indexmin = Array.IndexOf(aa, aa.Min());
            int indexmax = Array.IndexOf(aa, aa.Max());

            double multi = 1;

            if (indexmin < indexmax)
            {
                multi = aa.Skip(indexmin + 1).Take(indexmax - indexmin -1).Aggregate((x, y) => x * y);
            }


            Print(aa);
            Console.WriteLine($"произвдение {multi}");




            Console.ReadKey();
        }

        public static void Print(double[] Mas)
        {
            Mas = Mas.OrderBy(x => x).ToArray();
            for (int i = 0; i < Mas.Length; i++) Console.Write($"{Mas[i]} ");
        }
        public static void Print(int[] Mas)
        {
            Mas = Mas.OrderBy(x => x).ToArray();
            for (int i = 0; i < Mas.Length; i++) Console.Write($"{Mas[i]} ");
        }
    }
}
