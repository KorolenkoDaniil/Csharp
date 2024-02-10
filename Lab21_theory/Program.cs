using System.Xml;

namespace Lab21_theory
{
    internal class Program
    {
        
        string Path = "/Message.xml";
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration declaration = doc.CreateXmlDeclaration("1.0", "UTF-8", "yes");

            XmlElement root = doc.CreateElement("Persons");
            XmlElement person = doc.CreateElement("Person");
            XmlElement name = doc.CreateElement("name");
            XmlElement age = doc.CreateElement("age");
            XmlElement gender = doc.CreateElement("Gender");
        }
    }
}
