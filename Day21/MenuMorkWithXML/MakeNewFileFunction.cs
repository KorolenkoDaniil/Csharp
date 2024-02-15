using System;
using System.IO;
using System.Xml;

namespace Day21.MenuMorkWithXML
{
    internal class MakeNewFileFunction
    {
        public static void MakeNewFile(ref XmlDocument xdoc, ref string filePath)
        {
            try
            {
                Console.WriteLine("введите название нового файла");
                filePath = Console.ReadLine() + ".xml";
            }
            catch (IOException)
            {
                Console.WriteLine("что-то пошло не так, например такой файл уже существует");
                Console.ReadKey();
                return;
            }

            XmlElement root = xdoc.CreateElement("Flower");
            xdoc.AppendChild(root);

            xdoc.Save(filePath);

            Console.WriteLine($"новый файл с названием {filePath} создан", ConsoleColor.Red);
        }
    }
}
