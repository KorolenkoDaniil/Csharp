using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Day21.LINQ
{
    internal static class LINQMenu
    {
        public static void Menu(XmlDocument xdoc, string filePath)
        {
            int n;
            List<Flower> GreenHouse = new List<Flower>();
            XmlDocument xdocc = xdoc;

            xdocc.Load(filePath);

            foreach (XmlNode FlowerNode in xdoc.DocumentElement.ChildNodes)
            {
                Flower flower = new Flower();
                if (FlowerNode.Attributes.Count > 0)
                {
                    foreach (XmlAttribute xmlAttribute in FlowerNode.Attributes)
                    {
                        if (xmlAttribute.Name == "id")
                        {
                            flower.Id = int.Parse(xmlAttribute.InnerText);
                        }
                    }
                }

                if (FlowerNode.HasChildNodes)
                {
                    foreach (XmlNode dataNode1 in FlowerNode.ChildNodes)
                    {
                        if (dataNode1.Name == "name") flower.Name = dataNode1.InnerText;
                        if (dataNode1.Name == "soil") flower.Soil = dataNode1.InnerText;
                        if (dataNode1.Name == "origin") flower.Origin = dataNode1.InnerText;
                        if (dataNode1.Name == "VisualParamElem" && dataNode1.HasChildNodes)
                        {
                            List<string> param = new List<string>();
                            foreach (XmlNode dataNode2 in dataNode1.ChildNodes)
                            {
                                if (dataNode2.Name == "param") param.Add(dataNode2.InnerText);
                                Console.WriteLine($"{dataNode2.Name}: {dataNode2.InnerText}");
                            }
                            flower.VisualParameters = param;
                        }
                        Console.WriteLine($"{dataNode1.Name}: {dataNode1.InnerText}");
                    }
                    Console.WriteLine("--------------------------");
                }
                GreenHouse.Add(flower);
            }


            do
            {
                Console.WriteLine("1 - осуществить поиск ");
                Console.WriteLine("2 - сортировать данные по убыванию названий");
                Console.WriteLine("3 - сгруппировать данные по месту происхождения");
                n = int.Parse(Console.ReadLine());
            }while (n < 1 ||  n > 3);
            
            switch(n)
            {
                case 1:
                    {
                        Console.WriteLine("для поиска введите название/почву/происхождение/визуальный параметр");
                        string searchParam = Console.ReadLine();

                        Flower selectedFlower = Search.SearchItem(GreenHouse, searchParam);

                        if (selectedFlower != null) Console.WriteLine("ничего не удалось найти, проверьте данные, которые ввели");
                        else
                        {
                            Console.WriteLine(selectedFlower); ;
                        }
                        break;
                    }
                case 2:
                    {
                        Print(SortByNames.SortbyNames(GreenHouse));
                        break;
                    }
                case 3:
                    {
                        IGrouping<string, Flower> GroupedGreenhouse = GroupbyOrigin.Groupbyorigin(GreenHouse);
                        foreach (Flower flower in GroupedGreenhouse)
                        {
                            Console.WriteLine(flower);
                        }
                        break;
                    }
            }
        }

        public static void Print(List <Flower> GreenHouse)
        {
            for (int i = 0; i <  GreenHouse.Count; i++)
            {
                Console.WriteLine(GreenHouse[i]);
                Console.WriteLine("-----------------------------");
            }
        }
    }
}
