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
                        List<string> param = new List<string>();
                        Console.WriteLine($"{dataNode1.Name}: {dataNode1.InnerText}");
                        if (dataNode1.HasChildNodes)
                        {
                            param = new List<string>();
                            foreach (XmlNode dataNode2 in dataNode1.ChildNodes)
                            {
                                if (dataNode2.Name == "param") param.Add(dataNode2.InnerText);
                                Console.WriteLine($"{dataNode2.Name}: {dataNode2.InnerText}");
                            }
                            
                        }
                        flower.VisualParameters = param;
                    }
                    Console.WriteLine("--------------------------");
                }
                GreenHouse.Add(flower);
            }


            Console.WriteLine("!!!!!!!!!!");
            Console.WriteLine();
            Console.WriteLine(GreenHouse[0]);
            Console.WriteLine("!!!!!!!!!!");





            do
            {
                Console.WriteLine("осуществить поиск ");
                Console.WriteLine("сортировать данные по убыванию названий");
                Console.WriteLine("сгруппировать данные по месту происхождения");
                n = int.Parse(Console.ReadLine());
            }while (n < 1 ||  n > 3);
            
            switch(n)
            {
                case 1:
                    {

                        break;
                    }
                case 2:
                    {
                        break;
                    }
                case 3:
                    {
                        break;
                    }
            }
        }
    }
}
