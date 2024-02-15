using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.IO;
using System.Xml;

namespace Day21.MenuMorkWithXML
{
    internal class NewElementFunction
    {
        public static void NewElement(ref XmlDocument xdoc, ref string filePath, ref int numberofID)
        {

            string[] soils = { "подзолистая", "грунтовая", "дерново-подзолистая" };
            string[] multiplyingTypes = { "листьями", "черенками", "семенами" };


            xdoc.Load(filePath);
            XmlElement xRoot = xdoc.DocumentElement; //взяли корневой

            XmlElement child1 = xdoc.CreateElement("Flower"); //новый узел нового элемента
            child1.SetAttribute("id", $"{numberofID}");
            xRoot.AppendChild(child1);

            Console.WriteLine("введите название цветка");
            string name = Console.ReadLine();



            XmlElement nameElem = xdoc.CreateElement("name");
            nameElem.InnerText = name;
            child1.AppendChild(nameElem);


            string soil = ChoiceClass.ChoiceOfString(soils, "выберите номер земли которая благоприятна для растения");

            XmlElement soilElem = xdoc.CreateElement("soil");
            soilElem.InnerText = soil;
            child1.AppendChild(soilElem);

            Console.WriteLine($"введите страну происхождения {name}");
            string origin = Console.ReadLine();



            XmlElement originElem = xdoc.CreateElement("origin");
            originElem.InnerText = origin.ToString();
            child1.AppendChild(originElem);

            List<string> visualParameters = new List<string>();
            Console.WriteLine($"введите визуально отличительные черты {name}");
            int k;
            do
            {
                string parameter = Console.ReadLine();
                visualParameters.Add(parameter);
                Console.Write("добавить еще 1 черту?  ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("1 - да  ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("2 - нет ");
                k = int.Parse(Console.ReadLine());
            } while (k != 2);


            XmlElement VisualParamElem = xdoc.CreateElement("VisualParamElem");
            child1.AppendChild(VisualParamElem);
            for (int i = 0; i < visualParameters.Count; i++)
            {
                XmlElement paramElem = xdoc.CreateElement("param");
                paramElem.InnerText = visualParameters[i];
                VisualParamElem.AppendChild(paramElem);
            }

            child1.AppendChild(VisualParamElem);



            string multiplying = ChoiceClass.ChoiceOfString(multiplyingTypes, "выберите номер способа размножения"); ;
            XmlElement multiplyingElem = xdoc.CreateElement("multiplying");
            multiplyingElem.InnerText = multiplying;
            child1.AppendChild(multiplyingElem);


            xdoc.Save(filePath);

            numberofID++;
            File.WriteAllText("id.txt", $"{numberofID}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("элемент сохранен");
            Console.ResetColor();
        }

    }

}
