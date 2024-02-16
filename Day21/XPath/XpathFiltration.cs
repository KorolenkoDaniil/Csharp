using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Day21.XPath
{
    internal static class XpathFiltration
    {
        public static XmlNodeList PrimingList(XmlDocument xdoc, string filePath)
        {
            xdoc.Load(filePath);
            return xdoc.SelectNodes("//Flower[soil='грунтовая']");
        }
        public static XmlNodeList PodzolicList(XmlDocument xdoc, string filePath)
        {
            xdoc.Load(filePath);
            return xdoc.SelectNodes("//Flower[soil='подзолистая']");
        }
        public static XmlNodeList SodPodzolicList(XmlDocument xdoc, string filePath)
        {
            xdoc.Load(filePath);
            return xdoc.SelectNodes("//Flower[soil='дерново-подзолистая']");
        }

    }
}
