using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19__2_
{
    public class Program
    {
        static List<object> labelList = new List<object>();

        static void Main(string[] args)
        {
            for (; ; )
            {
                int num = 0;
                do
                {
                    Console.WriteLine("выберите пункцт меню");
                    Console.WriteLine("1 - добавить элементв коллекцию");
                    Console.WriteLine("2 - считать данные из файла");
                    Console.WriteLine("3 - записать данные в файл");
                    Console.WriteLine("4 - сортировать данные ");
                    Console.WriteLine("5 - найти по выбарнному критерию");
                    Console.WriteLine("6 - вывод всех элементов");
                    Console.WriteLine("7 - удалить элемент из коллекции");
                    num = int.Parse(Console.ReadLine());
                } while (num < 0);
                Label label1 = new Label();
                switch (num)
                {
                    case 1:
                        {

                            label1._Path = "File.txt";
                            Console.WriteLine("введите навзание для ярдыка");
                            label1._Name = Console.ReadLine();
                            label1._DateOfCreation = DateTime.Now;
                            labelList.Add(label1);
                            break;
                        }
                    case 2:
                        {
                            string DataAboutFiles = File.ReadAllText("File.txt");
                            Console.WriteLine(DataAboutFiles);
                            break;
                        }
                    case 3:
                        {
                            WriteDataToFile();
                            Console.WriteLine("Даныые о вашем листе записаны");
                            break;
                        }
                    case 4:
                        {
                            labelList.Sort();
                            Console.WriteLine("сортировка прошла успешно");
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Выберите критерий для поиска:");
                            Console.WriteLine("1 - По названию");
                            Console.WriteLine("2 - По дате создания");
                            int criteria = int.Parse(Console.ReadLine());

                            switch (criteria)
                            {
                                case 1:
                                    Console.WriteLine("Введите название для поиска:");
                                    string searchName = Console.ReadLine();
                                    List<Label> searchResultsByName = labelList.OfType<Label>().Where(label => label._Name == searchName).ToList();
                                    if (searchResultsByName.Any())
                                    {
                                        Console.WriteLine("Результаты поиска по названию:");
                                        foreach (Label result in searchResultsByName)
                                        {
                                            Console.WriteLine(result.ToString());
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Нет результатов для введенного названия.");
                                    }
                                    break;

                                case 2:
                                    Console.WriteLine("Введите дату для поиска (в формате ГГГГ-ММ-ДД):");
                                    if (DateTime.TryParse(Console.ReadLine(), out DateTime searchDate))
                                    {
                                        List<Label> searchResultsByDate = labelList.OfType<Label>().Where(label => label._DateOfCreation.Date == searchDate.Date).ToList();
                                        if (searchResultsByDate.Any())
                                        {
                                            Console.WriteLine("Результаты поиска по дате создания:");
                                            foreach (Label result in searchResultsByDate)
                                            {
                                                Console.WriteLine(result.ToString());
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Нет результатов для введенной даты.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Некорректный формат даты.");
                                    }
                                    break;

                                default:
                                    Console.WriteLine("Некорректный критерий поиска.");
                                    break;
                            }
                            break;
                        }

                    case 6:
                        {
                            for (int i = 0; i < labelList.Count;i++)
                            {
                                Console.WriteLine(labelList[i].ToString());
                            }
                            break;
                        }
                    case 7:
                        {
                         
                            for (int i = 0; i < labelList.Count; i++)
                            {
                                Console.WriteLine(i + " " + labelList[i].ToString());
                            }
                            int k = 0;
                            do
                            {
                                Console.WriteLine("выберите номер ярлыка для удаления ");
                                k = int.Parse(Console.ReadLine());
                            } while (k < 0 || k > labelList.Count);
                            RemoveLabel(k);
                            break;
                        }
                }
            }

        }



        static void WriteDataToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("File.txt"))
                {
                    foreach (object item in labelList)
                    {
                        writer.WriteLine(item.ToString());
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Ошибка при записи данных в файл");
            }
        }



        static void RemoveLabel(int i)
        {
            labelList.Remove(labelList[i]);
        }
    }
}
