using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day21
{
    public static class ChoiceClass
    {
        public static string ChoiceOfString (string[] possibleValues, string message)
        {
            Random random = new Random();
            int value;
            do
            {
                for (int i = 0; i < possibleValues.Length; i++)
                {
                    Console.WriteLine($"{i + 1} - {possibleValues[i]}");
                }
                Console.WriteLine(message);
                //value = int.Parse(Console.ReadLine());
                value = random.Next(1, possibleValues.Length);

                if (value <= 0 || value > possibleValues.Length) Console.WriteLine("проверьте введенное число");
            } while (value <= 0 || value > possibleValues.Length);
            return possibleValues[value - 1];
        }
    }
}
