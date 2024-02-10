using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab19_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Label> LabelList = new List<Label>();
            List<string> Paths = new List<string>()
            {
                "0 - создать новый путь"
            };

            for (; ; )
            {
                int num = 0;
                do
                {
                    Console.WriteLine("выберите пункт меню");
                    Console.WriteLine("1 - добавить элемент в коллекцию");
                    Console.WriteLine("2 - считать данные из файла");
                    Console.WriteLine("3 - записать данные в файл");
                    Console.WriteLine("4 - сортировать данные");
                    Console.WriteLine("5 - поиск элемента по заданному критерию");
                    Console.WriteLine("6 - вывод всех элементов ");
                    Console.WriteLine("7 - удаление элемента из коллекуии");
                    num = int.Parse(Console.ReadLine());
                } while (num < 1);

                Label label = new Label();

                switch (num) { 
                    case 1: {
                            Console.WriteLine("введите название ярлыка");
                            label._Name = Console.ReadLine();
                            Console.WriteLine("выберите путь к файлу в который звписать");
                            for (int i = 0; i < Paths.Count; i++)
                            {
                                Console.WriteLine(Paths[i]);
                            }
                            int path = int.Parse(Console.ReadLine());
                            string filePath = "";
                            if (path == 0)
                            {
                                Console.WriteLine("Введите путь к файлу:");
                                filePath = Console.ReadLine();
                                string pattern = @"^[a-zA-Z]:\\(?:[^\\/:*?""<>|\r\n]+\\)*[^\\/:*?""<>|\r\n]*$";
                                if (Regex.IsMatch(filePath, pattern))
                                {
                                    StreamWriter writer = new StreamWriter(filePath);
                                    writer.Close();
                                }
                                else
                                {
                                    Console.WriteLine("Неверный формат пути к файлу");
                                }
                                label._Path = filePath;
                                Paths.Add(label._Path);
                            }
                            else
                            {
                                label._Path = Paths[path];
                            }

                            label._DateOfCreation = DateTime.Now;
                            break;
                        }
                    case 2:
                        {
  
                            Console.WriteLine("выберите путь к файлу из которого читать");
                            for (int i = 1; i < Paths.Count; i++)
                            {
                                Console.WriteLine(Paths[i]);
                            }
                            int path = int.Parse(Console.ReadLine());
                            string filePath = Paths[path];
                            StreamReader reader = new StreamReader(filePath);
                            Console.WriteLine(reader.ReadToEnd());
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("выберите путь к файлу в который звписать");
                            for (int i = 1; i < Paths.Count; i++)
                            {
                                Console.WriteLine(Paths[i]);
                            }
                            int path = int.Parse(Console.ReadLine());
                            string filePath = Paths[path];
                            StreamWriter writer = new StreamWriter(filePath);
                            writer.Write(label.ToString());
                            writer.Close();
                            break;
                        }
                    case 4:
                        {
                            LabelList.Sort();
                            Console.WriteLine("сортировка выполнена");
                            break;
                        }
                    case 5:
                        {
                            int criterion = 0;
                            do
                            {
                                Console.WriteLine("выберите критерий");
                                Console.WriteLine("1 - название");
                                Console.WriteLine("2 - путь");
                                Console.WriteLine("3 - дата");
                            } while (criterion < 1);

                            switch (criterion)
                            {
                                case 1:
                                    Console.WriteLine("Введите название для поиска:");
                                    string searchName = Console.ReadLine();
                                    List<Label> matchingLabelsByName = LabelList.Where(lab => lab._Name == searchName).ToList();
                                    foreach (Label lab in matchingLabelsByName)
                                    {
                                        Console.WriteLine(lab);
                                    }
                                    if (matchingLabelsByName.Count == 0) Console.WriteLine("нет подходящих элементоа");
                                    break;


                                case 2:
                                    Console.WriteLine("Введите путь для поиска:");
                                    string searchPath = Console.ReadLine();
                                    List<Label> matchingLabelsByPath = LabelList.Where(lab => lab._Path == searchPath).ToList();

                                    foreach (Label lab in matchingLabelsByPath)
                                    {
                                        Console.WriteLine(lab);
                                    }
                                    if (matchingLabelsByPath.Count == 0) Console.WriteLine("нет подходящих элементоа");
                                    break;


                                case 3:
                                    Console.WriteLine("Введите дату для поиска (в формате ГГГГ-ММ-ДД):");
                                    string searchDateStr = Console.ReadLine();
                                    if (DateTime.TryParse(searchDateStr, out DateTime date))
                                    {
                                        List<Label> matchingLabelsByDate = LabelList.Where(lab => lab._DateOfCreation.Date == date.Date).ToList();
                                        foreach (Label lab in matchingLabelsByDate)
                                        {
                                            Console.WriteLine(lab);
                                        }
                                        if (matchingLabelsByDate.Count == 0) Console.WriteLine("нет подходящих элементоа");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Неверный формат даты");
                                    }
                                    break;
                            }
                            break;
                        }

                    case 6:
                        {
                            for (int i = 0; i < LabelList.Count; i++)
                            {
                                Console.WriteLine(LabelList[i]);
                            }
                            break;
                        }
                    case 7:
                        {
                            Label a = new Label();
                            Console.WriteLine("введите названия ярлыка для удаления");
                            a._Name = Console.ReadLine();
                            Console.WriteLine("введите путь ярлыка для удаления");
                            a._Name = Console.ReadLine();
                            LabelList.Remove(a);
                            break;
                        }
                }
            }
        }
    }
}
