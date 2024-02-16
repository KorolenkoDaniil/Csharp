using Day21.LINQ;
using Day21.MenuMorkWithXML;
using Day21.XPath;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Day21
{
    internal static class MenuOfWorkWithXML
    {
        public static void Menu()
        {
            XmlDocument xdoc = new XmlDocument();
            string filePath = "GreenhouseByDK.xml";

            if (!File.Exists("id.txt"))
            {
                Createfunction.Create();
            }

            string stringID = File.ReadAllText("id.txt").ToString();
            int numberofID = string.IsNullOrEmpty(stringID) ? 1 : int.Parse(stringID);

            if (numberofID == 1)
            {
                File.WriteAllText("id.txt", $"{1}");
            }


            while (true)
            {
                int n;
                do
                {
                    Console.WriteLine("1 - создание документа");
                    Console.WriteLine("2 - выбор файла для работы");
                    Console.WriteLine("3 - чтение объектов и добавление новых");
                    Console.WriteLine("4 - удаление объекта");
                    Console.WriteLine("5 - Работа с LiNQ");
                    Console.WriteLine("6 - фильтрация по почве");
                    Console.WriteLine("0 - выход");

                    Console.WriteLine("выберите пункт меню ");
                    n = int.Parse(Console.ReadLine());
                } while (n < 0 || n > 6);

                if (n == 0)
                {
                    break; // Exit the loop when the user selects "0"
                }

                switch (n)
                {
                    case 1:
                        {
                            MakeNewFileFunction.MakeNewFile(ref xdoc, ref filePath);
                            break;
                        }
                    case 2:
                        {
                            ChoiceOfFileFunction.ChoiceOfFile(ref xdoc, ref filePath);
                            break;
                        }
                    case 3:
                        {
                            xdoc.Load(filePath);
                            PrintNodesFunction.PrintNodes(ref xdoc);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("1 - добавить элемент");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("2 - продолжить без добавления элемента");
                            Console.ResetColor();
                            int a = int.Parse(Console.ReadLine());
                            if (a == 1) NewElementFunction.NewElement(ref xdoc, ref filePath, ref numberofID);

                            break;
                        }
                    case 4:
                        {
                            DeleteFileFunction.DeleteFile(ref xdoc, ref filePath, ref numberofID);
                            break;
                        }
                    case 5:
                        {
                            LINQMenu.Menu(xdoc, filePath);
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("растения с типом земли \"грунтовая\"");
                            XmlNodeList list1 = XpathFiltration.PrimingList(xdoc, filePath);
                            PrintNodesFunction.PrintNodesList(ref list1);

         
                            Console.WriteLine("растения с типом земли \"подзолистая\"");
                            XmlNodeList list2 = XpathFiltration.PodzolicList(xdoc, filePath);
                            PrintNodesFunction.PrintNodesList(ref list2);

                            
                            Console.WriteLine("растения с типом земли \"дерново-подзолистая\"");
                            XmlNodeList list3 = XpathFiltration.SodPodzolicList(xdoc, filePath);
                            PrintNodesFunction.PrintNodesList(ref list3);

                            break;
                        }
                }
            }

        }
    }
}
