using System;
using System.Collections.Generic;
using System.Xml;

namespace Day21.MenuMorkWithXML
{
    internal class PrintNodesFunction
    {
        public static void PrintNodes(ref XmlDocument xdoc)
        {


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
                        if (dataNode1.HasChildNodes)
                        {
                            foreach (XmlNode dataNode2 in dataNode1.ChildNodes)
                            {
                                Console.Write($"{dataNode2.Name}: {dataNode2.InnerText}  ");
                            }
                        }
                        else
                        {
                            Console.Write($"{dataNode1.Name}: {dataNode1.InnerText}  ");
                        }
                    }
                    Console.WriteLine("----------------------------------------------");
                }
            }
        }
        
        public static void PrintNodesList(ref XmlNodeList NodeList)
        {
            foreach (XmlNode FlowerNode in NodeList)
            {
                if (FlowerNode.HasChildNodes)
                {
                    foreach (XmlNode dataNode1 in FlowerNode.ChildNodes)
                    {
                        if (dataNode1.HasChildNodes)
                        {
                            foreach (XmlNode dataNode2 in dataNode1.ChildNodes)
                            {
                                Console.Write($"{dataNode2.InnerText}  ");
                            }
                        }
                        else
                        {
                            Console.Write($"{dataNode1.InnerText}  ");
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("--------------------------");
                }
            }
        }



    }
}
