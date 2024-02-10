using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19_1_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList ItemList = new ArrayList();

            string[] lines = File.ReadAllLines("items1.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                string[] c = lines[i].Split(' ');
                Item item = new Item(c[0], c[1], c[2]);
                ItemList.Add(item);
                Console.WriteLine(item);
            }

            ItemList.Sort();
            Console.WriteLine();

            StreamWriter writer = new StreamWriter("items2.txt");
            for (int i = 0; i < ItemList.Count; i++)
            {
                writer.WriteLine((ItemList[i]).ToString());
                Console.WriteLine(ItemList[i].ToString());
            }
            writer.Close();
            Console.ReadKey();
        }
    }
}
