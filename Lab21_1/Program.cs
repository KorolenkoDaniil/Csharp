using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Lab21_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xdoc = new XmlDocument();
            string filePath = "Motherboard.xml";

            if (!File.Exists("id.txt"))
            {
                Create();
            } 
            string stringID = File.ReadAllText("id.txt").ToString();
            int numberofID = string.IsNullOrEmpty(stringID) ? 1 : int.Parse(stringID);
            
            if (numberofID == 1)
            {
                File.WriteAllText("id.txt", $"{1}");
            }
            

            while (true)
            {
                int n = 1;

                do
                {
                    Console.WriteLine("1 - создание документа");
                    Console.WriteLine("2 - выбор файла для работы");
                    Console.WriteLine("3 - чтение объектов и добавление новых");
                    Console.WriteLine("4 - удаление объекта");
                    Console.WriteLine("5 - ");
                    Console.WriteLine("0 - выход");

                    Console.WriteLine("выберите пункт меню ");
                    n = int.Parse(Console.ReadLine());
                } while (n < 0 || n > 5);

                if (n == 0)
                {
                    break; // Exit the loop when the user selects "0"
                }

                switch (n)
                {
                    case 1:
                        {
                            MakeNewFile(ref xdoc, ref filePath);
                            break;
                        }
                    case 2:
                        {
                            ChoiceOfFile(ref xdoc, ref filePath);
                            break;
                        }
                    case 3:
                        {
                            xdoc.Load(filePath);
                            PrintNodes(ref xdoc);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("1 - добавить элемент");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("2 - продолжить без добавления элемента");
                            Console.ResetColor();
                            int a = int.Parse(Console.ReadLine());
                            if (a == 1) NewElement(ref xdoc, ref filePath, ref numberofID);
                           
                            break;
                        }
                    case 4:
                        {
                            DeleteFile(ref xdoc,ref filePath, ref numberofID);
                            break;
                        }
                    case 5:
                        {
                            xdoc.Load(filePath);

                            break;
                        }
                }
            }
        }

        public static void PrintNodes(ref XmlDocument xdoc)
        {
            foreach (XmlNode personNode in xdoc.DocumentElement.ChildNodes)
            {
                if (personNode.Attributes.Count > 0)
                {
                    foreach (XmlAttribute xmlAttribute in personNode.Attributes)
                    {
                        Console.WriteLine($"{xmlAttribute.Name} {xmlAttribute.InnerText}");
                    }
                } 
                 
                if (personNode.HasChildNodes)
                {
                    foreach (XmlNode dataNode1 in personNode.ChildNodes)
                    {
                        Console.WriteLine($"{dataNode1.Name}: {dataNode1.InnerText}");
                    }
                    Console.WriteLine("--------------------------");
                }
            }
        }




        public static void Create()
        {
            File.Create("id.txt");
        }


        public static void NewElement(ref XmlDocument xdoc, ref string filePath, ref int numberofID)
        {

            xdoc.Load(filePath);
            XmlElement xRoot = xdoc.DocumentElement; //взяли корневой

            XmlElement child1 = xdoc.CreateElement("Motherboard"); //новый узел нового элемента
            child1.SetAttribute("id", $"{numberofID}");
            xRoot.AppendChild(child1);

            Console.WriteLine("введите название материнской платы");
            string name = Console.ReadLine();
            XmlElement nameElem = xdoc.CreateElement("name");
            nameElem.InnerText = name;
            child1.AppendChild(nameElem);

            Console.WriteLine("введите марку материнской платы");
            string mark = Console.ReadLine();
            XmlElement markElem = xdoc.CreateElement("mark");
            markElem.InnerText = mark;
            child1.AppendChild(markElem);

            Console.WriteLine("введите количство памяти в материнской платы");
            int amountOfRAM = int.Parse(Console.ReadLine());
            XmlElement amountOfRAMElem = xdoc.CreateElement("amountOfRAM");
            amountOfRAMElem.InnerText = amountOfRAM.ToString();
            child1.AppendChild(amountOfRAMElem);

            Console.WriteLine("введите цену материнской платы");
            string price = Console.ReadLine();
            XmlElement priceElem = xdoc.CreateElement("price");
            priceElem.InnerText = price.ToString();
            child1.AppendChild(priceElem);



            xdoc.Save(filePath);

            numberofID++;
            File.WriteAllText("id.txt", $"{numberofID}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("элемент сохранен");
            Console.ResetColor();

        }




        public static void ChoiceOfFile(ref XmlDocument xdoc, ref string filePath)
        {
            string path = "D:\\C#\\Lab21_1\\bin\\Debug";  //исправь на полный путь папки Lab21_1\\bin\\Debug
            DirectoryInfo thisDirectory = new DirectoryInfo(path);

            FileInfo[] subDirectories = thisDirectory.GetFiles();
            List<FileInfo> XMLsubDirectories = new List<FileInfo>();

            Console.WriteLine(subDirectories.Length);
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
                Console.WriteLine("перед работой с файлом создайте его");
                return;
            }
            int number;
            try
            {
                Console.WriteLine("введите номер файла, который вы хотите открыть ");
                number = int.Parse(Console.ReadLine());
            }
            catch (IOException)
            {
                Console.WriteLine("что-то пошло не так, например такой файл не существует");
                return;
            }


            filePath = XMLsubDirectories[number - 1].FullName;
            Console.WriteLine("файл для работы выбран");
        }


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
            }

            XmlElement root = xdoc.CreateElement("Motherboards");
            xdoc.AppendChild(root);

            xdoc.Save(filePath);

            Console.WriteLine($"новый файл с названием {filePath} создан", ConsoleColor.Red);
        }


        public static void DeleteFile(ref XmlDocument xdoc, ref string filePath, ref int numberofID)
        {
            xdoc.Load(filePath);
            XmlElement xRoot = xdoc.DocumentElement;

            //xRoot.RemoveAll();     удаление всех узлов
            //XmlNode f = xRoot.FirstChild;      удаление верхнего элемента  

            PrintNodes(ref xdoc);

            Console.WriteLine("выберите индекс элемента, который надо удалить");
            int index = int.Parse(Console.ReadLine());
                

            XmlNode nodeToDelete = xRoot.SelectSingleNode($"//*[@id='{index}']");

            // Удалить узел
            if (nodeToDelete != null)
            {
                xRoot.RemoveChild(nodeToDelete);
                numberofID--;
            }
           

            xdoc.Save(filePath);
        }

    }
}