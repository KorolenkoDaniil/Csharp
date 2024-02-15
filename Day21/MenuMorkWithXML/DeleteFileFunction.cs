using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Day21.MenuMorkWithXML
{
    internal class DeleteFileFunction
    {
        public static void DeleteFile(ref XmlDocument xdoc, ref string filePath, ref int numberofID)
        {
            xdoc.Load(filePath);
            XmlElement xRoot = xdoc.DocumentElement;

            //xRoot.RemoveAll();     удаление всех узлов
            //XmlNode f = xRoot.FirstChild;      удаление верхнего элемента  

            PrintNodesFunction.PrintNodes(ref xdoc);

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
