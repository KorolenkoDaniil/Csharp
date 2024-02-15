using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Day21.MenuMorkWithXML
{
    internal class ChoiceOfFileFunction
    {
        public static void ChoiceOfFile(ref XmlDocument xdoc, ref string filePath)
        {
            string path = "D:\\C#\\Day21\\bin\\Debug";  //исправь на полный путь папки Lab21_1\\bin\\Debug
            DirectoryInfo thisDirectory = new DirectoryInfo(path);

            FileInfo[] subDirectories = thisDirectory.GetFiles();
            List<FileInfo> XMLsubDirectories = new List<FileInfo>();

            int k = 0;
            foreach (FileInfo subDirectory in subDirectories)
            {

                if (subDirectory.Extension.ToLower() == ".xml")
                {
                    k++;
                    Console.WriteLine($"{k} - {subDirectory.Name}");
                    XMLsubDirectories.Add(subDirectory);
                }
            }

            if (k == 0)
            {
                Console.WriteLine("перед работы с файлом создайте его");
                return;
            }
            int number;
            do {
                Console.WriteLine("введите номер файла, который вы хотите открыть ");
                number = int.Parse(Console.ReadLine());

                if (number < 1 || number > k)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("что-то пошло не так, например такого файл не существует");
                }

            } while (number < 1 || number > k);


            filePath = XMLsubDirectories[number - 1].FullName;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("файл для работы выбран");
            Console.ResetColor();

        }
    }
}
