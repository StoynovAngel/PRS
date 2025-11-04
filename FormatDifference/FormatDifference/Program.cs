using System.Xml.Linq;

namespace FormatDifference;

class Program
{
    static void Main(string[] args)
    {
        JsonFormat jsonFormat = new JsonFormat();
        jsonFormat.Display();

        IncorrectXmlFormat.XmlDifference();
        
        XmlFormat xmlFormat = new XmlFormat();
        xmlFormat.Display();
        
        XsdFormat xsdFormat = new XsdFormat();
        xsdFormat.Display();
    }
}