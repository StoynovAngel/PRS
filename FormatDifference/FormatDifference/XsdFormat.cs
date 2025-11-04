using System.Xml;
using System.Xml.Schema;

namespace FormatDifference;

public class XsdFormat : Format
{
    private const string XmlPath = "person_with_xsd.xml";
    private const string XsdPath = "root.xsd";
    
    public override void Display()
    {
        var xml = Path.Combine(AppContext.BaseDirectory, XmlPath);
        var xsd = Path.Combine(AppContext.BaseDirectory, XsdPath);
        
        var schema = new XmlSchemaSet();
        schema.Add("", xsd);

        var settings = new XmlReaderSettings
        {
            Schemas = schema,
            ValidationType = ValidationType.Schema
        };
        settings.ValidationEventHandler += ValidationCallback;

        using var reader = XmlReader.Create(xml, settings);
        while (reader.Read()) { }
        Console.WriteLine("XML is valid according to the XSD schema.");
    }
    
    private static void ValidationCallback(object? sender, ValidationEventArgs e)
    {
        Console.WriteLine($"Validation error: {e.Message}");
    }
}