using System.Xml.Linq;

namespace FormatDifference;

public class IncorrectXmlFormat
{
    private const string XmlPath = "person.xml";

    public static void XmlDifference()
    {
        XDocument xmlDocument = XDocument.Load(XmlPath);
        var root = xmlDocument.Root;
        
        var name = root.Element("name").Value; // "Angel"
        var age = root.Element("age").Value; // "10"
        var universityStatus = root.Element("universityStudent").Value; // true

        Console.WriteLine($"\nBefore proper deserialization - XML TYPES:");
        Console.WriteLine($"name: {name.GetType()}"); // String
        Console.WriteLine($"age: {age.GetType()}"); // String
        Console.WriteLine($"status: {universityStatus.GetType()}"); // String
    }
}