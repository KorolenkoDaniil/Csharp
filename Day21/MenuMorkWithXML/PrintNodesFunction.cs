using System;
using System.Xml;

namespace Day21.MenuMorkWithXML
{
    internal class PrintNodesFunction
    {
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
                        if (dataNode1.HasChildNodes)
                        {
                            foreach (XmlNode dataNode2 in dataNode1.ChildNodes)
                            {
                                Console.WriteLine($"{dataNode2.Name}: {dataNode2.InnerText}");
                            }
                        }
                    }
                    Console.WriteLine("--------------------------");
                }
            }
        }
    }
}
